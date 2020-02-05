using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universe.Models;

namespace Universe.Services.LogService
{
    public interface ILog
    {
        void WriteLog(string message);
       
    }
}
