using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client
{
    /// <summary>
    /// Contains configuration data for the docular windows client.
    /// </summary>
    public class DocularSection : ConfigurationSection
    {
        /// <summary>
        /// Used for locking.
        /// </summary>
        private static object defaultAccessorLock = new object();

        /// <summary>
        /// The <see cref="ConfigurationEventSource"/> used for logging.
        /// </summary>
        private static readonly ConfigurationEventSource staticEventSource = new ConfigurationEventSource();
        
        /// <summary>
        /// The key used to identify the default <see cref="DocularSection"/> instance in the configuration XML file.
        /// </summary>
        public const String SectionXmlKey = "ClientConfiguration";

        /// <summary>
        /// Gets the an instance of the <see cref="DocularSection"/>.
        /// </summary>
        public static DocularSection Default
        {
            get
            {
                Contract.Ensures(Contract.Result<DocularSection>() != null);

                lock (defaultAccessorLock)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
                    DocularSection section = config.GetSection(SectionXmlKey) as DocularSection;
                    if (section == null)
                    {
                        staticEventSource.SectionNotFound(typeof(DocularSection).AssemblyQualifiedName, SectionXmlKey);

                        section = new DocularSection();
                        config.Sections.Add(SectionXmlKey, section);
                        config.Save(ConfigurationSaveMode.Full);
                        return section;
                    }
                    else
                    {
                        return section;
                    }
                }
            }
        }

        /// <summary>
        /// A "random" salt. ;-)
        /// </summary>
        private static byte[] entropy = Encoding.UTF8.GetBytes("I should really invent a better salting mechanism!");

        /// <summary>
        /// The <see cref="ConfigurationEventSource"/> used for logging.
        /// </summary>
        private readonly ConfigurationEventSource eventSource = new ConfigurationEventSource();

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

                try
                {
                    return DPAPIDecryptToString(encryptedKeyString);
                }
                catch (Exception ex)
                {
                    this.eventSource.DecryptFailed(encryptedKeyString, ex);
                    return null;
                }
            }
            set
            {
                this["ApiKey"] = (value != null) ? DPAPIEncrypt(value) : null;
            }
        }

        /// <summary>
        /// The path to the docular remote DB.
        /// </summary>
        [StringValidator(MinLength = 12)]
        [ConfigurationProperty("DocularUri", DefaultValue = "http://example.com/api/", IsRequired = true)]
        public String DocularApiUri
        {
            get
            {
                return (String)this["DocularUri"] ?? "http://example.com/api/";
            }
            set
            {
                this["DocularUri"] = value ?? "http://example.com/api/";
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
        /// Initializes a new <see cref="DocularSection"/>.
        /// </summary>
        public DocularSection()
        {
            this.SectionInformation.AllowDefinition = ConfigurationAllowDefinition.Everywhere;
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToRoamingUser;
            this.SectionInformation.AllowOverride = true;
        }

        /// <summary>
        /// Indicates whether the <see cref="DocularSection"/> is read-only.
        /// </summary>
        /// <returns><c>false</c>, the section is always writable.</returns>
        public override bool IsReadOnly()
        {
            return false;
        }

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
    }
}
