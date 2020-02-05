using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Universe.InfraestructureTransversal;
using Universe.Services;
using Universe.Services.FactoryService.Rebeldfactory;
using Universe.Services.SplitService;

namespace UniverseNUnitTest.Pruebas_Unitarias.Servicios
{
    class RebeldFactoryTest
    {
        private readonly IRebeldFactory _factory;
        private readonly ISplitService _split;
        private readonly StringCollection _stringCollection;
        private readonly StringCollection _stringCollectionEmpty;

        public RebeldFactoryTest()
        {
            _split = new SplitService();
            _factory = new RebeldFactory(_split);
            _stringCollection = new StringCollection();
            _stringCollectionEmpty = new StringCollection();

        }

        [Test]
        public void CreateObjectStringCollection()
        {
            _stringCollection.Add("Volibear,Marte");
            var rebelde = _factory.CreateRebeld(_stringCollection);

            Assert.IsNotNull(rebelde);
        }

        [Test]
        public void CreateObjectStringCollectionNull()
        {
            Assert.Throws<FactoryException>(() => _factory.CreateRebeld(_stringCollectionEmpty));
        }

       
    }
}

