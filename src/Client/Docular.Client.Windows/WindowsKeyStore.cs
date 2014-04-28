using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;
using Docular.Client.View;

namespace Docular.Client
{
    /// <summary>
    /// Retreives the API key for an app instance.
    /// </summary>
    public class WindowsKeyStore : IKeyStore
    {
        /// <summary>
        /// Gets the API key.
        /// </summary>
        public String Key
        {
            get
            {
                return DocularSection.Default.ApiKey;
            }
            set
            {
                DocularSection section = DocularSection.Default;
                section.ApiKey = value;
                section.CurrentConfiguration.Save();
            }
        }

        /// <summary>
        /// Initializes a new <see cref="WindowsKeyStore"/>.
        /// </summary>
        public WindowsKeyStore() { }
    }
}
