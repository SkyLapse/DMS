using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;
using RestSharp.Portable;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Defines a mechanism to work with docular documents.
    /// </summary>
    [ContractClass(typeof(DocumentManagerContracts))]
    public interface IDocumentManager
    {
        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteDocumentAsync(String documentId);

        /// <summary>
        /// Gets the <see cref="Document"/>'s content.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the content of.</param>
        /// <returns>The <see cref="Document"/>'s content.</returns>
        Task<Stream> GetContentAsync(String documentId);

        /// <summary>
        /// Gets the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Document"/> to obtain.</param>
        /// <returns>The <see cref="Document"/> with the specified ID, or <c>null</c> if the <see cref="Document"/> was not found.</returns>
        Task<Document> GetDocumentAsync(String id);

        /// <summary>
        /// Gets a filtered list of <see cref="Document"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filterParameters">A collection of <see cref="Parameter"/>s to filter by.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        Task<Document[]> GetDocumentsAsync(params Parameter[] filterParameters);

        /// <summary>
        /// Gets the amount of stored <see cref="Document"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Document"/>s.</returns>
        Task<int> GetDocumentCountAsync();

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the thumbnail of.</param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        Task<Stream> GetThumbnailAsync(String documentId);

        /// <summary>
        /// Uploads the specified new <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PostDocumentAsync(Document document);

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PutDocumentAsync(Document document);

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> content to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> of which the content to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PutDocumentContentAsync(Document document);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(IDocumentManager))]
    abstract class DocumentManagerContracts : IDocumentManager
    {
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
        Task<System.IO.Stream> IDocumentManager.GetContentAsync(String documentId)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Document> IDocumentManager.GetDocumentAsync(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Document[]> IDocumentManager.GetDocumentsAsync(params Parameter[] filterParameters)
        {
            Contract.Requires<ArgumentNullException>(filterParameters != null);
            Contract.Requires<ArgumentException>(filterParameters.All(filterParam => filterParam.Type == ParameterType.GetOrPost));

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
        Task<System.IO.Stream> IDocumentManager.GetThumbnailAsync(String documentId)
        {
            Contract.Requires<ArgumentNullException>(documentId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.PostDocumentAsync(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.PutDocumentAsync(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            Contract.Requires<ArgumentNullException>(document.Id != null);
            
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IDocumentManager.PutDocumentContentAsync(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            Contract.Requires<ArgumentNullException>(document.Id != null);

            return null;
        }
    }
}
