using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;

namespace Docular.Client.Core.Controller
{
    /// <summary>
    /// Defines a mechanism to work with docular documents.
    /// </summary>
    public interface IDocumentManager
    {
        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteDocumentAsync(Document document);

        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteDocumentAsync(String documentId);

        /// <summary>
        /// Gets the <see cref="Document"/>'s content.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to obtain the content of.</param>
        /// <returns>The <see cref="Document"/>'s content.</returns>
        Task<Stream> GetContentAsync(Document document);

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
        /// <param name="user">The <see cref="User"/> who created the <see cref="Document"/>.</param>
        /// <param name="category">The <see cref="Category"/> the <see cref="Document"/> belongs to.</param>
        /// <param name="tag">A <see cref="Tag"/> of the <see cref="Document"/>.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        Task<Document[]> GetDocumentsAsync(User user = null, Category category = null, Tag tag = null);

        /// <summary>
        /// Gets a filtered list of <see cref="Document"/>s that match the specified criteria.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> who created the <see cref="Document"/>.</param>
        /// <param name="categoryId">The ID of the <see cref="Category"/> the <see cref="Document"/> belongs to.</param>
        /// <param name="tagId">The ID of a <see cref="Tag"/> of the <see cref="Document"/>.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        Task<Document[]> GetDocumentsAsync(String userId = null, String categoryId = null, String tagId = null);

        /// <summary>
        /// Gets the amount of stored <see cref="Document"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Document"/>s.</returns>
        Task<int> GetDocumentCountAsync();

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to obtain the thumbnail of.</param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        Task<Stream> GetThumbnailAsync(Document document);

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the thumbnail of.</param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        Task<Stream> GetThumbnailAsync(String documentId);

        /// <summary>
        /// Uploads the specified new / changed <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PostDocumentAsync(Document document);

        /// <summary>
        /// Uploads the specified <see cref="Document"/>'s content to the server. See remarks.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload the contents from.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        /// <remarks>
        /// The content path of the <see cref="Document"/> has to be local, otherwise a <see cref="InvalidOperationException"/>
        /// will be thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The <see cref="Document"/>'s content path does not point to a local file.</exception>
        Task UploadContentAsync(Document document);

        /// <summary>
        /// Uploads the specified <see cref="Document"/>'s content to the server. See remarks.
        /// </summary>
        /// <param name="documentId">The ID <see cref="Document"/> to upload the contents from.</param>
        /// <param name="content">The <see cref="Document"/>'s content.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        /// <remarks>
        /// The content path of the <see cref="Document"/> has to be local, otherwise a <see cref="InvalidOperationException"/>
        /// will be thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The <see cref="Document"/>'s content path does not point to a local file.</exception>
        Task UploadContentAsync(String documentId, Stream content);
    }
}
