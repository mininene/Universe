using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Universe.Controllers;
using Universe.Models;
using Universe.Services.Repository;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Universe.Services.LogService;
using Universe.Services;
using Universe.Services.ValidationService;
using Universe.Services.FactoryService;
using Universe.Services.FactoryService.Rebeldfactory;

namespace UniverseNUnitTest.Pruebas_Unitarias.Controller
{
    public class RebeldControllerTest
    {
        public  Mock<IRepositoryRebelds> _repositoryMock;
        public  RebeldsController _controller;
       private  StringCollection _invalidRebelCollection;
        private  StringCollection _validRebelCollection;
        private  IRepositoryRebelds _repository;
        private  DevelopmentLog _developmentLog;
#pragma warning disable CS0649 // Field 'RebeldControllerTest._log' is never assigned to, and will always have its default value null
        private  readonly ILog _log;
#pragma warning restore CS0649 // Field 'RebeldControllerTest._log' is never assigned to, and will always have its default value null

        [SetUp]

        public void Inicializar()
        {

           _developmentLog= new DevelopmentLog();
           _repository = new FakeRepositoryRebelds(_developmentLog);
            _invalidRebelCollection = new StringCollection  { "abc" };
            _validRebelCollection = new StringCollection {"Paco, Murcia"} ;
           _controller = new RebeldsController(_repository,_log);
        }

        [Test]
        
        public void ItReturnsCollectionOfSpeakers()
        {
             
            RebeldsController miControlador = new RebeldsController(_repository, _developmentLog);
            var lista = miControlador.Get(_repository);
            Assert.IsNotNull(lista);
            
        }

        [Test]
        public void ItHasPostMethod()
        {
           
            RebeldsController miControlador = new RebeldsController(_repository, _developmentLog);
            //var lista = miControlador.Post(_invalidRebelCollection);
            //Assert.IsNotNull(lista);
        }

    }
}

