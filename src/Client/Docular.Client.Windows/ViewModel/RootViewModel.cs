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
    public class RootViewModel : BaseViewModel
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
                this.SetProperty(ref _DisplayViewModel, value);
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
                this.SetProperty(ref _NavigationViewModel, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="RootViewModel"/>.
        /// </summary>
        public RootViewModel() 
        {
            StartViewModel startModel = new StartViewModel();
            SidebarViewModel sidebarModel = new SidebarViewModel();
            Task.WaitAll(startModel.LoadData(), sidebarModel.LoadData());
            this.DisplayViewModel = startModel;
            this.NavigationViewModel = sidebarModel;
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override Task LoadData()
        {
            return Task.FromResult<object>(null);
        }

        protected override void OnLoadDataCommandException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
