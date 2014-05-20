using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using Docular.Client.Rest;

namespace Docular.Client.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ICache cache = new DocularCache();

            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write("Hello, this is a test!");
                sw.Flush();
                ms.Position = 0;
                cache.Add("TestFile", ms, "Test").Wait();
            }

            using (Stream s = cache.Get("TestFile", "Test").Result)
            using (StreamReader sr = new StreamReader(s))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

            Console.Read();
            Console.WriteLine("Finished!");
        }
    }
}
