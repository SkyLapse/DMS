using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Contains filtering parameters for a <see cref="Document"/> collection request.
    /// </summary>
    [DataContract]
    public class DocumentCollectionParameters : CollectionFilterParameters
    {
        /// <summary>
        /// A default <see cref="DocumentCollectionParameters"/> returning all <see cref="Document"/>s.
        /// </summary>
        public static DocumentCollectionParameters Default
        {
            get
            {
                return new DocumentCollectionParameters();
            }
        }

        /// <summary>
        /// Returns <see cref="Document"/>s that belong into that specific category only.
        /// </summary>
        [DataMember]
        public String CategoryId { get; set; }

        /// <summary>
        /// Filtering text used for searching though the extracted content.
        /// </summary>
        /// <remarks>Like Google / Bing / Yahoo for documents.</remarks>
        [DataMember]
        public String Search { get; set; }

        /// <summary>
        /// Returns shared / non-shared <see cref="Document"/>s only.
        /// </summary>
        [DataMember]
        public bool Shared { get; set; }

        /// <summary>
        /// Returns <see cref="Document"/>s that are tagged with the given tag only.
        /// </summary>
        [DataMember]
        public String TagId { get; set; }
    }
}
