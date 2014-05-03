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
    /// Contains filtering parameters for a <see cref="Document"/> collection request.
    /// </summary>
    [Route("/documents/size", "GET")]
    public class DocumentSizeRequest : DefaultParameters, IReturn<Document[]>
    {
        /// <summary>
        /// A default <see cref="DocumentSizeRequest"/> returning all <see cref="Document"/>s.
        /// </summary>
        public static DocumentSizeRequest Default
        {
            get
            {
                return new DocumentSizeRequest();
            }
        }

        /// <summary>
        /// Returns <see cref="Document"/>s that belong into that specific category only.
        /// </summary>
        public String CategoryId { get; set; }

        /// <summary>
        /// Filtering text used for searching though the extracted content.
        /// </summary>
        /// <remarks>Like Google / Bing / Yahoo for documents.</remarks>
        public String Search { get; set; }

        /// <summary>
        /// Returns shared / non-shared <see cref="Document"/>s only.
        /// </summary>
        public bool Shared { get; set; }

        /// <summary>
        /// Returns <see cref="Document"/>s that are tagged with the given tag only.
        /// </summary>
        public String TagId { get; set; }

        /// <summary>
        /// Returns <see cref="Document"/>s created by that given user only.
        /// </summary>
        public String UserId { get; set; }
    }
}
