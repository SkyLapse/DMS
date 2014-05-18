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
    /// Contains filtering parameters for a <see cref="Category"/> request.
    /// </summary>
    [Route("/categories", "GET")]
    public class CategoryCollectionRequest : CollectionRequest, IReturn<Category[]>
    {
        /// <summary>
        /// The default <see cref="CategoryCollectionRequest"/> returning all available <see cref="Category"/>s.
        /// </summary>
        public static CategoryCollectionRequest Default
        {
            get
            {
                return new CategoryCollectionRequest();
            }
        }

        /// <summary>
        /// Returns <see cref="Category"/>s with that specified parent only.
        /// </summary>
        public String ParentId { get; set; }

        /// <summary>
        /// Returns <see cref="Category"/>s created by that given user only.
        /// </summary>
        public String UserId { get; set; }
    }
}
