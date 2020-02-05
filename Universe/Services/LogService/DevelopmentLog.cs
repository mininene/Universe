using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Universe.InfraestructureTransversal.ServicesException;
using Universe.Models;

namespace Universe.Services.LogService
{
    public class DevelopmentLog : ILog
    {


        //private readonly string _filePath =
        //    AppDomain.CurrentDomain.BaseDirectory + $"Rebels{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.json";


        public void WriteLog(string menssage)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Rebeldes Correctos.txt");
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(
                            $"EL rebelde se ha añadido al repisitorio en {DateTime.Now.ToString()}");
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(
                        $"EL rebelde se ha añadido al repisitorio en {DateTime.Now.ToString()}");

                }
            }


            //{


            //    try
            //    {
            //        using (var sw = new StreamWriter(_filePath))
            //        {
            //            var jsonStr = JsonConvert.SerializeObject(menssage, Formatting.Indented);

            //            sw.Write(jsonStr);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new LogException("No se ha podido escribir en el archivo", ex);
            //    }

            //}
        }
    }

}
//private readonly string Path = Directory.GetCurrentDirectory();
//if (!Directory.Exists(Path))
//Directory.CreateDirectory(Path);

//string nombre = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";
//string cadena = "";

//cadena += DateTime.Now + " - " + Log + Environment.NewLine;

//StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
//sw.Write(cadena);
//sw.Close();

//ILog oLog = new DevelopmentLog();
//oLog.WriteLog("Hola mundo");