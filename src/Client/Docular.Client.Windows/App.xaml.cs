using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Docular.Client.Windows
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Changes the application's skin.
        /// </summary>
        /// <param name="skinUri">The <see cref="Uri"/> of the <see cref="ResourceDictionary"/> containing the skin to load.</param>
        public void UpdateSkin(Uri skinUri)
        {
            Contract.Requires<ArgumentNullException>(skinUri != null);
            Contract.Requires<ArgumentException>(!skinUri.IsAbsoluteUri);

            ResourceDictionary newSkinDictionary = (ResourceDictionary)Application.LoadComponent(skinUri);
            throw new NotImplementedException();
        }
    }
}
