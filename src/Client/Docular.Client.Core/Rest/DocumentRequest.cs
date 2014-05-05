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
    /// Retreives a single <see cref="Document"/> by its ID.
    /// </summary>
    [Route("/documents/{Id}", "GET")]
    public class DocumentRequest : IdRequest<Document>
    {
        /// <summary>
        /// Implicitly converts the specified <see cref="Document"/>-ID into a <see cref="DocumentRequest"/>.
        /// </summary>
        /// <param name="documentId">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentRequest(String documentId)
        {
            return (documentId != null) ? new DocumentRequest() { Id = documentId } : null;
        }
    }
}
