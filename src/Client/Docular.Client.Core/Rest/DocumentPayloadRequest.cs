using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// The REST request used to obtain a <see cref="Document"/>'s payload
    /// </summary>
    [Route("/documents/{Id}/payload", "GET")]
    public class DocumentPayloadRequest : IdRequest<Stream>
    {
        /// <summary>
        /// Implicitly converts the specified <see cref="Document"/> into a <see cref="DocumentPayloadRequest"/>.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to create a <see cref="DocumentPayloadRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentPayloadRequest(Document document)
        {
            return (document != null) ? new DocumentPayloadRequest() { Id = document.Id } : null;
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Document"/> ID into a <see cref="DocumentPayloadRequest"/>.
        /// </summary>
        /// <param name="documentId">The <see cref="Document"/> ID to create a <see cref="DocumentPayloadRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentPayloadRequest(String documentId)
        {
            return (documentId != null) ? new DocumentPayloadRequest() { Id = documentId } : null;
        }
    }
}
