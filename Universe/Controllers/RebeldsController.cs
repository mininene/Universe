using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Universe.InfraestructureTransversal.ControllerException;
using Universe.Models;
using Universe.Services;
using Universe.Services.FactoryService;
using Universe.Services.FactoryService.Rebeldfactory;
using Universe.Services.LogService;
using Universe.Services.Repository;
using Universe.Services.ValidationService;

namespace Universe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RebeldsController : ControllerBase
    {
        private readonly IRepositoryRebelds _repository;
        private readonly ILog _log;
        private readonly ISplitService _splitservice;
        private readonly IValidationRegisterSpecification _validation;
        private readonly IRebeldListFactory _listFactory;
        private readonly IRebeldFactory _factory;


        public RebeldsController(IRepositoryRebelds repository, ILog log, ISplitService splitservice, IValidationRegisterSpecification validation, IRebeldListFactory listFactory, IRebeldFactory factory)
        {
            _repository = repository;
            _log = log;
            _splitservice = splitservice;
            _validation = validation;
            _listFactory = listFactory;
            _factory = factory;
        }

        public RebeldsController(IRepositoryRebelds repository, ILog log)
        {
            _repository = repository;
            _log = log;

        }


        [HttpGet]
        public IActionResult Get(IRepositoryRebelds _repository)
        {
            try
            {
                string result = String.Empty;
                IEnumerable<Rebelds> listRebelds = _repository.Lista;


                foreach (var obj in listRebelds)
                {
                    result = result + $"Nombre {obj.Name} on Planet {obj.Name}" + Environment.NewLine;

                }
                _log.WriteLog("Datos leidos correctamente");
                return Ok(result);
            }
            catch (ControllerException)
            {
                _log.WriteLog("Error al leer los datos");
                throw new ControllerException("Error inesperado");
            }

        }

        public object Get(Mock<IRepositoryRebelds> repositoryMock)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/api/rebelde/post")]
        public IActionResult Post(StringCollection rebeldes)
        {

            try
            {
                _repository.CreateStringCollection(rebeldes);
                _log.WriteLog("Datos grabados correctamente");
                return Ok(true);
            }
            catch (ControllerException)
            {
                _log.WriteLog("Error al grabar los datos");
                return BadRequest("Error inesperado");
                throw new ControllerException("Error inesperado");
            }

        }

       






















    }
}