using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using Docular.Client.Rest.Requests;
using PCLStorage;
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
        private readonly JsonServiceClient client = new JsonServiceClient();

        /// <summary>
        /// The <see cref="ICache"/> used to cache the payloads and thumbnails.
        /// </summary>
        private readonly ICache cache;

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="apiUri">The base URL of the remote docular host's API.</param>
        public DocularClient(String apiUri)
            : this(apiUri, new DocularCache())
        {
            Contract.Requires<ArgumentNullException>(apiUri != null);
        }

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="apiUri">The base URL of the remote docular host's API.</param>
        /// <param name="cache">The <see cref="ICache"/> used to cache thumbnails and payloads.</param>
        public DocularClient(String apiUri, ICache cache)
        {
            Contract.Requires<ArgumentNullException>(apiUri != null && cache != null);

            this.cache = cache;
            this.client.BaseUri = apiUri;
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
            return this.GetPayloadAsync(payloadRequest, false);
        }

        public async Task<Stream> GetPayloadAsync(DocumentPayloadRequest payloadRequest, bool allowCached)
        {
            if (allowCached)
            {
                return await this.cache.Get(payloadRequest.Id, "Payloads") ?? await this.GetPayloadAsync(payloadRequest, false);
            }
            else
            {
                Stream payloadStream = await this.client.GetAsync<Stream>(payloadRequest);
                if (payloadStream != null)
                {
                    await this.cache.Add(payloadRequest.Id, payloadStream, "Payloads");
                }
                return payloadStream;
            }
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
            return this.GetThumbnailAsync(thumbnailRequest, false);
        }

        public async Task<Stream> GetThumbnailAsync(DocumentThumbnailRequest thumbnailRequest, bool allowCached)
        {
            if (allowCached)
            {
                return await this.cache.Get(thumbnailRequest.Id, "Thumbnails") ?? await this.GetThumbnailAsync(thumbnailRequest, false);
            }
            else
            {
                Stream thumbnailStream = await this.client.GetAsync<Stream>(thumbnailRequest);
                if (thumbnailStream != null)
                {
                    await this.cache.Add(thumbnailRequest.Id, thumbnailStream, "Thumbnails");
                }
                return thumbnailStream;
            }
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

        public Task<User> GetCurrentUserAsync()
        {
            return this.client.GetAsync<User>(new UserCurrentRequest());
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
