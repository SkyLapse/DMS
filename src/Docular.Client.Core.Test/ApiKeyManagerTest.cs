using System;
using System.Threading.Tasks;
using Docular.Client.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Docular.Client.Core.Test
{
    [TestClass]
    public class ApiKeyManagerTest
    {
        [TestMethod]
        public async Task TestReceiveKey()
        {
            IApiKeyManager apiKeyManager = new DocularClient("raspbmc.local:5002/api");

            String key = await apiKeyManager.GetKey("Test", "Test", "Test");
            Assert.IsNotNull(key);
        }
    }
}
