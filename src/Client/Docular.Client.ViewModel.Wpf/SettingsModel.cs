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
    /// The settings view model.
    /// </summary>
    public class SettingsModel : BaseModel
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
                if (value != _Skin)
                {
                    _Skin = value;
                    this.OnPropertyChanged();
                }
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
                if (value != _DocularHomeUrl)
                {
                    _DocularHomeUrl = value;
                    this.OnPropertyChanged();
                }
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
    }
}
