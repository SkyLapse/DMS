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
        #region API constants

        /// <summary>
        /// The part of the REST url specifying an ID.
        /// </summary>
        private const String IdUrlPath = "/{id}";

        /// <summary>
        /// The part of the REST url for retreiving a collection's count.
        /// </summary>
        private const String CountUrlPath = "/count";

        /// <summary>
        /// The sub path for categories.
        /// </summary>
        public const String Categories = "categories";

        /// <summary>
        /// The sub path for a category by ID.
        /// </summary>
        public const String CategoriesId = Categories + IdUrlPath;

        /// <summary>
        /// The sub path for the amount of categores.
        /// </summary>
        public const String CategoriesCount = Categories + CountUrlPath;

        /// <summary>
        /// The sub path for documents.
        /// </summary>
        public const String Documents = "documents";

        /// <summary>
        /// The sub path for the amount of documents.
        /// </summary>
        public const String DocumentsCount = Documents + CountUrlPath;

        /// <summary>
        /// The sub path for a document by ID.
        /// </summary>
        public const String DocumentsId = Documents + IdUrlPath;

        /// <summary>
        /// The sub path for a documents content by ID.
        /// </summary>
        public const String DocumentsIdContent = DocumentsId + "/content";

        /// <summary>
        /// The sub path for a documents thumbnail by ID.
        /// </summary>
        public const String DocumentsIdThumbnail = DocumentsId + "/thumbnail";

        /// <summary>
        /// The sub path for tags.
        /// </summary>
        public const String Tags = "tags";

        /// <summary>
        /// The sub path for a tag by ID.
        /// </summary>
        public const String TagsId = Categories + IdUrlPath;

        /// <summary>
        /// The sub path for the amount of tags.
        /// </summary>
        public const String TagsCount = Categories + CountUrlPath;

        /// <summary>
        /// The sub path for users.
        /// </summary>
        public const String Users = "users";

        /// <summary>
        /// The sub path for a user by ID.
        /// </summary>
        public const String UsersId = Categories + IdUrlPath;

        /// <summary>
        /// The sub path for the amount of users.
        /// </summary>
        public const String UsersCount = Categories + CountUrlPath;

        #endregion

        /// <summary>
        /// The <see cref="IContentReceiver"/> used to obtain a <see cref="Document"/>s content.
        /// </summary>
        private IContentReceiver contentReceiver = null;

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
        /// <param name="contentReceiver">The <see cref="IContentReceiver"/> used to obtain a <see cref="Document"/>s content.</param>
        public DocularClient(String docularUri, IKeyStore keyStore, IContentReceiver contentReceiver)
            : this(new Uri(docularUri), keyStore, contentReceiver)
        {
            Contract.Requires<ArgumentNullException>(docularUri != null && keyStore != null && contentReceiver != null);
        }

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="docularUri">The adress of the remote host.</param>
        /// <param name="keyStore">A <see cref="IKeyStore"/> used to obtain the key.</param>
        /// <param name="contentReceiver">The <see cref="IContentReceiver"/> used to obtain a <see cref="Document"/>s content.</param>
        public DocularClient(Uri docularUri, IKeyStore keyStore, IContentReceiver contentReceiver)
        {
            Contract.Requires<ArgumentNullException>(docularUri != null && keyStore != null && contentReceiver != null);
            Contract.Requires<ArgumentException>(!docularUri.IsFile);
            Contract.Requires<ArgumentException>(docularUri.AbsoluteUri.EndsWith("/api") || docularUri.AbsoluteUri.EndsWith("/api/"));
            Contract.Requires<ArgumentException>(docularUri.Scheme == "https");

            this.contentReceiver = contentReceiver;
            this.DocularUri = docularUri;
            this.restClient.BaseUrl = this.DocularUri;
            this.restClient.Authenticator = new DocularAuthenticator(keyStore);
        }

        #region Documents

        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        public Task DeleteDocumentAsync(String documentId)
        {
            return this.PerformDeleteRequest(documentId, DocumentsId);
        }

        /// <summary>
        /// Gets the <see cref="Document"/>'s content.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the content of.</param>
        /// <returns>The <see cref="Document"/>'s content.</returns>
        public Task<Stream> GetContentAsync(String documentId)
        {
            RestRequest contentRequest = new RestRequest(DocumentsIdContent, HttpMethod.Get);
            contentRequest.AddUrlSegment("id", documentId);
            return this.ThrowIfErroneous(this.restClient.Execute<Stream>(contentRequest));
        }

        /// <summary>
        /// Gets the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Document"/> to obtain.</param>
        /// <returns>The <see cref="Document"/> with the specified ID, or <c>null</c> if the <see cref="Document"/> was not found.</returns>
        public Task<Document> GetDocumentAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<Document>(id, DocumentsId);
        }

        /// <summary>
        /// Gets a filtered list of <see cref="Document"/>s that match the specified criteria.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> who created the <see cref="Document"/>.</param>
        /// <param name="categoryId">The ID of the <see cref="Category"/> the <see cref="Document"/> belongs to.</param>
        /// <param name="tagId">The ID of a <see cref="Tag"/> of the <see cref="Document"/>.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        public Task<Document[]> GetDocumentsAsync(String userId = null, String categoryId = null, String tagId = null)
        {
            return this.PerformFilteredRetreiveRequest<Document>(Documents, userId: userId, categoryId: categoryId, tagId: tagId);
        }

        /// <summary>
        /// Gets the amount of stored <see cref="Document"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Document"/>s.</returns>
        public Task<int> GetDocumentCountAsync()
        {
            return this.PerformCountRequest(DocumentsCount);
        }

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the thumbnail of.</param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        public Task<Stream> GetThumbnailAsync(String documentId)
        {
            RestRequest thumbnailRequest = new RestRequest(DocumentsIdThumbnail, HttpMethod.Get);
            thumbnailRequest.AddUrlSegment("id", documentId);
            return this.ThrowIfErroneous(this.restClient.Execute<Stream>(thumbnailRequest));
        }

        /// <summary>
        /// Uploads the specified new <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task PostDocumentAsync(Document document)
        {
            return this.PerformPostRequest(document, Documents);
        }

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task PutDocumentAsync(Document document)
        {
            RestRequest categoryRequest = new RestRequest(DocumentsId, HttpMethod.Put);
            categoryRequest.AddUrlSegment("id", document.Id);
            categoryRequest.AddBody(document);
            categoryRequest.AddFile("content", this.contentReceiver.GetLocalContent(document), this.contentReceiver.GetFileName(document));
            return this.ThrowIfErroneous(this.restClient.Execute(categoryRequest));
        }

        #endregion

        #region Categories

        /// <summary>
        /// Asynchronously deletes the specified <see cref="Category"/>.
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        public Task DeleteCategoryAsync(String categoryId)
        {
            return this.PerformDeleteRequest(categoryId, CategoriesId);
        }

        /// <summary>
        /// Gets the <see cref="Category"/> with the specified ID.
        /// </summary>
        /// <param name="id">The id of the <see cref="Category"/> to get.</param>
        /// <returns>The <see cref="Category"/> with the specified ID, or <c>null</c> if it was not found.</returns>
        public Task<Category> GetCategoryAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<Category>(id, CategoriesId);
        }

        /// <summary>
        /// Gets all <see cref="Category"/>s that match the specified criteria.
        /// </summary>
        /// <param name="userId">
        /// The ID of the <see cref="User"/> who created the <see cref="Category"/>. If null is specified, there will be no filtering.
        /// </param>
        /// <param name="parentId">
        /// The ID of the parent <see cref="Category"/> it has to be a child of. If null is specified, there will be no filtering.
        /// </param>
        /// <returns></returns>
        public Task<Category[]> GetCategoriesAsync(String userId = null, String parentId = null)
        {
            return this.PerformFilteredRetreiveRequest<Category>(Categories, userId: userId, categoryId: parentId);
        }

        /// <summary>
        /// Gets the amount of <see cref="Category"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Category"/>s.</returns>
        public Task<int> GetCategoryCountAsync()
        {
            return this.PerformCountRequest(CategoriesCount);
        }

        /// <summary>
        /// Uploads a new <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task PostCategoryAsync(Category category)
        {
            return this.PerformPostRequest(category, Categories);
        }

        /// <summary>
        /// Uploads a changed <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task PutCategoryAsync(Category category)
        {
            return this.PerformPutRequest(category, CategoriesId);
        }

        #endregion

        #region Tags

        /// <summary>
        /// Deletes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="tagId">The ID of the <see cref="Tag"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        public Task DeleteTagAsync(String tagId)
        {
            return this.PerformDeleteRequest(tagId, TagsId);
        }

        /// <summary>
        /// Gets the <see cref="Tag"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Tag"/> to get.</param>
        /// <returns>The <see cref="Task"/> with the ID, or <c>null</c> if the <see cref="Tag"/> could not be found.</returns>
        public Task<Tag> GetTagAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<Tag>(id, TagsId);
        }

        /// <summary>
        /// Gets a filtered collection of <see cref="Tag"/>s.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> who created the <see cref="Tag"/>.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        public Task<Tag[]> GetTagsAsync(String userId = null)
        {
            return this.PerformFilteredRetreiveRequest<Tag>(Tags, userId: userId);
        }

        /// <summary>
        /// Gets the amount of <see cref="Tag"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="Tag"/>s in the DB.</returns>
        public Task<int> GetTagCountAsync()
        {
            return this.PerformCountRequest(TagsCount);
        }

        /// <summary>
        /// Uploads a new <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        public Task PostTagAsync(Tag tag)
        {
            return this.PerformPostRequest(tag, Tags);
        }

        /// <summary>
        /// Uploads a changed <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        public Task PutTagAsync(Tag tag)
        {
            return this.PerformPutRequest(tag, TagsId);
        }

        #endregion

        #region Users

        /// <summary>
        /// Deletes a <see cref="User"/> from the DB.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        public Task DeleteUserAsync(String userId)
        {
            return this.PerformDeleteRequest(userId, UsersId);
        }

        /// <summary>
        /// Gets the <see cref="User"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="User"/> to obtain.</param>
        /// <returns>The <see cref="User"/> with the specified ID, or <c>null</c> if the user was not found.</returns>
        public Task<User> GetUserAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<User>(id, UsersId);
        }

        /// <summary>
        /// Gets the amount of <see cref="User"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="User"/>s.</returns>
        public Task<int> GetUserCountAsync()
        {
            return this.PerformCountRequest(UsersCount);
        }

        /// <summary>
        /// Uploads a new <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task PostUserAsync(User user)
        {
            return this.PerformPostRequest(user, Users);
        }

        /// <summary>
        /// Uploads a changed <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task PutUserAsync(User user)
        {
            return this.PerformPutRequest(user, UsersId);
        }

        #endregion

        #region Request DRY-Methods

        /// <summary>
        /// Performs a DELETE request to the specified URL with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <param name="apiUrl">The URL to send the request to.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous request.</returns>
        private Task PerformDeleteRequest(String id, String apiUrl)
        {
            RestRequest deleteRequest = new RestRequest(UsersId, HttpMethod.Get);
            deleteRequest.AddUrlSegment("id", id);
            return this.ThrowIfErroneous(this.restClient.Execute(deleteRequest));
        }

        /// <summary>
        /// Performs a GET request to the specified URL with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the item to get.</param>
        /// <param name="apiUrl">The URL to send the request to.</param>
        /// <returns>A <see cref="Task{T}"/> describing the asynchronous request.</returns>
        private Task<T> PerformSingleRetreiveRequest<T>(String id, String apiUrl)
        {
            RestRequest retreiveRequest = new RestRequest(apiUrl, HttpMethod.Get);
            retreiveRequest.AddUrlSegment("id", id);
            return this.ThrowIfErroneous(this.restClient.Execute<T>(retreiveRequest));
        }

        /// <summary>
        /// Performs a GET request to the specified URL with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> who created the item.</param>
        /// <param name="categoryId">The ID of the <see cref="Category"/> the item belongs to.</param>
        /// <param name="tagId">The ID of a <see cref="Tag"/> of the item.</param>
        /// <param name="apiUrl">The URL to send the request to.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous request.</returns>
        private Task<T[]> PerformFilteredRetreiveRequest<T>(String apiUrl, String userId = null, String categoryId = null, String tagId = null)
        {
            RestRequest filteredRequest = new RestRequest(apiUrl, HttpMethod.Get);
            filteredRequest.AddParameter("user", userId, ParameterType.GetOrPost);
            filteredRequest.AddParameter("category", categoryId, ParameterType.GetOrPost);
            filteredRequest.AddParameter("tag", tagId, ParameterType.GetOrPost);
            return this.ThrowIfErroneous(this.restClient.Execute<T[]>(filteredRequest));
        }

        /// <summary>
        /// Counts the items whose API URL is <paramref name="apiUrl"/>.
        /// </summary>
        /// <param name="apiUrl">The API URL of the items to count.</param>
        /// <returns>The item count..</returns>
        private Task<int> PerformCountRequest(String apiUrl)
        {
            RestRequest countRequest = new RestRequest(apiUrl, HttpMethod.Get);
            return this.ThrowIfErroneous(this.restClient.Execute<int>(countRequest));
        }

        /// <summary>
        /// POSTs the specified <see cref="DocularObject"/> to the specified <paramref name="apiUrl"/>.
        /// </summary>
        /// <param name="value">The <see cref="DocularObject"/> to post.</param>
        /// <param name="apiUrl">The URL of the API to post to.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous POSTing process.</returns>
        private Task PerformPostRequest(DocularObject value, String apiUrl)
        {
            RestRequest postRequest = new RestRequest(apiUrl, HttpMethod.Post);
            postRequest.AddBody(value);
            return this.ThrowIfErroneous(this.restClient.Execute(postRequest));
        }

        /// <summary>
        /// PUTs the specified <see cref="DocularObject"/> to the specified <paramref name="apiUrl"/>.
        /// </summary>
        /// <param name="value">The <see cref="DocularObject"/> to put.</param>
        /// <param name="apiUrl">The URL of the API to send a PUT request to.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous PUTting process.</returns>
        private Task PerformPutRequest(DocularObject value, String apiUrl)
        {
            RestRequest categoryRequest = new RestRequest(apiUrl, HttpMethod.Put);
            categoryRequest.AddUrlSegment("id", value.Id);
            categoryRequest.AddBody(value);
            return this.ThrowIfErroneous(this.restClient.Execute(categoryRequest));
        }

        #endregion

        /// <summary>
        /// Throws an <see cref="HttpException"/> if the specified <see cref="IRestResponse"/> represents an error.
        /// </summary>
        /// <param name="responseTask">The <see cref="IRestResponse"/> to check for errors.</param>
        private async Task ThrowIfErroneous(Task<IRestResponse> responseTask)
        {
            Contract.Requires<ArgumentNullException>(responseTask != null);

            IRestResponse response = await responseTask;
            if (response.StatusCode.IsError())
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                    case HttpStatusCode.Forbidden:
                        throw new HttpForbiddenException();
                    case HttpStatusCode.InternalServerError:
                        throw new HttpInternalServerErrorException();
                    case HttpStatusCode.NotFound:
                        throw new HttpNotFoundException();
                    default:
                        throw new HttpException(response.StatusDescription, response.StatusCode);
                }
            }
        }

        /// <summary>
        /// Throws an <see cref="HttpException"/> if the specified <see cref="IRestResponse{T}"/> represents an error.
        /// </summary>
        /// <param name="responseTask">The <see cref="IRestResponse{T}"/> to check for errors.</param>
        /// <returns>The <see cref="IRestResponse{T}"/>s data.</returns>
        private async Task<T> ThrowIfErroneous<T>(Task<IRestResponse<T>> responseTask)
        {
            Contract.Requires<ArgumentNullException>(responseTask != null);

            IRestResponse<T> response = await responseTask;
            await this.ThrowIfErroneous(Task.FromResult((IRestResponse)response));
            return response.Data;
        }
    }
}
