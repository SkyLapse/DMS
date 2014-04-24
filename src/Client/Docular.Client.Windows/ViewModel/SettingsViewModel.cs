using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private String _Skin;

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

        private String _DocularHomeUrl;

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
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override Task LoadData()
        {
            throw new NotImplementedException();
        }

        protected override void OnLoadDataCommandException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
