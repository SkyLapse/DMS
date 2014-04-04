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
            Contract.Requires<ArgumentNullException>(docularUri != null);
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
            Contract.Requires<ArgumentException>(docularUri.AbsoluteUri.EndsWith("api") || docularUri.AbsoluteUri.EndsWith("api/"));
            
            if (docularUri.AbsoluteUri.EndsWith("api"))
            {
                Uri result;
                if (!Uri.TryCreate(docularUri, "/", out result))
                {
                    throw new Exception("An error occured while appending '/' to the docular API URI.");
                }
                docularUri = result;
            }

            this.DocularUri = docularUri;
            this.restClient.BaseUrl = this.DocularUri;
            this.restClient.Authenticator = new DocularAuthenticator(keyStore);
        }

        #region Documents

        public Task DeleteDocumentAsync(Document document)
        {
            return this.DeleteDocumentAsync(document.Id);
        }

        public async Task DeleteDocumentAsync(String documentId)
        {
            RestRequest deleteRequest = new RestRequest(this.CreateApiUri("documents/" + documentId), HttpMethod.Delete);
            IRestResponse response = await this.restClient.Execute(deleteRequest);
            if (response.StatusCode.IsError())
            {
                throw new HttpException(response.StatusDescription, response.StatusCode);
            }
        }

        public Task<Stream> GetContentAsync(Document document)
        {
            return this.GetContentAsync(document.Id);
        }

        public Task<Stream> GetContentAsync(String documentId)
        {
            return new HttpClient().GetStreamAsync(this.CreateApiUri("documents/" + documentId + "/content"));
        }

        public async Task<Document> GetDocumentAsync(String id)
        {
            RestRequest documentRequest = new RestRequest(this.CreateApiUri("documents/" + id), HttpMethod.Get);
            return (await this.restClient.Execute<Document>(documentRequest)).Data;
        }

        public Task<Document[]> GetDocumentsAsync(User user = null, Category category = null, Tag tag = null)
        {
            return this.GetDocumentsAsync((user != null) ? user.Id : null, (category != null) ? category.Id : null, (tag != null) ? tag.Id : null);
        }

        public async Task<Document[]> GetDocumentsAsync(String userId = null, String categoryId = null, String tagId = null)
        {
            RestRequest documentRequest = new RestRequest(this.CreateApiUri("documents"), HttpMethod.Get);
            documentRequest.AddParameter("user", userId, ParameterType.GetOrPost);
            documentRequest.AddParameter("category", categoryId, ParameterType.GetOrPost);
            documentRequest.AddParameter("tag", tagId, ParameterType.GetOrPost);

            return (await this.restClient.Execute<Document[]>(documentRequest)).Data;
        }

        public async Task<int> GetDocumentCountAsync()
        {
            RestRequest countRequest = new RestRequest(this.CreateApiUri("documents/count"), HttpMethod.Get);
            return (await this.restClient.Execute<int>(countRequest)).Data;
        }

        public Task<Stream> GetThumbnailAsync(Document document)
        {
            return this.GetThumbnailAsync(document.Id);
        }

        public Task<Stream> GetThumbnailAsync(String documentId)
        {
            return new HttpClient().GetStreamAsync(this.CreateApiUri("documents/" + documentId + "/thumbnail"));
        }

        public Task PostDocumentAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task UploadContentAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public async Task UploadContentAsync(String documentId, System.IO.Stream content)
        {
            RestRequest uploadRequest = new RestRequest(this.CreateApiUri("documents/" + documentId + "/content"), HttpMethod.Post);
            uploadRequest.AddFile("content", content, "TEST");
            IRestResponse response = await this.restClient.Execute(uploadRequest);
            if (response.StatusCode.IsError())
            {
                throw new HttpException(response.StatusDescription, response.StatusCode);
            }
        }

        #endregion

        #region Categories

        public Task DeleteCategoryAsync(Category category)
        {
            return this.DeleteCategoryAsync(category.Id);
        }

        public Task DeleteCategoryAsync(String categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<Category[]> GetCategoriesAsync(User user = null, Category parent = null)
        {
            return this.GetCategoriesAsync((user != null) ? user.Id : null, (parent != null) ? parent.Id : null);
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

        public Task DeleteTagAsync(Tag tag)
        {
            return this.DeleteTagAsync(tag.Id);
        }

        public Task DeleteTagAsync(String tagId)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTagAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag[]> GetTagsAsync(User user = null)
        {
            return this.GetTagsAsync((user != null) ? user.Id : null);
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

        public Task DeleteUserAsync(User user)
        {
            return this.DeleteUserAsync(user.Id);
        }

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

        /// <summary>
        /// Creates an API <see cref="Uri"/> from the <see cref="Uri"/> the <see cref="DocularClient"/> was initialized with and the specified one.
        /// </summary>
        /// <param name="apiUri">The sub <see cref="Uri"/> for the specified API function.</param>
        /// <returns>The combined <see cref="Uri"/>.</returns>
        private Uri CreateApiUri(String apiUri)
        {
            return this.CreateApiUri(new Uri(apiUri));
        }

        /// <summary>
        /// Creates an API <see cref="Uri"/> from the <see cref="Uri"/> the <see cref="DocularClient"/> was initialized with and the specified one.
        /// </summary>
        /// <param name="apiUri">The sub <see cref="Uri"/> for the specified API function.</param>
        /// <returns>The combined <see cref="Uri"/>.</returns>
        private Uri CreateApiUri(Uri apiUri)
        {
            Uri result;
            if (!Uri.TryCreate(this.DocularUri, apiUri, out result))
            {
                throw new InvalidOperationException("There was an error combining the URIs.");
            }
            return result;
        }
    }
}
