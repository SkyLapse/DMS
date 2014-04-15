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
        /// The <see cref="Uri"/> of the default skin.
        /// </summary>
        private static Uri DefaultSkinUri = new Uri("Resources/Skins/Default.xaml", UriKind.Relative);

        /// <summary>
        /// Initializes a new <see cref="App"/>.
        /// </summary>
        public App()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            DocularSection section = (DocularSection)config.GetSection(DocularSection.SectionXmlKey);

            Contract.Assume(section != null);
            ((App)Application.Current).UpdateSkin(section.Skin);
        }

        /// <summary>
        /// Changes the application's skin. See remarks.
        /// </summary>
        /// <remarks>
        /// The method will fall back to the default skin if applying the new skin failed. If you need to apply
        /// a skin from a different directory use the overload taking an <see cref="Uri"/>-parameter instead.
        /// </remarks>
        /// <param name="skinFileName">The file name of the skin file (residing in Resources/Skins/FILENAME.xaml) without the extension.</param>
        public void UpdateSkin(String skinFileName)
        {
            Contract.Requires<ArgumentNullException>(skinFileName != null);

            Uri skinUri = new Uri(String.Format("Resources/Skins/{0}.xaml", Uri.EscapeUriString(skinFileName)), UriKind.Relative);
            Contract.Assume(!skinUri.IsAbsoluteUri);
            this.UpdateSkin(skinUri);
        }

        /// <summary>
        /// Changes the application's skin.
        /// </summary>
        /// <remarks>The method will fall back to the default skin if applying the new skin failed.</remarks>
        /// <param name="skinUri">The <see cref="Uri"/> of the <see cref="ResourceDictionary"/> containing the skin to load.</param>
        /// <exception cref="InvalidOperationException">Applying the desired skin failed and trying to fall back to the default skin failed as well.</exception>
        public void UpdateSkin(Uri skinUri)
        {
            Contract.Requires<ArgumentNullException>(skinUri != null);
            Contract.Requires<ArgumentException>(!skinUri.IsAbsoluteUri);

            try
            {
                ResourceDictionary newDict = (ResourceDictionary)Application.LoadComponent(skinUri);
                this.ReplaceResourceDictonaries(
                    this.Resources,
                    newDict,
                    dict => dict.Keys.OfType<String>().Contains("IsSkinDictionary")
                );
            }
            catch
            {
                if (skinUri != DefaultSkinUri)
                {
                    this.UpdateSkin(DefaultSkinUri);
                }
                else
                {
                    throw new InvalidOperationException("Applying the skin failed and falling back to the default skin failed as well!");
                }
            }
        }

        /// <summary>
        /// Recursively replaces the resource dictionary's merged dictionaries if a predicate matches.
        /// </summary>
        /// <param name="current">The <see cref="ResourceDictionary"/> of which the merged <see cref="ResourceDictionary"/>s to check.</param>
        /// <param name="newDict">The <see cref="ResourceDictionary"/> to replace the matches with.</param>
        /// <param name="predicate">The predicate selecting <see cref="ResourceDictionary"/>s for replacement.</param>
        private void ReplaceResourceDictonaries(ResourceDictionary current, ResourceDictionary newDict, Predicate<ResourceDictionary> predicate)
        {
            Contract.Requires<ArgumentNullException>(current != null);
            Contract.Requires<ArgumentNullException>(newDict != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            for (int i = 0; i < current.MergedDictionaries.Count(); i++)
            {
                if (current.MergedDictionaries[i] != null)
                {
                    if (predicate(current.MergedDictionaries[i]))
                    {
                        current.MergedDictionaries[i] = newDict;
                    }
                    ReplaceResourceDictonaries(current.MergedDictionaries[i], newDict, predicate);
                }
            }
        }
    }
}
