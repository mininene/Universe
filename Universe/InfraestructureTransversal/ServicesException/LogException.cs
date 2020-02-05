using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universe.InfraestructureTransversal.ServicesException
{
    public class LogException : Exception
    {
        public LogException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
