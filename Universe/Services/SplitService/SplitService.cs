using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal.ServicesException;
using Universe.Models;
using Universe.Services.FactoryService;

namespace Universe.Services.SplitService
{
    public class SplitService : ISplitService
    {
        public string[] Convert(string cadena, char caracter)
        {
            var arrayString = cadena.Split(caracter);

            if (arrayString.Length == 1 )
            {
                throw new SplitException("No se ha podido separar la cadena por '" + caracter + "'");
            }

            return arrayString;
        }
    }
}
