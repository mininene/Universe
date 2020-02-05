using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Universe.Models;

namespace Universe.Services.FactoryService
{
    public interface IRebeldListFactory
    {
        IEnumerable<Rebelds> CreateListRebelds(StringCollection collection);
    }
}
