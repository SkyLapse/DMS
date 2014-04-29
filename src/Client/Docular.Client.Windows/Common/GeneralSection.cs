using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client
{
    /// <summary>
    /// Contains general configuration data.
    /// </summary>
    public class GeneralSection : ConfigurationSection
    {
        /// <summary>
        /// The key used to identify the default <see cref="GeneralSection"/> instance in the configuration XML file.
        /// </summary>
        public const String SectionXmlKey = "GeneralConfiguration";

        /// <summary>
        /// Gets the an instance of the <see cref="GeneralSection"/>.
        /// </summary>
        public static GeneralSection Default
        {
            get
            {
                Contract.Ensures(Contract.Result<GeneralSection>() != null);

                return App.GetConfigurationSection<GeneralSection>(SectionXmlKey);
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
        /// Initializes a new <see cref="GeneralSection"/>.
        /// </summary>
        public GeneralSection()
        {
            this.SectionInformation.AllowDefinition = ConfigurationAllowDefinition.Everywhere;
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToRoamingUser;
            this.SectionInformation.AllowOverride = true;
        }

        /// <summary>
        /// Indicates whether the <see cref="GeneralSection"/> is read-only.
        /// </summary>
        /// <returns><c>false</c>, the section is always writable.</returns>
        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
