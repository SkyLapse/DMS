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
using ServiceStack;

namespace Docular.Client.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DocularClient client = new DocularClient("http://62.143.158.178:5002/api/");

            Document doc = new Document()
            {
                Category = new Category("Hello, this is a test category!"),
                CreateInfo = new ChangeInfo(new User() { Name = "TestUser" }, DateTime.Now),
                CustomFields = new[] { new CustomField("TestKey1", "TestValue"), new CustomField("TestKey2", "TestValue2") },
                Description = "This document is used as test.",
                ExtractedContent = "Hello, this is a test",
                Name = "Test Document",
                Mime = "image/jpg",
                Size = 1010213
            };

            File.WriteAllText("E:\\Users\\Moritz\\Downloads\\Document.json", doc.ToJson());

            //client.AddDocumentAsync(doc).Wait();

            Document[] docs = client.GetDocumentsAsync(DocumentCollectionRequest.Default).Result;

            Console.WriteLine("Finished!");
        }
    }
}
