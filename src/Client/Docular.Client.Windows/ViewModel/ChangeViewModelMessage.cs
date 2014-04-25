using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// A message instructing the main view model to change the content view model to the specified one.
    /// </summary>
    public struct ChangeViewModelMessage
    {
        /// <summary>
        /// The new view model to display.
        /// </summary>
        public BaseViewModel NewViewModel { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="ChangeViewModelMessage"/>.
        /// </summary>
        /// <param name="newViewModel">The new view model to display.</param>
        public ChangeViewModelMessage(BaseViewModel newViewModel)
            : this()
        {
            Contract.Requires<ArgumentNullException>(newViewModel != null);

            this.NewViewModel = newViewModel;
        }
    }
}
