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
        public async Task TestApiKeyReceivement()
        {
            IApiKeyManager apiKeyManager = new DocularClient("raspbmc.local:5002/api");

            String key = await apiKeyManager.GetKey("Test", "Test", "Test");
            Assert.IsNotNull(key, "The received key was null!");
        }

        [TestMethod]
        public async Task TestApiKeyValidation()
        {
            IApiKeyManager apiKeyManager = new DocularClient("raspbmc.local:5002/api");

            Assert.IsTrue(
                await apiKeyManager.ValidateKey(await apiKeyManager.GetKey("Test", "Test", "Test")),
                "There was some kind of error on the server side or the key, which was received immediately before, " +
                "is not valid anymore (because it was invalidated on the server or something, if this is the case everything is going well)."
            );
        }
    }
}
