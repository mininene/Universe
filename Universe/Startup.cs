using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Universe.InfraestructureTransversal;
using Universe.InfraestructureTransversal.ControllerException;
using Universe.InfraestructureTransversal.ServicesException;
using Universe.Services;
using Universe.Services.CurrencyService;
using Universe.Services.FactoryService;
using Universe.Services.FactoryService.Rebeldfactory;
using Universe.Services.LogService;
using Universe.Services.Repository;
using Universe.Services.SplitService;
using Universe.Services.ValidationService;

namespace Universe
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }  // Variable del sistema para saber el entorno de trabajo de la APP
        


        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services) //Aqui van todos los servicios
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);  //Servicio MVC
                services.AddScoped(typeof(ISplitService), typeof(SplitService)); // Servicio Split tomar cadena y separarla con ","
                services.AddScoped(typeof(IRebeldListFactory), typeof(RebeldListFactory)); // Servicio RebeldListFactory para hacer lista de rebeldes,cualquier entorno
                services.AddScoped(typeof(IRebeldFactory), typeof(RebeldFactory)); // Servicio RebeldFactory para cambiar la forma de crear rebeldes,cualquier entorno
                services.AddScoped(typeof(IValidationRegisterSpecification), typeof(ValidationRegisterSpecification)); // Servicio Factory cualquier entorno
                
            if (Env.IsDevelopment())
            {
                services.AddScoped(typeof(IRepositoryRebelds), typeof(FakeRepositoryRebelds));// Servicio Repository depende del usuario
                services.AddSingleton(typeof(ILog), typeof(DevelopmentLog));  // Servicio Log el mismo objeto para todos                
                services.AddTransient(typeof(ICurrencyService), typeof(CurrencyService)); // Servicio Currency

            }

            else
            {
                services.AddScoped(typeof(IRepositoryRebelds), typeof(ApiRepositoryRebelds));// Servicio Repository depende del usuario
                services.AddSingleton(typeof(ILog), typeof(ProductionLog));  // Servicio Log el mismo objeto para todos 
                services.AddTransient(typeof(ICurrencyService), typeof(CurrencyService)); // Servicio Currency 

            }



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILog log)
        {
            app.UseStaticFiles();
             app.UseMvc();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
               

            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));  //Registro del Middleware

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
            


        }
        public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate next;
            public ErrorHandlingMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task Invoke(HttpContext context,IServiceProvider serviceProvider /* other dependencies */)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    ILog log = serviceProvider.GetService<ILog>();
                    await HandleExceptionAsync(context, ex, log);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILog log)
            {
                var code = HttpStatusCode.InternalServerError; // 500 if unexpected

                
                if (ex is RepositoryException)  code = HttpStatusCode.NotFound;
                else if (ex is FactoryException) code = HttpStatusCode.BadRequest;
                else if (ex is SplitException) code = HttpStatusCode.BadRequest;
                else if (ex is ControllerException) code = HttpStatusCode.BadRequest;
                else if (ex is ValidationException) code = HttpStatusCode.BadRequest;
                else if (ex is LogException) code = HttpStatusCode.NotFound;

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                log.WriteLog(result);
                return context.Response.WriteAsync(result);

            }
        }





    }
    }

