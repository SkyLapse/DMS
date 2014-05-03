using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// The REST-Request for deleting a specific <see cref="Tag"/>.
    /// </summary>
    [Route("/tags/{Id}", "DELETE")]
    public class TagDeleteRequest : IdVoidRequest
    {
        /// <summary>
        /// Implicitly converts the <see cref="Category"/> into a <see cref="TagDeleteRequest"/>.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator TagDeleteRequest(Tag tag)
        {
            Contract.Requires<ArgumentNullException>(tag != null);

            return new TagDeleteRequest() { Id = tag.Id };
        }

        /// <summary>
        /// Implicitly converts the tag ID into a <see cref="TagDeleteRequest"/>.
        /// </summary>
        /// <param name="category">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator TagDeleteRequest(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return new TagDeleteRequest() { Id = id };
        }
    }
}
