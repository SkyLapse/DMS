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
    /// Logs data from collection view models.
    /// </summary>
    [EventSource(Name = "CollectionViewModel")]
    public class CollectionViewModelEventSource : ViewModelEventSource
    {
        /// <summary>
        /// Logs an exception in the <see cref="M:CollectionViewModel.LoadMore"/>-method.
        /// </summary>
        /// <param name="viewModelType">The <see cref="Type"/> of ViewModel the data was loaded into.</param>
        /// <param name="dataType">The <see cref="Type"/> of data to be loaded.</param>
        /// <param name="ex">The <see cref="Exception"/> that occured while loading the data.</param>
        [Event(101,
               Message = "Loading additional data (of type '{0}') into the ViewModel (of type '{1}') failed. (Exception Type: '{2}'; Source: '{3}'; Message: '{4}'; StackTrace: '{5}')",
               Level = EventLevel.Error,
               Opcode = EventOpcode.Receive)]
        public void OnLoadMoreException(Type viewModelType, Type dataType, Exception ex)
        {
            Contract.Requires<ArgumentNullException>(viewModelType != null);
            Contract.Requires<ArgumentNullException>(dataType != null);
            Contract.Requires<ArgumentNullException>(ex != null);

            this.WriteEvent(
                101,
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
