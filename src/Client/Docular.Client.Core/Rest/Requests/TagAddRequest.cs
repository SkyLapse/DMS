using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest.Requests
{
    /// <summary>
    /// The REST request for adding (or updating) a <see cref="Tag"/> to the remote DB.
    /// </summary>
    [Route("/tags", "POST")]
    [Route("/tags/{Id}", "PUT")]
    public class TagAddRequest : IReturnVoid
    {
        /// <summary>
        /// The <see cref="Category"/> to add.
        /// </summary>
        public Tag Tag { get; set; }

        /// <summary>
        /// The <see cref="Category"/>s Id.
        /// </summary>
        /// <remarks>Will be fetched from the <see cref="P:Tag"/>-property.</remarks>
        public String Id
        {
            get
            {
                Tag tag = this.Tag;
                return (tag != null) ? tag.Id : null;
            }
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Tag"/> into a <see cref="TagAddRequest"/>.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to create a <see cref="TagAddRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator TagAddRequest(Tag tag)
        {
            return (tag != null) ? new TagAddRequest() { Tag = tag } : null;
        }
    }
}
