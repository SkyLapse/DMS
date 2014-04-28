using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client
{
    /// <summary>
    /// Represents an <see cref="EventSource"/> logging events from the configuration system.
    /// </summary>
    [EventSource(Name = "Configuration")]
    public class ConfigurationEventSource : EventSource
    {
        /// <summary>
        /// Initializes a new <see cref="ConfigurationEventSource"/>.
        /// </summary>
        public ConfigurationEventSource() : base(false) { }

        /// <summary>
        /// Logs a configuration saving error.
        /// </summary>
        /// <param name="configuration">The <see cref="System.Configuration.Configuration"/> that should've been saved to disk.</param>
        [Event(1,
               Message = "Saving the configuration to '{0}' failed. (Exception Type: '{1}'; Source: '{2}'; Message: '{3}'; StackTrace: '{4}')", 
               Level = EventLevel.Critical)]
        public void ConfigurationSaveFailed(Configuration configuration, Exception ex)
        {
            this.WriteEvent(
                1, 
                configuration.FilePath, 
                ex.GetType().AssemblyQualifiedName, 
                ex.Message, 
                ex.StackTrace,
                ex.Source
            );
        }

        /// <summary>
        /// Logs the error when a decrypt of an API key failed.
        /// </summary>
        /// <param name="apiKey">The api key which should have been decrypted.</param>
        /// <param name="ex">The exception that occured.</param>
        [Event(2, 
               Message = "Decrypting an API key ({0}) failed, returning null. (Exception Type: '{1}'; Source: '{2}'; Message: '{3}'; StackTrace: '{4}')", 
               Level = EventLevel.Warning)]
        public void DecryptFailed(String apiKey, Exception ex)
        {
            this.WriteEvent(
                2,
                apiKey,
                ex.GetType().AssemblyQualifiedName,
                ex.Message,
                ex.StackTrace,
                ex.Source
            );
        }

        /// <summary>
        /// Logs when a <see cref="ConfigurationSection"/> was not found and had to be created.
        /// </summary>
        /// <param name="sectionAssemblyQualifiedName">The <see cref="Type.AssemblyQualifiedName"/> of the <see cref="ConfigurationSection"/>.</param>
        /// <param name="sectionKey">The key of the <see cref="ConfigurationSection"/> in the XML file.</param>
        [Event(3, 
               Message = "ConfigurationSection of Type '{0}' with key '{1}' not found, creating.",
               Level = EventLevel.Informational)]
        public void SectionNotFound(String sectionAssemblyQualifiedName, String sectionKey)
        {
            this.WriteEvent(3, sectionAssemblyQualifiedName, sectionKey);
        }
    }
}
