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
    /// The REST request to add (or update) a <see cref="Document"/> to the remote DB.
    /// </summary>
    [Route("/documents", "POST")]
    [Route("/documents/{Id}", "PUT")]
    public class DocumentAddRequest : IReturnVoid
    {
        /// <summary>
        /// The <see cref="Document"/> to add.
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// The <see cref="Document"/>s Id.
        /// </summary>
        /// <remarks>Will be fetched from the <see cref="P:Document"/>-property.</remarks>
        public String Id
        {
            get
            {
                Document document = this.Document;
                return (document != null) ? document.Id : null;
            }
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Document"/> into a <see cref="DocumentAddRequest"/>.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to create a <see cref="DocumentAddRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentAddRequest(Document document)
        {
            return (document != null) ? new DocumentAddRequest() { Document = document } : null;
        }
    }
}
