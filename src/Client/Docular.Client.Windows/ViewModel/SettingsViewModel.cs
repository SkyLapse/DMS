using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client;
using Docular.Client.Model;
using Docular.Client.Rest;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The settings view model.
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        /// <summary>
        /// The <see cref="RemoteDbSection"/> to edit.
        /// </summary>
        private RemoteDbSection remoteDbSection;

        /// <summary>
        /// The <see cref="RemoteDbSection"/> to edit.
        /// </summary>
        private GeneralSection generalSection;

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Skin;

        /// <summary>
        /// The application skin.
        /// </summary>
        public String Skin
        {
            get
            {
                return _Skin;
            }
            set
            {
                this.SetProperty(ref _Skin, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _DocularApiUrl;

        /// <summary>
        /// The uri of the server to work with.
        /// </summary>
        public String DocularApiUrl
        {
            get
            {
                return _DocularApiUrl;
            }
            set
            {
                this.SetProperty(ref _DocularApiUrl, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="SettingsViewModel"/>.
        /// </summary>
        public SettingsViewModel()
            : base(Resources.Strings.General.SettingsCaption, (Path)System.Windows.Application.Current.Resources["SettingsIcon"])
        {
            this.remoteDbSection = RemoteDbSection.Default;
            this.generalSection = GeneralSection.Default;
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override Task LoadData()
        {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Saves the current configuration to the disk.
        /// </summary>
        public void Save()
        {
            using (IsBusySwitcher switcher = this.StartBusySection())
            {
                this.remoteDbSection.CurrentConfiguration.Save();
            }
        }
    }
}
