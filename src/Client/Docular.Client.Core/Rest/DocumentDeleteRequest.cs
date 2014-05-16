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
    [Route("/documents/{Id}", "DELETE")]
    public class DocumentDeleteRequest : IdVoidRequest
    {
        /// <summary>
        /// Implicitly converts the <see cref="Category"/> into a <see cref="DocumentDeleteRequest"/>.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentDeleteRequest(Document document)
        {
            return (document != null) ? new DocumentDeleteRequest() { Id = document.Id } : null;
        }

        /// <summary>
        /// Implicitly converts the tag ID into a <see cref="DocumentDeleteRequest"/>.
        /// </summary>
        /// <param name="category">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentDeleteRequest(String id)
        {
            return (id != null) ? new DocumentDeleteRequest() { Id = id } : null;
        }
    }
}
