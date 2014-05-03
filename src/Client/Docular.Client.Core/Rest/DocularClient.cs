using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;
using ServiceStack.Text;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Represents a client for working with a docular DB.
    /// </summary>
    public class DocularClient : IDocularClient
    {
        /// <summary>
        /// The <see cref="JsonServiceClient"/> executing the requests.
        /// </summary>
        private JsonServiceClient client = new JsonServiceClient();

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="baseUri">The base URL of the remote docular host.</param>
        public DocularClient(String baseUri)
        {
            Contract.Requires<ArgumentNullException>(baseUri != null);

            this.client.BaseUri = baseUri;
            JsConfig.EmitCamelCaseNames = true;
        }

        #region API-Keys

        public Task<String> GetKey(ApiKeyRequest keyRequest)
        {
            return this.client.PostAsync<String>(keyRequest);
        }

        public Task<bool> ValidateKey(ApiKeyValidateRequest validateRequest)
        {
            return this.client.PostAsync<bool>(validateRequest);
        }

        #endregion

        #region Categories

        public Task AddCategoryAsync(CategoryAddRequest tagAddRequest)
        {
            return this.client.PostAsync(tagAddRequest);
        }

        public Task DeleteCategoryAsync(CategoryDeleteRequest deleteRequest)
        {
            return this.client.DeleteAsync(deleteRequest);
        }

        public Task<Category> GetCategoryAsync(CategoryRequest categoryRequest)
        {
            return this.client.GetAsync<Category>(categoryRequest);
        }

        public Task<Category[]> GetCategoriesAsync(CategoryCollectionRequest collectionRequest)
        {
            return this.client.GetAsync<Category[]>(collectionRequest);
        }

        public Task<int> GetCategoryCountAsync()
        {
            return this.client.GetAsync<int>(new CategoryCountRequest());
        }

        public Task UpdateCategoryAsync(CategoryAddRequest categoryRequest)
        {
            return this.client.PutAsync(categoryRequest);
        }

        #endregion

        #region Documents

        public Task AddDocumentAsync(DocumentAddRequest documentRequest)
        {
            return this.client.PostAsync(documentRequest);
        }

        public Task DeleteDocumentAsync(DocumentDeleteRequest deleteRequest)
        {
            return this.client.DeleteAsync(deleteRequest);
        }

        public Task<Stream> GetPayloadAsync(DocumentPayloadRequest payloadRequest)
        {
            return this.client.GetAsync<Stream>(payloadRequest);
        }

        public Task<Document> GetDocumentAsync(DocumentRequest documentRequest)
        {
            return this.client.GetAsync<Document>(documentRequest);
        }

        public Task<Document[]> GetDocumentsAsync(DocumentCollectionRequest collectionRequest)
        {
            return this.client.GetAsync<Document[]>(collectionRequest);
        }

        public Task<int> GetDocumentCountAsync()
        {
            return this.client.GetAsync<int>(new DocumentCountRequest());
        }

        public Task<int> GetDocumentsSizeAsync(DocumentSizeRequest filter)
        {
            return this.client.GetAsync<int>(filter);
        }

        public Task<Stream> GetThumbnailAsync(DocumentThumbnailRequest thumbnailRequest)
        {
            return this.client.GetAsync<Stream>(thumbnailRequest);
        }

        public Task UpdateDocumentAsync(DocumentAddRequest documentRequest)
        {
            return this.client.PutAsync(documentRequest);
        }

        public Task UpdateDocumentContentAsync(DocumentUpdatePayloadRequest payloadRequest)
        {
            return this.client.PostAsync(payloadRequest);
        }

        #endregion

        #region Tags

        public Task AddTagAsync(TagAddRequest addRequest)
        {
            return this.client.PostAsync(addRequest);
        }

        public Task DeleteTagAsync(TagDeleteRequest deleteRequest)
        {
            return this.client.DeleteAsync(deleteRequest);
        }

        public Task<Tag> GetTagAsync(TagRequest request)
        {
            return this.client.GetAsync<Tag>(request);
        }

        public Task<Tag[]> GetTagsAsync(TagCollectionRequest collectionRequest)
        {
            return this.client.GetAsync<Tag[]>(collectionRequest);
        }

        public Task<int> GetTagCountAsync()
        {
            return this.client.GetAsync<int>(new TagCountRequest());
        }

        public Task UpdateTagAsync(TagAddRequest updateRequest)
        {
            return this.client.PutAsync(updateRequest);
        }

        #endregion

        #region Users

        public Task AddUserAsync(UserAddRequest addRequest)
        {
            return this.client.PostAsync(addRequest);
        }

        public Task DeleteUserAsync(UserDeleteRequest deleteRequest)
        {
            return this.client.DeleteAsync(deleteRequest);
        }

        public Task<User> GetUserAsync(UserRequest request)
        {
            return this.client.GetAsync<User>(request);
        }

        public Task<User[]> GetUsersAsync(UserCollectionRequest collectionRequest)
        {
            return this.client.GetAsync<User[]>(collectionRequest);
        }

        public Task<int> GetUserCountAsync()
        {
            return this.client.GetAsync<int>(new UserCountRequest());
        }

        public Task UpdateUserAsync(UserAddRequest updateRequest)
        {
            return this.client.PutAsync(updateRequest);
        }

        #endregion
    }
}
