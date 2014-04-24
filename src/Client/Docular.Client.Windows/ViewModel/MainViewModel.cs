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
        private BaseViewModel _DisplayViewModel;

        /// <summary>
        /// The model to display in the UI.
        /// </summary>
        public BaseViewModel DisplayViewModel
        {
            get
            {
                return _DisplayViewModel;
            }
            set
            {
                if (value != _DisplayViewModel)
                {
                    _DisplayViewModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private BaseViewModel _NavigationViewModel;

        /// <summary>
        /// The <see cref="BaseViewModel"/> used for window navigation.
        /// </summary>
        public BaseViewModel NavigationViewModel
        {
            get
            {
                return _NavigationViewModel;
            }
            set
            {
                if (value != _NavigationViewModel)
                {
                    _NavigationViewModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="MainViewModel"/>.
        /// </summary>
        public MainViewModel() { }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadData()
        {
            using (IsBusySwitcher section = new IsBusySwitcher(this))
            {
                BaseViewModel displayModel = new MainPageModel();
                BaseViewModel navigationModel = new SidebarViewModel();
                await Task.WhenAll(displayModel.LoadData(), navigationModel.LoadData());
                this.DisplayViewModel = displayModel;
                this.NavigationViewModel = navigationModel;
            }
        }

        protected override void OnLoadDataCommandException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
