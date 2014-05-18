using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest.Requests
{
    /// <summary>
    /// Contains filtering parameters for a <see cref="Tag"/> request.
    /// </summary>
    [Route("/tags", "GET")]
    public class TagCollectionRequest : CollectionRequest, IReturn<Tag[]>
    {
        /// <summary>
        /// The default <see cref="TagCollectionRequest"/> returning all available <see cref="Tag"/>s.
        /// </summary>
        public static TagCollectionRequest Default
        {
            get
            {
                return new TagCollectionRequest();
            }
        }

        /// <summary>
        /// Returns <see cref="Tag"/>s created by that given user only.
        /// </summary>
        public String UserId { get; set; }
    }
}
