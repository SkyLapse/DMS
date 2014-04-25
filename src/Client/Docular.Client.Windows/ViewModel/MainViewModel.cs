using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Docular.Client;
using GalaSoft.MvvmLight.Messaging;

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
        private BaseViewModel _ContentViewModel;

        /// <summary>
        /// The model to display in the UI.
        /// </summary>
        public BaseViewModel ContentViewModel
        {
            get
            {
                return _ContentViewModel;
            }
            set
            {
                this.SetProperty(ref _ContentViewModel, value);
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
        /// Initializes a new <see cref="MainViewModel"/>.
        /// </summary>
        public MainViewModel() 
        {
            Messenger.Default.Register<ChangeViewModelMessage>(this, m => this.ContentViewModel = m.NewViewModel);

            ViewModelLocator locator = (ViewModelLocator)Application.Current.Resources["ViewModelLocator"];
            Contract.Assume(locator != null);
            this.ContentViewModel = locator.StartViewModel;
            this.NavigationViewModel = locator.SidebarViewModel;
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
