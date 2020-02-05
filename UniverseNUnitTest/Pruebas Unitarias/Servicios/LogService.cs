using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Universe.Models;
using Universe.Services.LogService;

namespace UniverseNUnitTest.Pruebas_Unitarias.Servicios
{
    class LogService
    {
        public readonly string Contain;
        private readonly ILog _log = new DevelopmentLog();


      
        public LogService()
        {
            Contain = "Esto es una prueba!";
            _log.WriteLog(Contain);
        }

        [Test]
        public void LogWrite()
        {
            _log.WriteLog(Contain);
        }

    }
}
