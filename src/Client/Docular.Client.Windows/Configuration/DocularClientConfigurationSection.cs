using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
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
        private static byte[] entropy = Encoding.UTF8.GetBytes("I should really invent a better salting mechanism!");

        /// <summary>
        /// The API key string. Will be encrypted upon save and decrypted upon access.
        /// </summary>
        [ConfigurationProperty("ApiKey", IsRequired = true)]
        public String ApiKey
        {
            get
            {
                String encryptedKeyString = (String)this["ApiKey"];
                if (encryptedKeyString == null)
                {
                    return null;
                }

                byte[] encryptedKey = Convert.FromBase64String(encryptedKeyString);
                byte[] decryptedKey = ProtectedData.Unprotect(encryptedKey, entropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decryptedKey);
            }
            set
            {
                if (value != null)
                {
                    byte[] apiKeyBytes = Encoding.UTF8.GetBytes(value);
                    byte[] encryptedKey = ProtectedData.Protect(apiKeyBytes, entropy, DataProtectionScope.CurrentUser);
                    this["ApiKey"] = Convert.ToBase64String(encryptedKey);
                }
                else
                {
                    this["ApiKey"] = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the application skin to use on startup.
        /// </summary>
        [StringValidator(MinLength = 1)]
        [ConfigurationProperty("Skin", DefaultValue = "Default", IsRequired = true)]
        public String Skin
        {
            get
            {
                return (String)this["Skin"] ?? "Default";
            }
            set
            {
                this["Skin"] = value ?? "Default";
            }
        }

        /// <summary>
        /// Initializes a new <see cref="DocularClientConfigurationSection"/>.
        /// </summary>
        public DocularClientConfigurationSection()
        {
            this.SectionInformation.AllowDefinition = ConfigurationAllowDefinition.Everywhere;
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
            this.SectionInformation.AllowOverride = true;
        }
    }
}
