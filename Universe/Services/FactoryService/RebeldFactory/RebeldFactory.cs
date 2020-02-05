using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal;
using Universe.Models;

namespace Universe.Services.FactoryService.Rebeldfactory
{
    public class RebeldFactory : IRebeldFactory
    {

        private Rebelds _rebelde;
        private readonly ISplitService _split;

        public RebeldFactory(ISplitService split)
        {
            _split = split;
        }

        public Rebelds CreateRebeld(StringCollection collection)
        {
            try
            {
                
                var cadena = _split.Convert(collection[0], ',');
                _rebelde = new Rebelds(cadena[0], cadena[1]);
            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto de rebelde", ex);
            }
            return _rebelde; 

        }




    }

}
