using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Docular.Client.Windows.Views;

namespace Docular.Client.Windows
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
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                DocularSection section = (DocularSection)config.GetSection(DocularSection.SectionXmlKey);

                Contract.Assume(section != null);
                return section.ApiKey;
            }
            set
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                DocularSection section = (DocularSection)config.GetSection(DocularSection.SectionXmlKey);

                Contract.Assume(section != null);
                section.ApiKey = value;
                config.Save();
            }
        }

        /// <summary>
        /// Initializes a new <see cref="WindowsKeyStore"/>.
        /// </summary>
        public WindowsKeyStore() { }
    }
}
