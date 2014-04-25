using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The search view model.
    /// </summary>
    public class SearchViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new <see cref="SearchViewModel"/>.
        /// </summary>
        public SearchViewModel() : base(Resources.Strings.General.SearchCaption, (Path)System.Windows.Application.Current.Resources["SearchIcon"]) { }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override Task LoadData()
        {
            return Task.FromResult<object>(null);
        }
    }
}
