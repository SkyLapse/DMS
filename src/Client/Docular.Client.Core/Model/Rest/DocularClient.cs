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

        public Task DeleteDocumentAsync(String documentId)
        {
            return this.PerformDeleteRequest(documentId, DocumentsId);
        }

        public Task<Stream> GetContentAsync(String documentId)
        {
            RestRequest contentRequest = new RestRequest(DocumentsIdContent, HttpMethod.Get);
            contentRequest.AddUrlSegment("id", documentId);
            return this.ThrowIfErroneous(this.restClient.Execute<Stream>(contentRequest));
        }

        public Task<Document> GetDocumentAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<Document>(id, DocumentsId);
        }

        public Task<Document[]> GetDocumentsAsync(String userId = null, String categoryId = null, String tagId = null)
        {
            return this.PerformFilteredRetreiveRequest<Document>(Documents, userId: userId, categoryId: categoryId, tagId: tagId);
        }

        public Task<int> GetDocumentCountAsync()
        {
            return this.PerformCountRequest(DocumentsCount);
        }

        public Task<Stream> GetThumbnailAsync(String documentId)
        {
            RestRequest thumbnailRequest = new RestRequest(DocumentsIdThumbnail, HttpMethod.Get);
            thumbnailRequest.AddUrlSegment("id", documentId);
            return this.ThrowIfErroneous(this.restClient.Execute<Stream>(thumbnailRequest));
        }

        public Task PostDocumentAsync(Document document)
        {
            return this.PerformPostRequest(document, Documents);
        }

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

        public Task DeleteCategoryAsync(String categoryId)
        {
            return this.PerformDeleteRequest(categoryId, CategoriesId);
        }

        public Task<Category> GetCategoryAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<Category>(id, CategoriesId);
        }

        public Task<Category[]> GetCategoriesAsync(String userId = null, String parentId = null)
        {
            return this.PerformFilteredRetreiveRequest<Category>(Categories, userId: userId, categoryId: parentId);
        }

        public Task<int> GetCategoryCountAsync()
        {
            return this.PerformCountRequest(CategoriesCount);
        }

        public Task PostCategoryAsync(Category category)
        {
            return this.PerformPostRequest(category, Categories);
        }

        public Task PutCategoryAsync(Category category)
        {
            return this.PerformPutRequest(category, CategoriesId);
        }

        #endregion

        #region Tags

        public Task DeleteTagAsync(String tagId)
        {
            return this.PerformDeleteRequest(tagId, TagsId);
        }

        public Task<Tag> GetTagAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<Tag>(id, TagsId);
        }

        public Task<Tag[]> GetTagsAsync(String userId = null)
        {
            return this.PerformFilteredRetreiveRequest<Tag>(Tags, userId: userId);
        }

        public Task<int> GetTagCountAsync()
        {
            return this.PerformCountRequest(TagsCount);
        }

        public Task PostTagAsync(Tag tag)
        {
            return this.PerformPostRequest(tag, Tags);
        }

        public Task PutTagAsync(Tag tag)
        {
            return this.PerformPutRequest(tag, TagsId);
        }

        #endregion

        #region Users

        public Task DeleteUserAsync(String userId)
        {
            return this.PerformDeleteRequest(userId, UsersId);
        }

        public Task<User> GetUserAsync(String id)
        {
            return this.PerformSingleRetreiveRequest<User>(id, UsersId);
        }

        public Task<int> GetUserCountAsync()
        {
            return this.PerformCountRequest(UsersCount);
        }

        public Task PostUserAsync(User user)
        {
            return this.PerformPostRequest(user, Users);
        }

        public Task PutUserAsync(User user)
        {
            return this.PerformPutRequest(user, UsersId);
        }

        #endregion

        #region Request DRY-Methods

        private Task PerformDeleteRequest(String id, String apiUrl)
        {
            RestRequest deleteRequest = new RestRequest(UsersId, HttpMethod.Get);
            deleteRequest.AddUrlSegment("id", id);
            return this.ThrowIfErroneous(this.restClient.Execute(deleteRequest));
        }

        private Task<T> PerformSingleRetreiveRequest<T>(String id, String apiUrl)
        {
            RestRequest retreiveRequest = new RestRequest(apiUrl, HttpMethod.Get);
            retreiveRequest.AddUrlSegment("id", id);
            return this.ThrowIfErroneous(this.restClient.Execute<T>(retreiveRequest));
        }

        private Task<T[]> PerformFilteredRetreiveRequest<T>(String apiUrl, String userId = null, String categoryId = null, String tagId = null)
        {
            RestRequest filteredRequest = new RestRequest(apiUrl, HttpMethod.Get);
            filteredRequest.AddParameter("user", userId, ParameterType.GetOrPost);
            filteredRequest.AddParameter("category", categoryId, ParameterType.GetOrPost);
            filteredRequest.AddParameter("tag", tagId, ParameterType.GetOrPost);
            return this.ThrowIfErroneous(this.restClient.Execute<T[]>(filteredRequest));
        }

        private Task<int> PerformCountRequest(String apiUrl)
        {
            RestRequest countRequest = new RestRequest(apiUrl, HttpMethod.Get);
            return this.ThrowIfErroneous(this.restClient.Execute<int>(countRequest));
        }

        private Task PerformPostRequest(DocularObject value, String apiUrl)
        {
            RestRequest postRequest = new RestRequest(apiUrl, HttpMethod.Post);
            postRequest.AddBody(value);
            return this.ThrowIfErroneous(this.restClient.Execute(postRequest));
        }

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
