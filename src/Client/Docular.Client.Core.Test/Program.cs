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
            DocularClient client = new DocularClient("http://raspbmc.local:5002/api/");

            Document doc = new Document()
            {
                Category = new Category() 
                { 
                    Name = "Hello, this is a test category!",
                    Description = "This is the description of the test category.",
                    CustomFields = new[] 
                    { 
                        new CustomField("CustomFieldKey1", "This is the value of the first custom field."),
                        new CustomField("CustomFieldKey2", "This is the value of the second custom field.")
                    }
                },
                CreateInfo = new ChangeInfo(new User() { Name = "TestUser" }, DateTime.Now),
                CustomFields = new[] { new CustomField("TestKey1", "TestValue1"), new CustomField("TestKey2", "TestValue2") },
                Description = "This document is used as test.",
                ExtractedContent = "Hello, this is a test",
                Name = "Test Document",
                Mime = "image/jpg",
                Size = 1010213,
                Tags = new[] { new Tag() { Name = "Tag1", Description = "This is the description of the one and only tag the document is tagged with." } }
            };

            File.WriteAllText("E:\\Users\\Moritz\\Downloads\\Document.json", doc.ToJson());

            //client.AddDocumentAsync(doc).Wait();

            //Document[] docs = client.GetDocumentsAsync(DocumentCollectionRequest.Default).Result;

            Console.WriteLine("Finished!");
        }
    }
}
