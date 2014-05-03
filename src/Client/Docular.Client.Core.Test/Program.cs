using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using Docular.Client.Rest;
using ServiceStack;

namespace Docular.Client.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DocularClient client = new DocularClient("http://62.143.158.178/api/");
            JsonServiceClient serviceClient = new JsonServiceClient("http://62.143.158.178/api/");

            using (FileStream fs = File.Create("E:\\Users\\Moritz\\Downloads\\Reponse.json", 8192))
            {
                Document[] documents = serviceClient.Get(DocumentCollectionRequest.Default);
                Console.WriteLine(documents.ToJson());
            }

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}
