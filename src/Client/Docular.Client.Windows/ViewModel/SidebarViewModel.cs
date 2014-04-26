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
            this.Items.Add(new StartViewModel());
            this.Items.Add(new SearchViewModel());
            this.Items.Add(new DocumentViewModel());
            this.Items.Add(new CategoryViewModel());
            this.Items.Add(new TagViewModel());
            this.Items.Add(new SettingsViewModel());
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
