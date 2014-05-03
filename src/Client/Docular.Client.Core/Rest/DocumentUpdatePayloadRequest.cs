using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Updates a <see cref="Document"/>'s payload.
    /// </summary>
    [Route("/documents/{Id}/payload", "POST")]
    public class DocumentUpdatePayloadRequest : IdVoidRequest
    {
        /// <summary>
        /// The new payload.
        /// </summary>
        public Stream File { get; set; }
    }
}
