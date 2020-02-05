using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal;
using Universe.Models;
using Universe.Services.FactoryService;
using Universe.Services.FactoryService.Rebeldfactory;
using Universe.Services.LogService;

namespace Universe.Services.Repository
{
    public class ApiRepositoryRebelds : IRepositoryRebelds
    {
        private readonly IRebeldListFactory _listFactory;
        private readonly IRebeldFactory _factory;
        private readonly ILog _log;
        private readonly DevelopmentLog _developmentLog;

        public ApiRepositoryRebelds(DevelopmentLog developmentLog)
        {
            this._developmentLog = developmentLog;
        }

        public ApiRepositoryRebelds(ILog log, IRebeldListFactory listFactory, IRebeldFactory factory)
        {
            _log = log;
            _listFactory = listFactory;
            _factory = factory;
        }
        public IEnumerable<Rebelds> Lista { get; set; }

        public void CreateStringCollection(StringCollection rebeldes)
        {
            var result = string.Empty;
            try
            {
                Rebelds obj = _factory.CreateRebeld(rebeldes);
                List<Rebelds> ExistingList = Lista.ToList();
                ExistingList.Add(obj);
                result = ExistingList.ToString();
                _log.WriteLog(result);
            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido listar todos los rebeldes", ex);
            }
        }

        public void Import()
        {
            using (var client = new HttpClient())
            {


                HttpResponseMessage response = client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
                string contenido = response.Content.ReadAsStringAsync().Result;
                {
                    // List<Cliente> lista;
                    Lista = JsonConvert.DeserializeObject<List<Rebelds>>(contenido);

                }
            }
        }

    }

}
