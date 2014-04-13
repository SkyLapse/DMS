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

            ResourceDictionary newDict = (ResourceDictionary)Application.LoadComponent(skinUri);
            if (newDict == null)
            {
                throw new InvalidOperationException("The new skin to be applied could not be found.");
            }
            this.ReplaceResourceDictonaries(
                this.Resources,
                newDict,
                dict => dict.Keys.OfType<String>().Contains("IsSkinDictionary")
            );
        }

        /// <summary>
        /// Recursively replaces the resource dictionary's merged dictionarys if a predicate matches.
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
