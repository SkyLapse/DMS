using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core;

namespace Docular.Client.Windows
{
    /// <summary>
    /// Contains configuration data for the docular windows client.
    /// </summary>
    public class DocularSection : ConfigurationSection
    {
        /// <summary>
        /// The key used to identify the default <see cref="DocularSection"/> instance in the configuration XML file.
        /// </summary>
        public const String SectionXmlKey = "ClientConfiguration";

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

                try
                {
                    return DPAPIDecryptToString(encryptedKeyString);
                }
                catch
                {
                    this.ApiKey = null;
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    this["ApiKey"] = DPAPIEncrypt(value);
                }
                else
                {
                    this["ApiKey"] = null;
                }
            }
        }

        /// <summary>
        /// The path to the docular remote DB.
        /// </summary>
        [StringValidator(MinLength = 12)]
        [ConfigurationProperty("DocularUri", DefaultValue = "http://example.com/", IsRequired = true)]
        public String DocularUri
        {
            get
            {
                return (String)this["DocularUri"] ?? "http://example.com/";
            }
            set
            {
                this["DocularUri"] = value;
            }
        }

        /// <summary>
        /// Gets the Uri to the docular REST API.
        /// </summary>
        public String DocularApiUri
        {
            get
            {
                String docularUri = this.DocularUri;
                return (docularUri != null) ? new Uri(docularUri).Combine("api/").ToString() : null;
            }
        }

        /// <summary>
        /// Gets the Uri to the docular REST API.
        /// </summary>
        public String DocularResetPasswordUri
        {
            get
            {
                String docularUri = this.DocularUri;
                return (docularUri != null) ? new Uri(docularUri).Combine("resetpassword/").ToString() : null;
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
