using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal;
using Universe.Models;

namespace Universe.Services.FactoryService
{
    public class RebeldListFactory : IRebeldListFactory
    {

#pragma warning disable CS0649 // Field 'RebeldListFactory._listRebelds' is never assigned to, and will always have its default value null
        private IEnumerable<Rebelds> _listRebelds;
#pragma warning restore CS0649 // Field 'RebeldListFactory._listRebelds' is never assigned to, and will always have its default value null
        private readonly ISplitService _split;
        private Rebelds _rebeld { get; set; }


        public RebeldListFactory(ISplitService split)
        {
            _split = split;
        }

        public IEnumerable<Rebelds> CreateListRebelds(StringCollection collection)
        {

            try
            {
                foreach (var item in collection)
                {
                    string[] cadena = _split.Convert(item, ',');
                    _listRebelds.Append(_rebeld = new Rebelds(cadena[0], cadena[1]));
                }
            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear la lista de rebeldes", ex);
            }

            return _listRebelds;
        }

        
    }
}
