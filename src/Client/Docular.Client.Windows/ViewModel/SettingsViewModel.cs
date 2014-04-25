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
using Docular.Client.Model.Rest;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The settings view model.
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        /// <summary>
        /// The <see cref="DocularSection"/> to edit.
        /// </summary>
        private DocularSection section;

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
        private String _DocularHomeUrl;

        /// <summary>
        /// The uri of the server to work with.
        /// </summary>
        public String DocularHomeUrl
        {
            get
            {
                return _DocularHomeUrl;
            }
            set
            {
                this.SetProperty(ref _DocularHomeUrl, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="SettingsViewModel"/>.
        /// </summary>
        public SettingsViewModel()
            : base(Resources.Strings.General.SettingsCaption, (Path)System.Windows.Application.Current.Resources["SettingsIcon"])
        {
            this.section = DocularSection.Default;
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
                this.section.CurrentConfiguration.Save();
            }
        }
    }
}
