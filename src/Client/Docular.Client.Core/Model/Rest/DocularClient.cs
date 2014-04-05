using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;
using RestSharp.Portable;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents a client for working with a docular DB.
    /// </summary>
    public class DocularClient : IDocularClient
    {
        /// <summary>
        /// The <see cref="RestClient"/> used to perform the REST requests.
        /// </summary>
        private RestClient restClient = new RestClient();

        /// <summary>
        /// The adress of the the remote host.
        /// </summary>
        public Uri DocularUri { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="docularUri">The adress of the remote host.</param>
        /// <param name="keyStore">A <see cref="IKeyStore"/> used to obtain the key.</param>
        public DocularClient(String docularUri, IKeyStore keyStore)
            : this(new Uri(docularUri), keyStore)
        {
            Contract.Requires<ArgumentNullException>(docularUri != null && keyStore != null);
        }

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="docularUri">The adress of the remote host.</param>
        /// <param name="keyStore">A <see cref="IKeyStore"/> used to obtain the key.</param>
        public DocularClient(Uri docularUri, IKeyStore keyStore)
        {
            Contract.Requires<ArgumentNullException>(docularUri != null && keyStore != null);
            Contract.Requires<ArgumentException>(!docularUri.IsFile);
            Contract.Requires<ArgumentException>(docularUri.AbsoluteUri.EndsWith("/api") || docularUri.AbsoluteUri.EndsWith("/api/"));

            this.DocularUri = docularUri;
            this.restClient.BaseUrl = this.DocularUri;
            this.restClient.Authenticator = new DocularAuthenticator(keyStore);
        }

        #region Documents

        public Task DeleteDocumentAsync(String documentId)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetContentAsync(String documentId)
        {
            throw new NotImplementedException();
        }

        public Task<Document> GetDocumentAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<Document[]> GetDocumentsAsync(String userId = null, String categoryId = null, String tagId = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetDocumentCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetThumbnailAsync(String documentId)
        {
            throw new NotImplementedException();
        }

        public Task PostDocumentAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task UploadContentAsync(String documentId, System.IO.Stream content)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Categories

        public Task DeleteCategoryAsync(String categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<Category[]> GetCategoriesAsync(String userId = null, String parentId = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCategoryCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task PostCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Tags

        public Task DeleteTagAsync(String tagId)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTagAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag[]> GetTagsAsync(String userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTagCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task PostTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Users

        public Task DeleteUserAsync(String userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task PostUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
