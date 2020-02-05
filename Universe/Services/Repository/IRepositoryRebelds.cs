using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Universe.Models;

namespace Universe.Services.Repository
{
    public interface IRepositoryRebelds
    {
   
       IEnumerable<Rebelds> Lista { get; }
        void CreateStringCollection(StringCollection rebeldes);


    }
}
