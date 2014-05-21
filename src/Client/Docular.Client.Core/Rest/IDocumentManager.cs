using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Defines a mechanism to work with docular documents.
    /// </summary>
    [ContractClass(typeof(IDocumentManagerContracts))]
    public interface IDocumentManager
    {
        /// <summary>
        /// Uploads the specified new <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task AddDocumentAsync(Document document);

        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteDocumentAsync(String documentId);

        /// <summary>
        /// Gets the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain..</param>
        /// <returns>The <see cref="Document"/> with the specified ID, or <c>null</c> if the <see cref="Document"/> was not found.</returns>
        Task<Document> GetDocumentAsync(String documentId);

        /// <summary>
        /// Gets a filtered list of <see cref="Document"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        Task<Document[]> GetDocumentsAsync(DocumentCollectionParameters filter);

        /// <summary>
        /// Gets the amount of stored <see cref="Document"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Document"/>s.</returns>
        Task<int> GetDocumentCountAsync();

        /// <summary>
        /// Gets the size in bytes of a specified document collection.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>The size of the selected documents in bytes.</returns>
        Task<int> GetDocumentsSizeAsync(DocumentCollectionParameters filter);

        /// <summary>
        /// Gets the <see cref="Document"/>'s payload data.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the content of.</param>
        /// <returns>The <see cref="Document"/>'s payload.</returns>
        Task<Stream> GetPayloadAsync(String documentId);

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the thumbnail of.</param>
        /// <param name="height">The desired width of the thumbnail. Specifying values &lt; 0 results in no resizing / cropping.</param>
        /// <param name="width">The desired height of the thumbnail. Specifying values &lt; 0 results in no resizing / cropping.</param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        Task<Stream> GetThumbnailAsync(String documentId, int width = -1, int height = -1);

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateDocumentAsync(Document document);

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> content to the server.
        /// </summary>
        /// <param name="content">The <see cref="Document"/>'s content.</param>
        /// <param name="documentId">The ID of the <see cref="Document"/> whose content is to be updated.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateDocumentContentAsync(String documentId, Stream content);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(IDocumentManager))]
    abstract class IDocumentManagerContracts : IDocumentManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.AddDocumentAsync(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.DeleteDocumentAsync(String documentId)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Document> IDocumentManager.GetDocumentAsync(String documentId)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Document[]> IDocumentManager.GetDocumentsAsync(DocumentCollectionParameters filter)
        {
            Contract.Requires<ArgumentNullException>(filter != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> IDocumentManager.GetDocumentCountAsync()
        {
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> IDocumentManager.GetDocumentsSizeAsync(DocumentCollectionParameters filter)
        {
            Contract.Requires<ArgumentNullException>(filter != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Stream> IDocumentManager.GetPayloadAsync(String documentId)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Stream> IDocumentManager.GetThumbnailAsync(String documentId, int width, int height)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.UpdateDocumentAsync(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            Contract.Requires<ArgumentException>(document.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.UpdateDocumentContentAsync(String documentId, Stream content)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);
            Contract.Requires<ArgumentNullException>(content != null);

            return null;
        }
    }
}
