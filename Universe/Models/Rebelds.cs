using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universe.Models
{
    public class Rebelds
    {

    
      public  string Name { get; set; }
      public  string Planet { get; set; }

        public Rebelds(string name, string planet)
        {

           Name = name;
           Planet = planet;
        }

    }
}
