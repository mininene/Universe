using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal.ServicesException;
using Universe.Models;

namespace Universe.Services.LogService
{
    public class ProductionLog : ILog
    {
        private readonly string _filePath = AppDomain.CurrentDomain.BaseDirectory + $"Rebels{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.json";
       
        public void WriteLog(string message)
        {
            try
            {
                using (var sr = new StreamReader(_filePath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new LogException("No se ha podido escribir en la consola", ex);
            }
        }
}
}







//private readonly string Path = Directory.GetCurrentDirectory();

//public void WriteLog(string Log)
//{

//    string nombre = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";
//    string cadena = "";

//    cadena += DateTime.Now + " - " + Log + Environment.NewLine;

//    using (StreamReader sr = new StreamReader(nombre))
//    {
//        while ((cadena = sr.ReadLine()) != null)
//        {
//            Console.WriteLine(cadena);
//        }
//    }

//}