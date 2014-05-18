using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using Docular.Client.Rest.Requests;

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
        /// <param name="documentRequest">A <see cref="DocumentAddRequest"/> containing the <see cref="Document"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task AddDocumentAsync(DocumentAddRequest documentRequest);

        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="deleteRequest">The <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteDocumentAsync(DocumentDeleteRequest deleteRequest);

        /// <summary>
        /// Gets the <see cref="Document"/>'s payload data.
        /// </summary>
        /// <param name="payloadRequest">A <see cref="DocumentPayloadRequest"/> of the <see cref="Document"/> to obtain the content of.</param>
        /// <returns>The <see cref="Document"/>'s payload.</returns>
        Task<Stream> GetPayloadAsync(DocumentPayloadRequest payloadRequest);

        /// <summary>
        /// Gets the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="documentRequest">A <see cref="DocumentRequest"/> used to obtain the <see cref="Document"/>.</param>
        /// <returns>The <see cref="Document"/> with the specified ID, or <c>null</c> if the <see cref="Document"/> was not found.</returns>
        Task<Document> GetDocumentAsync(DocumentRequest documentRequest);

        /// <summary>
        /// Gets a filtered list of <see cref="Document"/>s that match the specified criteria.
        /// </summary>
        /// <param name="collectionRequest">A collection of parameters to filter by.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        Task<Document[]> GetDocumentsAsync(DocumentCollectionRequest collectionRequest);

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
        Task<int> GetDocumentsSizeAsync(DocumentSizeRequest filter);

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="thumbnailRequest">
        /// A <see cref="DocumentThumbnailRequest"/> containing the ID of the <see cref="Document"/> to obtain the thumbnail of.
        /// </param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        Task<Stream> GetThumbnailAsync(DocumentThumbnailRequest thumbnailRequest);

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="documentRequest">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateDocumentAsync(DocumentAddRequest documentRequest);

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> content to the server.
        /// </summary>
        /// <param name="updatePayloadRequest">A <see cref="DocumentUpdatePayloadRequest"/> containing the new payload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateDocumentContentAsync(DocumentUpdatePayloadRequest updatePayloadRequest);
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
        Task IDocumentManager.AddDocumentAsync(DocumentAddRequest documentRequest)
        {
            Contract.Requires<ArgumentNullException>(documentRequest != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.DeleteDocumentAsync(DocumentDeleteRequest deleteRequest)
        {
            Contract.Requires<ArgumentNullException>(deleteRequest != null);
            Contract.Requires<ArgumentException>(deleteRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Stream> IDocumentManager.GetPayloadAsync(DocumentPayloadRequest payloadRequest)
        {
            Contract.Requires<ArgumentNullException>(payloadRequest != null);
            Contract.Requires<ArgumentException>(payloadRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Document> IDocumentManager.GetDocumentAsync(DocumentRequest documentRequest)
        {
            Contract.Requires<ArgumentNullException>(documentRequest != null);
            Contract.Requires<ArgumentException>(documentRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Document[]> IDocumentManager.GetDocumentsAsync(DocumentCollectionRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

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
        Task<int> IDocumentManager.GetDocumentsSizeAsync(DocumentSizeRequest filter)
        {
            Contract.Requires<ArgumentNullException>(filter != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Stream> IDocumentManager.GetThumbnailAsync(DocumentThumbnailRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);
            Contract.Requires<ArgumentException>(request.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.UpdateDocumentAsync(DocumentAddRequest documentRequest)
        {
            Contract.Requires<ArgumentNullException>(documentRequest != null);
            Contract.Requires<ArgumentException>(documentRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.UpdateDocumentContentAsync(DocumentUpdatePayloadRequest updatePayloadRequest)
        {
            Contract.Requires<ArgumentNullException>(updatePayloadRequest != null);
            Contract.Requires<ArgumentException>(updatePayloadRequest.Id != null);

            return null;
        }
    }
}
