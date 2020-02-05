using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universe.InfraestructureTransversal.ServicesException
{
    public class SplitException : Exception
    {
        public SplitException(string message) : base(message)
        {
        }
    }
}
