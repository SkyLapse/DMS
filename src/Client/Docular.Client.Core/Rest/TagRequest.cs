using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// The REST request used to retreive a single <see cref="Tag"/>.
    /// </summary>
    [Route("/tags/{Id}", "GET")]
    public class TagRequest : IdRequest<Tag>
    {
        /// <summary>
        /// Implicitly converts the specified <see cref="Tag"/>-ID into a <see cref="TagRequest"/>.
        /// </summary>
        /// <param name="tagId">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator TagRequest(String tagId)
        {
            return (tagId != null) ? new TagRequest() { Id = tagId } : null;
        }
    }
}
