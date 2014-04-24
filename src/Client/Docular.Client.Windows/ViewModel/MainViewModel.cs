using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The main model containing the model currently being displayed.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private BaseViewModel _DisplayModel;

        /// <summary>
        /// The model to display in the UI.
        /// </summary>
        public BaseViewModel DisplayModel
        {
            get
            {
                return _DisplayModel;
            }
            set
            {
                if (value != _DisplayModel)
                {
                    _DisplayModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadData()
        {
            using (IsBusySwitcher section = new IsBusySwitcher(this))
            {
                MainPageModel mainPage = new MainPageModel();
                await mainPage.LoadData();
                this.DisplayModel = mainPage;
            }
        }

        protected override void OnLoadDataCommandException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
