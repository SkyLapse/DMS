using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Contains filtering parameters for a <see cref="Category"/> request.
    /// </summary>
    public class CategoryCollectionParameters : CollectionFilterParameters
    {
        /// <summary>
        /// The default <see cref="CategoryCollectionParameters"/> returning all available <see cref="Category"/>s.
        /// </summary>
        public static CategoryCollectionParameters Default
        {
            get
            {
                return new CategoryCollectionParameters();
            }
        }

        /// <summary>
        /// Returns <see cref="Category"/>s with that specified parent only.
        /// </summary>
        [DataMember]
        public String ParentId { get; set; }
    }
}
