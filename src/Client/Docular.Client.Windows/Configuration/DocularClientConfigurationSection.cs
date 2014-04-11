using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Windows.Configuration
{
    /// <summary>
    /// Contains configuration data for the docular windows client.
    /// </summary>
    public class DocularClientConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// A "random" salt. ;-)
        /// </summary>
        private static byte[] entropy = Encoding.UTF8.GetBytes("This is my truly random salt!");

        /// <summary>
        /// The API key string. Will be encrypted upon save and decrypted upon access.
        /// </summary>
        [ConfigurationProperty("ApiKey", IsRequired = true)]
        public String ApiKey
        {
            get
            {
                byte[] encryptedKey = Convert.FromBase64String((String)this["ApiKey"]);
                byte[] decryptedKey = ProtectedData.Unprotect(encryptedKey, entropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decryptedKey);
            }
            set
            {
                byte[] apiKeyBytes = Encoding.UTF8.GetBytes(value);
                byte[] encryptedKey = ProtectedData.Protect(apiKeyBytes, entropy, DataProtectionScope.CurrentUser);
                this["ApiKey"] = Convert.ToBase64String(encryptedKey);
            }
        }

        /// <summary>
        /// Gets or sets the application skin to use on startup.
        /// </summary>
        [ConfigurationProperty("Skin", DefaultValue = "Default", IsRequired = true)]
        public String Skin
        {
            get
            {
                return (String)this["Skin"];
            }
            set
            {
                this["Skin"] = value;
            }
        }
    }
}
