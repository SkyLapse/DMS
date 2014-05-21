using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Contains filtering parameters for a <see cref="User"/> request.
    /// </summary>
    public class UserCollectionParameters : CollectionFilterParameters
    {
        /// <summary>
        /// The default <see cref="UserCollectionParameters"/> returning all available <see cref="User"/>s.
        /// </summary>
        public static UserCollectionParameters Default
        {
            get
            {
                return new UserCollectionParameters();
            }
        }
    }
}
