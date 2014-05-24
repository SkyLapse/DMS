using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Events
{
    /// <summary>
    /// Logs data from the view models.
    /// </summary>
    [EventSource(Name = "ViewModel")]
    public class ViewModelEventSource : EventSource
    {
        /// <summary>
        /// Logs the initialization of a new ViewModel.
        /// </summary>
        /// <param name="viewModelType">The <see cref="Type"/> of the ViewModel that was initialzed.</param>
        /// <param name="vmName">The name of the ViewModel.</param>
        [Event(000,
               Message = "A new ViewModel of type '{0}' with name '{1}' was initialized.",
               Level = EventLevel.Informational,
               Opcode = EventOpcode.Info)]
        public void Initialized(Type viewModelType, String vmName)
        {
            Contract.Requires<ArgumentNullException>(viewModelType != null);

            this.WriteEvent(
                000,
                viewModelType.AssemblyQualifiedName,
                vmName
            );
        }

        /// <summary>
        /// Logs an exception in the <see cref="M:BaseViewModel.LoadData"/>-method.
        /// </summary>
        /// <param name="viewModelType">The <see cref="Type"/> of ViewModel the data was loaded into.</param>
        /// <param name="dataType">The <see cref="Type"/> of data to be loaded.</param>
        /// <param name="ex">The <see cref="Exception"/> that occured while loading the data.</param>
        [Event(100,
               Message = "Loading data (of type '{0}') into the ViewModel (of type '{1}') failed. (Exception Type: '{2}'; Source: '{3}'; Message: '{4}'; StackTrace: '{5}')",
               Level = EventLevel.Error, 
               Opcode = EventOpcode.Receive)]
        public void LoadDataException(Type viewModelType, Type dataType, Exception ex)
        {
            Contract.Requires<ArgumentNullException>(viewModelType != null);
            Contract.Requires<ArgumentNullException>(dataType != null);
            Contract.Requires<ArgumentNullException>(ex != null);

            this.WriteEvent(
                100,
                dataType.AssemblyQualifiedName,
                viewModelType.AssemblyQualifiedName,
                ex.GetType().AssemblyQualifiedName,
                ex.Source,
                ex.Message,
                ex.StackTrace
            );
        }
    }
}
