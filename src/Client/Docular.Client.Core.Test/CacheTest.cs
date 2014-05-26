using System;
using System.IO;
using System.Threading.Tasks;
using Docular.Client.Core;
using Docular.Client.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Docular.Client.Core.Test
{
    [TestClass]
    public class CacheTest
    {
        public const String TestSentence = "Hello, this is a test.";

        [TestMethod]
        public async Task TestCacheStoreAndRetreive()
        {
            DocularCache cache = new DocularCache();
            await this.WriteTestFileToCache(cache, "TestStoreAndRetreive", "Default");

            using (Stream s = await cache.Get("TestStoreAndRetreive", "Default"))
            {
                Assert.IsNotNull(s, "The received file was null, meaning it was deleted while the test ran.");
                using (StreamReader sr = new StreamReader(s))
                {
                    Assert.AreEqual(TestSentence, sr.ReadToEnd(), "The retreived text was not the same!");
                }
            }
        }

        private Task WriteTestFileToCache(DocularCache cache, String fileName, String storeName)
        {
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(TestSentence);
                sw.Flush();
                ms.Position = 0;

                return cache.Add(fileName, ms, storeName);
            }
        }
    }
}
