using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntegracjaOptima.Log
{
    class Logger
    {
        private static string Sciezka { get; set; }
        public static void WriteLog(string tresc)
        {
            using (StreamWriter sw = File.AppendText(Sciezka))
            {
                sw.WriteLine(tresc);
            }
        }

        public static void CreateLogFile()
        {
            var d = DateTime.Now;
            Sciezka = Directory.GetCurrentDirectory()+"\\log\\" + d.ToString("yyyy-MM-dd_HHmmss") + ".txt";
        }
    }
}
