using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core;
using Docular.Client.Core.Model;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.ViewModel.Wpf
{
    /// <summary>
    /// The <see cref="Category"/> view model.
    /// </summary>
    public class CategoryModel : BaseModel
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private ObservableCollection<Category> _Categories;

        /// <summary>
        /// All loaded <see cref="Category"/>s.
        /// </summary>
        public ObservableCollection<Category> Categories
        {
            get
            {
                return _Categories;
            }
            set
            {
                if (value != _Categories)
                {
                    _Categories = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="CategoryModel"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> used to fetch data from the database.</param>
        public CategoryModel(IDocularClient client)
            : base(client, "Categories")
        {
            Contract.Requires<ArgumentNullException>(client != null);
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadData()
        {
            try
            {
                this.IsBusy = true;
                this.Categories = new ObservableCollection<Category>(await this.Client.GetCategoriesAsync());
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
