using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universe.InfraestructureTransversal
{
    public class FactoryException:Exception
    {
        public FactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
