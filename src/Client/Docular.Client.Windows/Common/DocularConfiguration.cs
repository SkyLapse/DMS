using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Events;

namespace Docular.Client
{
    /// <summary>
    /// Contains general configuration data.
    /// </summary>
    public class DocularConfiguration : ConfigurationSection
    {
        /// <summary>
        /// A machine-specific salt.
        /// </summary>
        private static readonly byte[] entropy = Encoding.UTF8.GetBytes(Environment.MachineName);

        /// <summary>
        /// The <see cref="ConfigurationEventSource"/> used for logging.
        /// </summary>
        private static readonly ConfigurationEventSource eventSource = new ConfigurationEventSource();

        /// <summary>
        /// The key used to identify the default <see cref="DocularConfiguration"/> instance in the configuration XML file.
        /// </summary>
        public const String SectionXmlKey = "DocularWindows";

        /// <summary>
        /// Gets the an instance of the <see cref="DocularConfiguration"/>.
        /// </summary>
        public static DocularConfiguration Default
        {
            get
            {
                Contract.Ensures(Contract.Result<DocularConfiguration>() != null);

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
                DocularConfiguration section = (DocularConfiguration)config.GetSection(SectionXmlKey);

                if (section == null)
                {
                    section = new DocularConfiguration();
                    config.Sections.Add(SectionXmlKey, section);
                }

                eventSource.ConfigurationLoaded(section.CurrentConfiguration.FilePath);
                return section;
            }
        }

        /// <summary>
        /// The API key string. Will be encrypted upon save and decrypted upon access.
        /// </summary>
        [ConfigurationProperty("ApiKey", IsRequired = true)]
        public String ApiKey
        {
            get
            {
                String apiKey = this.GetValue<String>("ApiKey");
                return (apiKey != null) ? DPAPIDecryptToString(apiKey) : null;
            }
            set
            {
                this.SetValue("ApiKey", (value != null) ? DPAPIEncrypt(value) : null);
            }
        }

        /// <summary>
        /// The path to the docular remote DB.
        /// </summary>
        [StringValidator(MinLength = 12)]
        [ConfigurationProperty("DocularApiUri", IsRequired = true)]
        public String DocularApiUri
        {
            get
            {
                return this.GetValue<String>("DocularApiUri");
            }
            set
            {
                this.SetValue("DocularApiUri", value);
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
                return this.GetValue<String>("Skin") ?? "Default";
            }
            set
            {
                this.SetValue("Skin", value ?? "Default");
            }
        }

        /// <summary>
        /// Initializes a new <see cref="DocularConfiguration"/>.
        /// </summary>
        public DocularConfiguration()
        {
            this.SectionInformation.AllowDefinition = ConfigurationAllowDefinition.Everywhere;
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToRoamingUser;
            this.SectionInformation.AllowOverride = true;
        }

        /// <summary>
        /// Indicates whether the <see cref="DocularConfiguration"/> is read-only.
        /// </summary>
        /// <returns><c>false</c>, the section is always writable.</returns>
        public override bool IsReadOnly()
        {
            return false;
        }

        /// <summary>
        /// Retreives a value from the configuration file.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value to retreive.</typeparam>
        /// <param name="key">The key of the value.</param>
        /// <returns>The value inside the configuration file.</returns>
        private T GetValue<T>(String key)
        {
            T value = (T)(this[key] ?? default(T));
            eventSource.ValueRetreived(key, value);
            return value;
        }

        /// <summary>
        /// Sets a value in the configuration file.
        /// </summary>
        /// <param name="key">The key of the value.</param>
        /// <param name="value">The new value.</param>
        private void SetValue(String key, object value)
        {
            this[key] = value;
            eventSource.ValueSet(key, value);
        }

        #region DPAPI

        /// <summary>
        /// Decrypts the specified base-64 encoded DPAPI protected string into its original form.
        /// </summary>
        /// <param name="data">The data to decrypt.</param>
        /// <returns>The decrypted data.</returns>
        private static byte[] DPAPIDecrypt(String data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            return DPAPIDecrypt(Convert.FromBase64String(data));
        }

        /// <summary>
        /// Decrypts the specified base-64 encoded DPAPI protected string into its original form.
        /// </summary>
        /// <param name="data">The data to decrypt.</param>
        /// <returns>The decrypted data.</returns>
        private static byte[] DPAPIDecrypt(byte[] data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            return ProtectedData.Unprotect(data, entropy, DataProtectionScope.CurrentUser);
        }

        /// <summary>
        /// Decrypts the specified base-64 encoded DPAPI protected string into its original form.
        /// </summary>
        /// <param name="data">The data to decrypt.</param>
        /// <returns>The decrypted data "deserialized" as <see cref="String"/>.</returns>
        private static String DPAPIDecryptToString(String data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            return DPAPIDecryptToString(Convert.FromBase64String(data));
        }

        /// <summary>
        /// Decrypts the specified base-64 encoded DPAPI protected string into its original form.
        /// </summary>
        /// <param name="data">The data to decrypt.</param>
        /// <returns>The decrypted data "deserialized" as <see cref="String"/>.</returns>
        private static String DPAPIDecryptToString(byte[] data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            return Encoding.UTF8.GetString(DPAPIDecrypt(data));
        }

        /// <summary>
        /// Encrypts the specified <see cref="String"/> with the DPAPI and encodes the resulting bytes with base-64.
        /// </summary>
        /// <param name="data">The data to encrypt.</param>
        /// <returns>The encrypted data.</returns>
        private static String DPAPIEncrypt(String data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            return DPAPIEncrypt(Encoding.UTF8.GetBytes(data));
        }

        /// <summary>
        /// Encrypts the specified array of bytes with the DPAPI and encodes the resulting bytes with base-64.
        /// </summary>
        /// <param name="data">The data to encrypt.</param>
        /// <returns>The encrypted data.</returns>
        private static String DPAPIEncrypt(byte[] data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            byte[] encryptedKey = ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedKey);
        }

        #endregion
    }
}
