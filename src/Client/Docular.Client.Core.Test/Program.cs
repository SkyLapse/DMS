using System;
using System.Collections.Generic;
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
            DocularClient client = new DocularClient(new Uri("https://example.com/api"), new TestKeyStore(), new TestContentReceiver());
            Document testDocument = new Document(
                client,
                new ChangeInfo(new User(), DateTime.Now),
                new ChangeInfo(),
                "image/jpeg",
                new Category(),
                new Buzzword[] { },
                "Test ABC 123",
                new Uri("https://example.com/api/download/Test.jpg"),
                new Uri("https://example.com/api/download/Test-Thumbnail.jpg"),
                1000,
                new Tag[] { new Tag() { Name = "Tag1", Description = "Description of Tag1" } }
            );

            RestRequest testRequest = new RestRequest("https://example.com/api/documents", HttpMethod.Post);
            testRequest.AddBody(testDocument);

            String requestBody = testRequest.GetContent().ReadAsStringAsync().Result;
            Console.WriteLine(requestBody);
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Request.json"),
                requestBody
            );

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
