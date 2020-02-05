using Castle.Core.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Universe.Models;


namespace UniverseNUnitTest.Pruebas_Unitarias.Model
{

    public class ModelTest
    {

        [Test]
        public void RebeldeCorrecto()
        {
            Rebelds rebelde = new Rebelds("Maria", "Mercurio");
            Assert.IsNotNull(rebelde);
            Assert.IsTrue(!string.IsNullOrEmpty(rebelde.Name));
        }


        [Test]
        public void RebeldeIncorrectoPrimerVacio()
        {
            Rebelds rebelde = new Rebelds("", "Saturno");

            Assert.IsNotNull(rebelde);
            Assert.IsTrue(string.IsNullOrEmpty(rebelde.Name));
        }

        [Test]
        public void RebeldeIncorrectoSegundoVacio()
        {
            Rebelds rebelde = new Rebelds("Maria", "");

            Assert.IsNotNull(rebelde);
            Assert.IsTrue(string.IsNullOrEmpty(rebelde.Planet));
        }

    }

}
