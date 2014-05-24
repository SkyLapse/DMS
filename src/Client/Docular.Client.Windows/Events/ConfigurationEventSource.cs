using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Events
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
        /// Logs the successfull loading of a configuration file.
        /// </summary>
        /// <param name="configFile">The config file that was loaded.</param>
        [Event(000,
               Message = "Loaded a config file from path '{0}'.",
               Level = EventLevel.Informational,
               Opcode = EventOpcode.Info)]
        public void ConfigurationLoaded(String configFile)
        {
            this.WriteEvent(000, configFile);
        }

        /// <summary>
        /// Logs the retreival of a specific value from the configuration.
        /// </summary>
        /// <param name="entryName">The key of the setting value that was retreived.</param>
        /// <param name="value">The value that was retreived.</param>
        [Event(001, 
               Message = "The value '{0}' was retreived from the configuration. It's value was '{1}'.",
               Level = EventLevel.Verbose,
               Opcode = EventOpcode.Receive)]
        public void ValueRetreived(String entryName, object value)
        {
            this.WriteEvent(001, entryName, value);
        }

        /// <summary>
        /// Logs when a config entry in the configuration was written.
        /// </summary>
        /// <param name="entryName">The name of the entry.</param>
        /// <param name="value">The new value.</param>
        [Event(002,
               Message = "The value '{0}' was set to '{1}'.",
               Level = EventLevel.Verbose,
               Opcode = EventOpcode.Receive)]
        public void ValueSet(String entryName, object value)
        {
            this.WriteEvent(002, entryName, value);
        }

        /// <summary>
        /// Logs a configuration saving error.
        /// </summary>
        /// <param name="configuration">The <see cref="DocularConfiguration"/> that should've been saved to disk.</param>
        /// <param name="ex">The <see cref="Exception"/> that occured while saving the <see cref="DocularConfiguration"/>.</param>
        [Event(100,
               Message = "Saving the configuration to '{0}' failed. (Exception Type: '{1}'; Source: '{2}'; Message: '{3}'; StackTrace: '{4}')", 
               Level = EventLevel.Error)]
        public void ConfigurationSaveFailed(Configuration configuration, Exception ex)
        {
            Contract.Requires<ArgumentNullException>(ex != null);
            Contract.Requires<ArgumentNullException>(configuration != null);

            this.WriteEvent(
                100, 
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
        [Event(101, 
               Message = "Decrypting an API key ({0}) failed, returning null. (Exception Type: '{1}'; Source: '{2}'; Message: '{3}'; StackTrace: '{4}')", 
               Level = EventLevel.Warning)]
        public void DecryptFailed(String apiKey, Exception ex)
        {
            Contract.Requires<ArgumentNullException>(ex != null);

            this.WriteEvent(
                101,
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
        [Event(102, 
               Message = "ConfigurationSection of Type '{0}' with key '{1}' not found, creating.",
               Level = EventLevel.Warning)]
        public void SectionNotFound(String sectionAssemblyQualifiedName, String sectionKey)
        {
            this.WriteEvent(102, sectionAssemblyQualifiedName, sectionKey);
        }
    }
}
