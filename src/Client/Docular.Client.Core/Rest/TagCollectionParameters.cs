using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Contains filtering parameters for a <see cref="Tag"/> request.
    /// </summary>
    public class TagCollectionParameters : CollectionFilterParameters
    {
        /// <summary>
        /// The default <see cref="TagCollectionParameters"/> returning all available <see cref="Tag"/>s.
        /// </summary>
        public static TagCollectionParameters Default
        {
            get
            {
                return new TagCollectionParameters();
            }
        }
    }
}
