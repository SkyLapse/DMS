﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Docular.Client.Windows.UI;

namespace Docular.Client.Windows
{
    /// <summary>
    /// Retreives the API key for an app instance.
    /// </summary>
    public class WindowsKeyStore : IKeyStore
    {
        /// <summary>
        /// Initializes a new <see cref="WindowsKeyStore"/>.
        /// </summary>
        public WindowsKeyStore() { }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <returns>The API key.</returns>
        public String GetKey()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            DocularSection section = (DocularSection)config.GetSection(DocularSection.SectionXmlKey);

            Contract.Assume(section != null);
            return section.ApiKey;
        }
    }
}
