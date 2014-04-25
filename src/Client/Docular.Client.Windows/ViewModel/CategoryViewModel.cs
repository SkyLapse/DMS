using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client;
using Docular.Client.Model;
using Docular.Client.Model.Rest;
using GalaSoft.MvvmLight.Ioc;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The <see cref="Category"/> view model.
    /// </summary>
    public class CategoryViewModel : CollectionViewModel<Category>
    {
        /// <summary>
        /// Initializes a new <see cref="DocumentViewModel"/>.
        /// </summary>
        [PreferredConstructor]
        public CategoryViewModel() : base(Resources.Strings.General.DocumentsCaption, (Path)System.Windows.Application.Current.Resources["BoxIcon"]) { }

        /// <summary>
        /// Initializes a new <see cref="CategoryViewModel"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> used to fetch data from the database.</param>
        public CategoryViewModel(IDocularClient client)
            : base(client, Resources.Strings.General.CategoriesCaption, (Path)System.Windows.Application.Current.Resources["FolderIcon"])
        {
            Contract.Requires<ArgumentNullException>(client != null);
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadData()
        {
            using (IsBusySwitcher section = this.StartBusySection())
            {
                this.Items = new ObservableCollection<Category>(await this.Client.GetCategoriesAsync());
            }
        }
    }
}
