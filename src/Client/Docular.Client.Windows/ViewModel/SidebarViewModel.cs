using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Docular.Client.Model;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The sidebar view model.
    /// </summary>
    public class SidebarViewModel : CollectionViewModel<BaseViewModel>
    {
        /// <summary>
        /// Initializes a new <see cref="SidebarViewModel"/>.
        /// </summary>
        public SidebarViewModel()
            : base(Resources.Strings.General.SidebarCaption)
        {
            ViewModelLocator locator = ViewModelLocator.Default;
            this.Items.Add(locator.StartViewModel);
            this.Items.Add(locator.SearchViewModel);
            this.Items.Add(locator.DocumentViewModel);
            this.Items.Add(locator.CategoryViewModel);
            this.Items.Add(locator.TagViewModel);
            this.Items.Add(locator.SettingsViewModel);
        }

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
