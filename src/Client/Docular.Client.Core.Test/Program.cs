using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;
using Docular.Client.Core.Model.Rest;
using RestSharp.Portable;

namespace Docular.Client.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocularClient client = new DocularClient(new Uri("http://62.143.158.178:5002/api/"), new TestKeyStore(), new TestContentReceiver());

            //Document testDocument = new Document(
            //    client,
            //    new ChangeInfo(new User(), DateTime.Now),
            //    new ChangeInfo(),
            //    "image/jpeg",
            //    new Category(),
            //    new Buzzword[] { },
            //    "Test ABC 123",
            //    new Uri("https://example.com/api/download/Test.jpg"),
            //    new Uri("https://example.com/api/download/Test-Thumbnail.jpg"),
            //    1000,
            //    new Tag[] { new Tag() { Name = "Tag1", Description = "Description of Tag1" } }
            //);

            //RestRequest testRequest = new RestRequest("documents", HttpMethod.Post);
            //testRequest.AddBody(testDocument);

            //String requestBody = testRequest.GetContent().ReadAsStringAsync().Result;
            //Console.WriteLine(requestBody);
            //System.IO.File.WriteAllText(
            //    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Request.json"),
            //    requestBody
            //);

            //Document response = client.GetDocumentAsync("53402d959f2225e0d5a33882").Result;

            //new Newtonsoft.Json.JsonSerializer().Serialize(Console.Out, response);

            using (MemoryStream ms = new MemoryStream(new RestClient("http://62.143.158.178:5002/api/").Execute(new RestRequest("documents/53402d959f2225e0d5a33882", HttpMethod.Get)).Result.RawBytes))
            using (StreamReader sr = new StreamReader(ms))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

            Document document = client.GetDocumentAsync("53402d959f2225e0d5a33882").Result;

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

        class TestKeyStore : IKeyStore
        {
            public string GetKey()
            {
                return "ABCDEFHIJKLMNOPQRSTUVWXYZ";
            }
        }

        class TestContentReceiver : IContentReceiver
        {
            public System.IO.Stream GetLocalContent(Document document)
            {
                return System.IO.File.Open("E:\\Users\\Moritz\\Downloads\\Test.jpg", System.IO.FileMode.OpenOrCreate);
            }

            public string GetFileName(Document document)
            {
                return "E:\\Users\\Moritz\\Downloads\\Test.jpg";
            }
        }
    }
}
