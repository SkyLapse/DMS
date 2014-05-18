using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest.Requests
{
    /// <summary>
    /// The REST request used to obtain a <see cref="Document"/>'s payload
    /// </summary>
    [Route("/documents/{Id}/thumbnail", "GET")]
    public class DocumentThumbnailRequest : IdRequest<Stream>
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        public int _Height = -1;

        /// <summary>
        /// The thumbnail's desired height.
        /// </summary>
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private int _Width = -1;

        /// <summary>
        /// The thumbnail's desired width.
        /// </summary>
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Document"/> into a <see cref="DocumentThumbnailRequest"/>.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to create a <see cref="DocumentThumbnailRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentThumbnailRequest(Document document)
        {
            return (document != null) ? new DocumentThumbnailRequest() { Id = document.Id } : null;
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Document"/> ID into a <see cref="DocumentThumbnailRequest"/>.
        /// </summary>
        /// <param name="documentId">The <see cref="Document"/> ID to create a <see cref="DocumentThumbnailRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator DocumentThumbnailRequest(String documentId)
        {
            return (documentId != null) ? new DocumentThumbnailRequest() { Id = documentId } : null;
        }
    }
}
