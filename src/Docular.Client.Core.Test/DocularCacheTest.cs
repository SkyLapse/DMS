using System;
using System.IO;
using System.Threading.Tasks;
using Docular.Client.Core;
using Docular.Client.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Docular.Client.Core.Test
{
    [TestClass]
    public class DocularCacheTest
    {
        public const String TestSentence = "Hello, this is a test.";

        [TestMethod]
        public async Task TestStoreAndRetreive()
        {
            ICache cache = new DocularCache();
            await this.WriteTestFile(cache, "TestStoreAndRetreive");

            using (Stream s = await cache.Get("TestStoreAndRetreive"))
            using (StreamReader sr = new StreamReader(s))
            {
                Assert.AreEqual(TestSentence, sr.ReadToEnd(), "The retreived text was not the same!");
            }
        }

        [TestMethod]
        public async Task TestInvalidation()
        {
            ICache cache = new DocularCache();
            await this.WriteTestFile(cache, "TestInvalidation");
            await cache.Invalidate();

            using (Stream s = await cache.Get("TestInvalidation"))
            {
                Assert.AreEqual(null, s, "The retreived Stream was not null (as it should've been after invalidation).");
            }
        }

        private async Task WriteTestFile(ICache cache, String fileName, String storeName = null)
        {
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(TestSentence);
                sw.Flush();
                ms.Position = 0;

                await cache.Add(fileName, ms, storeName);
            }
        }
    }
}
