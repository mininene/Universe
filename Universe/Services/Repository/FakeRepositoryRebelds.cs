using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal;
using Universe.Models;
using Universe.Services.FactoryService;
using Universe.Services.FactoryService.Rebeldfactory;
using Universe.Services.LogService;

namespace Universe.Services.Repository
{
    public class FakeRepositoryRebelds : IRepositoryRebelds
    {

        private readonly IRebeldListFactory _listFactory;
        private readonly IRebeldFactory _factory;
        private readonly ILog _log;
        private readonly DevelopmentLog _developmentLog;

        public FakeRepositoryRebelds(DevelopmentLog developmentLog)
        {
            this._developmentLog = developmentLog;
        }

        public FakeRepositoryRebelds( ILog log, IRebeldListFactory listFactory, IRebeldFactory factory)
        {
            _log = log;
            _listFactory = listFactory;
            _factory = factory;
        }



        public IEnumerable<Rebelds> Lista { get; } = new List<Rebelds>()
        {
            new Rebelds("Darius","Saturno"),
            new Rebelds("Alexa","Urano"),
            new Rebelds("Sona","Pluton")


            //new Rebelds{Name="Darius", Planet="Saturno"},
            //new Rebelds{Name="Alexa", Planet="Urano"},

        };

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
    }
}

