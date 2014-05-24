using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using PCLStorage;
using ServiceStack;
using ServiceStack.Text;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Represents a client for working with a docular DB.
    /// </summary>
    public partial class DocularClient : IDocularClient
    {
        /// <summary>
        /// The <see cref="JsonServiceClient"/> executing the requests.
        /// </summary>
        private readonly JsonServiceClient client;

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
            this.client = new JsonServiceClient(apiUri);
        }

        #region Authorization

        /// <summary>
        /// Gets a new key from the server.
        /// </summary>
        /// <param name="machineName">The name of the current machine.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="username">The user's name.</param>
        /// <returns>A new API key.</returns>
        public Task<String> GetKey(String username, String password, String machineName)
        {
            return this.client.PostAsync<String>(new ApiKeyDto() { MachineName = machineName, Password = password, Username = username });
        }

        /// <summary>
        /// Checks whether the specified API key is still valid.
        /// </summary>
        /// <param name="key">The key to validate.</param>
        /// <returns><c>true</c> if the key is valid, otherwise <c>false</c>.</returns>
        public Task<bool> ValidateKey(String key)
        {
            return this.client.PostAsync<bool>(new ApiKeyValidateDto() { Key = key });
        }

        #endregion

        #region Categories

        /// <summary>
        /// Uploads a new <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task AddCategoryAsync(Category category)
        {
            return this.client.PostAsync((CategoryAddDto)category);
        }

        /// <summary>
        /// Asynchronously deletes the specified <see cref="Category"/>.
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        public Task DeleteCategoryAsync(String categoryId)
        {
            return this.client.DeleteAsync((CategoryDeleteDto)categoryId);
        }

        /// <summary>
        /// Gets the <see cref="Category"/> with the specified ID.
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to get.</param>
        /// <returns>The <see cref="Category"/> with the specified ID, or <c>null</c> if it was not found.</returns>
        public Task<Category> GetCategoryAsync(String categoryId)
        {
            return this.client.GetAsync<Category>((CategoryDto)categoryId);
        }

        /// <summary>
        /// Gets all <see cref="Category"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns></returns>
        public Task<Category[]> GetCategoriesAsync(CategoryCollectionParameters filter)
        {
            return this.client.GetAsync<Category[]>((CategoryCollectionDto)filter);
        }

        /// <summary>
        /// Gets the amount of <see cref="Category"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Category"/>s.</returns>
        public Task<int> GetCategoryCountAsync()
        {
            return this.client.GetAsync<int>(new CategoryCountDto());
        }

        /// <summary>
        /// Uploads a changed <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task UpdateCategoryAsync(Category category)
        {
            return this.client.PutAsync((CategoryAddDto)category);
        }

        #endregion

        #region Documents

        /// <summary>
        /// Uploads the specified new <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task AddDocumentAsync(Document document)
        {
            return this.client.PostAsync((DocumentAddDto)document);
        }

        /// <summary>
        /// Deletes the specified <see cref="Document"/> from the docular DB.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        public Task DeleteDocumentAsync(String documentId)
        {
            return this.client.DeleteAsync((DocumentDeleteDto)documentId);
        }

        /// <summary>
        /// Gets the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain..</param>
        /// <returns>The <see cref="Document"/> with the specified ID, or <c>null</c> if the <see cref="Document"/> was not found.</returns>
        public Task<Document> GetDocumentAsync(String documentId)
        {
            return this.client.GetAsync<Document>((DocumentDto)documentId);
        }

        /// <summary>
        /// Gets a filtered list of <see cref="Document"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>A collection of <see cref="Document"/>s that match the criteria.</returns>
        public Task<Document[]> GetDocumentsAsync(DocumentCollectionParameters filter)
        {
            return this.client.GetAsync<Document[]>((DocumentCollectionDto)filter);
        }

        /// <summary>
        /// Gets the amount of stored <see cref="Document"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Document"/>s.</returns>
        public Task<int> GetDocumentCountAsync()
        {
            return this.client.GetAsync<int>(new DocumentCountDto());
        }

        /// <summary>
        /// Gets the size in bytes of a specified document collection.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>The size of the selected documents in bytes.</returns>
        public Task<int> GetDocumentsSizeAsync(DocumentCollectionParameters filter)
        {
            return this.client.GetAsync<int>((DocumentSizeDto)filter);
        }

        /// <summary>
        /// Gets the <see cref="Document"/>'s payload data.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the content of.</param>
        /// <returns>The <see cref="Document"/>'s payload.</returns>
        public Task<Stream> GetPayloadAsync(String documentId)
        {
            return this.client.GetAsync<Stream>((DocumentPayloadDto)documentId);
        }

        /// <summary>
        /// Gets a <see cref="Stream"/> containing the thumbnail image of the <see cref="Document"/>.
        /// </summary>
        /// <param name="documentId">The ID of the <see cref="Document"/> to obtain the thumbnail of.</param>
        /// <param name="height">The desired width of the thumbnail. Specifying values &lt; 0 results in no resizing / cropping.</param>
        /// <param name="width">The desired height of the thumbnail. Specifying values &lt; 0 results in no resizing / cropping.</param>
        /// <returns>The <see cref="Document"/>'s thumbnail.</returns>
        public Task<Stream> GetThumbnailAsync(String documentId, int width = -1, int height = -1)
        {
            return this.client.GetAsync<Stream>(new DocumentThumbnailDto() { Width = width, Height = height, Id = documentId });
        }

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> to the server.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task UpdateDocumentAsync(Document document)
        {
            return this.client.PutAsync((DocumentAddDto)document);
        }

        /// <summary>
        /// Uploads the specified changed <see cref="Document"/> content to the server.
        /// </summary>
        /// <param name="content">The <see cref="Document"/>'s content.</param>
        /// <param name="documentId">The ID of the <see cref="Document"/> whose content is to be updated.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task UpdateDocumentContentAsync(String documentId, Stream content)
        {
            return this.client.PostAsync(new DocumentUpdatePayloadDto() { Id = documentId, File = content });
        }

        #endregion

        #region Tags

        /// <summary>
        /// Uploads a new <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        public Task AddTagAsync(Tag tag)
        {
            return this.client.PostAsync((TagAddDto)tag);
        }

        /// <summary>
        /// Removes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="tagId">The ID of the <see cref="Tag"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        public Task DeleteTagAsync(String tagId)
        {
            return this.client.DeleteAsync((TagDeleteDto)tagId);
        }

        /// <summary>
        /// Gets the <see cref="Tag"/> with the specified ID.
        /// </summary>
        /// <param name="tagId">The ID of the <see cref="Tag"/> to obtain..</param>
        /// <returns>The <see cref="Task"/> with the ID, or <c>null</c> if the <see cref="Tag"/> could not be found.</returns>
        public Task<Tag> GetTagAsync(String tagId)
        {
            return this.client.GetAsync<Tag>((TagDto)tagId);
        }

        /// <summary>
        /// Gets a filtered collection of <see cref="Tag"/>s.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        public Task<Tag[]> GetTagsAsync(TagCollectionParameters filter)
        {
            return this.client.GetAsync<Tag[]>((TagCollectionDto)filter);
        }

        /// <summary>
        /// Gets the amount of <see cref="Tag"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="Tag"/>s in the DB.</returns>
        public Task<int> GetTagCountAsync()
        {
            return this.client.GetAsync<int>(new TagCountDto());
        }

        /// <summary>
        /// Uploads a changed <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        public Task UpdateTagAsync(Tag tag)
        {
            return this.client.PutAsync((TagAddDto)tag);
        }

        #endregion

        #region Users

        /// <summary>
        /// Uploads a new <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task AddUserAsync(User user)
        {
            return this.client.PostAsync((UserAddDto)user);
        }

        /// <summary>
        /// Deletes a <see cref="User"/> from the DB.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        public Task DeleteUserAsync(String userId)
        {
            return this.client.DeleteAsync((UserDeleteDto)userId);
        }

        /// <summary>
        /// Gets the <see cref="User"/> associated with the login data.
        /// </summary>
        /// <returns>The <see cref="User"/> associated with the transmitted login data.</returns>
        public Task<User> GetCurrentUserAsync()
        {
            return this.client.GetAsync<User>(new UserCurrentDto());
        }

        /// <summary>
        /// Gets the <see cref="User"/> with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to obtain.</param>
        /// <returns>The <see cref="User"/> with the specified ID, or <c>null</c> if the user was not found.</returns>
        public Task<User> GetUserAsync(String userId)
        {
            return this.client.GetAsync<User>((UserDto)userId);
        }

        /// <summary>
        /// Gets a filtered list of <see cref="User"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>A collection of <see cref="User"/>s that match the criteria.</returns>
        public Task<User[]> GetUsersAsync(UserCollectionParameters filter)
        {
            return this.client.GetAsync<User[]>((UserCollectionDto)filter);
        }

        /// <summary>
        /// Gets the amount of <see cref="User"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="User"/>s.</returns>
        public Task<int> GetUserCountAsync()
        {
            return this.client.GetAsync<int>(new UserCountDto());
        }

        /// <summary>
        /// Uploads a changed <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The changed <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        public Task UpdateUserAsync(User user)
        {
            return this.client.PutAsync((UserAddDto)user);
        }

        #endregion

        #region DTOs

        /// <summary>
        /// Returns a single element by its ID.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of element to obtain.</typeparam>
        private abstract class IdDto<T> : IReturn<T>
        {
            /// <summary>
            /// The ID of the element to retreive.
            /// </summary>
            public String Id { get; set; }
        }

        /// <summary>
        /// Represents a REST request with an ID returning nothing..
        /// </summary>
        private abstract class IdVoidDto : IReturnVoid
        {
            /// <summary>
            /// The ID of the <see cref="Category"/> to delete.
            /// </summary>
            public String Id { get; set; }
        }

        #region Authorization

        /// <summary>
        /// A REST request used to obtain a new key.
        /// </summary>
        [Route("/keys", "POST")]
        private class ApiKeyDto : IReturn<String>
        {
            /// <summary>
            /// The current machine name.
            /// </summary>
            public String MachineName { get; set; }

            /// <summary>
            /// The username of the user to obtain an API key of.
            /// </summary>
            public String Username { get; set; }

            /// <summary>
            /// The user's password.
            /// </summary>
            public String Password { get; set; }
        }

        /// <summary>
        /// A REST request used for validating an existing API key.
        /// </summary>
        [Route("/keys/validate", "POST")]
        private class ApiKeyValidateDto : IReturn<bool>
        {
            /// <summary>
            /// The api key to validate.
            /// </summary>
            public String Key { get; set; }
        }

        #endregion

        #region Categories

        /// <summary>
        /// The REST request to add (or update) a <see cref="Document"/> to the remote DB.
        /// </summary>
        [Route("/categories", "POST")]
        [Route("/categories/{Id}", "PUT")]
        private class CategoryAddDto : IReturnVoid
        {
            /// <summary>
            /// The <see cref="Category"/> to add.
            /// </summary>
            public Category Category { get; set; }

            /// <summary>
            /// The <see cref="Category"/>s Id.
            /// </summary>
            /// <remarks>Will be fetched from the <see cref="P:Category"/>-property.</remarks>
            public String Id
            {
                get
                {
                    Category category = this.Category;
                    return (category != null) ? category.Id : null;
                }
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="Category"/> into a <see cref="CategoryAddDto"/>.
            /// </summary>
            /// <param name="category">The <see cref="Category"/> to create a <see cref="CategoryAddDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator CategoryAddDto(Category category)
            {
                return (category != null) ? new CategoryAddDto() { Category = category } : null;
            }
        }

        /// <summary>
        /// Contains filtering parameters for a <see cref="Category"/> request.
        /// </summary>
        [Route("/categories", "GET")]
        private class CategoryCollectionDto : CategoryCollectionParameters, IReturn<Category[]> { }

        /// <summary>
        /// The REST request used to count all categories.
        /// </summary>
        [Route("/categories/count", "GET")]
        private class CategoryCountDto : IReturn<int> { }

        /// <summary>
        /// The REST-Request for deleting a specific <see cref="Category"/>.
        /// </summary>
        [Route("/categories/{Id}", "DELETE")]
        private class CategoryDeleteDto : IdVoidDto
        {
            /// <summary>
            /// Implicitly converts the <see cref="Category"/> into a <see cref="CategoryDeleteDto"/>.
            /// </summary>
            /// <param name="category">The <see cref="Category"/> to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator CategoryDeleteDto(Category category)
            {
                return (category != null) ? new CategoryDeleteDto() { Id = category.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the category ID into a <see cref="CategoryDeleteDto"/>.
            /// </summary>
            /// <param name="id">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator CategoryDeleteDto(String id)
            {
                return (id != null) ? new CategoryDeleteDto() { Id = id } : null;
            }
        }

        /// <summary>
        /// The REST request used to retreive a single <see cref="Category"/>.
        /// </summary>
        [Route("/categories/{Id}", "GET")]
        private class CategoryDto : IdDto<Category>
        {
            /// <summary>
            /// Implicitly converts the specified <see cref="Category"/>-ID into a <see cref="CategoryDto"/>.
            /// </summary>
            /// <param name="categoryId">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator CategoryDto(String categoryId)
            {
                return (categoryId != null) ? new CategoryDto() { Id = categoryId } : null;
            }
        }

        #endregion

        #region Documents

        /// <summary>
        /// The REST request to add (or update) a <see cref="Document"/> to the remote DB.
        /// </summary>
        [Route("/documents", "POST")]
        [Route("/documents/{Id}", "PUT")]
        private class DocumentAddDto : IReturnVoid
        {
            /// <summary>
            /// The <see cref="Document"/> to add.
            /// </summary>
            public Document Document { get; set; }

            /// <summary>
            /// The <see cref="Document"/>s Id.
            /// </summary>
            /// <remarks>Will be fetched from the <see cref="P:Document"/>-property.</remarks>
            public String Id
            {
                get
                {
                    Document document = this.Document;
                    return (document != null) ? document.Id : null;
                }
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="Document"/> into a <see cref="DocumentAddDto"/>.
            /// </summary>
            /// <param name="document">The <see cref="Document"/> to create a <see cref="DocumentAddDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentAddDto(Document document)
            {
                return (document != null) ? new DocumentAddDto() { Document = document } : null;
            }
        }

        /// <summary>
        /// Contains filtering parameters for a <see cref="Document"/> collection request.
        /// </summary>
        [DataContract]
        [Route("/documents", "GET")]
        private class DocumentCollectionDto : DocumentCollectionParameters, IReturn<Document[]> { }

        /// <summary>
        /// The REST request used to count all tags.
        /// </summary>
        [Route("/documents/count", "GET")]
        private class DocumentCountDto : IReturn<int> { }
        
        /// <summary>
        /// The REST-Request for deleting a specific <see cref="Tag"/>.
        /// </summary>
        [Route("/documents/{Id}", "DELETE")]
        private class DocumentDeleteDto : IdVoidDto
        {
            /// <summary>
            /// Implicitly converts the <see cref="Category"/> into a <see cref="DocumentDeleteDto"/>.
            /// </summary>
            /// <param name="document">The <see cref="Document"/> to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentDeleteDto(Document document)
            {
                return (document != null) ? new DocumentDeleteDto() { Id = document.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the tag ID into a <see cref="DocumentDeleteDto"/>.
            /// </summary>
            /// <param name="id">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentDeleteDto(String id)
            {
                return (id != null) ? new DocumentDeleteDto() { Id = id } : null;
            }
        }

        /// <summary>
        /// Retreives a single <see cref="Document"/> by its ID.
        /// </summary>
        [Route("/documents/{Id}", "GET")]
        private class DocumentDto : IdDto<Document>
        {
            /// <summary>
            /// Implicitly converts the specified <see cref="Document"/>-ID into a <see cref="DocumentDto"/>.
            /// </summary>
            /// <param name="documentId">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentDto(String documentId)
            {
                return (documentId != null) ? new DocumentDto() { Id = documentId } : null;
            }
        }

        /// <summary>
        /// The REST request used to obtain a <see cref="Document"/>'s payload
        /// </summary>
        [Route("/documents/{Id}/payload", "GET")]
        private class DocumentPayloadDto : IdDto<Stream>
        {
            /// <summary>
            /// Implicitly converts the specified <see cref="Document"/> into a <see cref="DocumentPayloadDto"/>.
            /// </summary>
            /// <param name="document">The <see cref="Document"/> to create a <see cref="DocumentPayloadDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentPayloadDto(Document document)
            {
                return (document != null) ? new DocumentPayloadDto() { Id = document.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="Document"/> ID into a <see cref="DocumentPayloadDto"/>.
            /// </summary>
            /// <param name="documentId">The <see cref="Document"/> ID to create a <see cref="DocumentPayloadDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentPayloadDto(String documentId)
            {
                return (documentId != null) ? new DocumentPayloadDto() { Id = documentId } : null;
            }
        }

        /// <summary>
        /// Contains filtering parameters for a <see cref="Document"/> collection request.
        /// </summary>
        [Route("/documents/size", "GET")]
        private class DocumentSizeDto : DocumentCollectionParameters, IReturn<int> { }

        /// <summary>
        /// The REST request used to obtain a <see cref="Document"/>'s payload
        /// </summary>
        [Route("/documents/{Id}/thumbnail", "GET")]
        private class DocumentThumbnailDto : IdDto<Stream>
        {
            /// <summary>
            /// Backing field.
            /// </summary>
            private int _Height = -1;

            /// <summary>
            /// The thumbnail's desired height.
            /// </summary>
            public int Height
            {
                get
                {
                    return _Height;
                }
                set
                {
                    _Height = value;
                }
            }

            /// <summary>
            /// Backing field.
            /// </summary>
            private int _Width = -1;

            /// <summary>
            /// The thumbnail's desired width.
            /// </summary>
            public int Width
            {
                get
                {
                    return _Width;
                }
                set
                {
                    _Width = value;
                }
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="Document"/> into a <see cref="DocumentThumbnailDto"/>.
            /// </summary>
            /// <param name="document">The <see cref="Document"/> to create a <see cref="DocumentThumbnailDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentThumbnailDto(Document document)
            {
                return (document != null) ? new DocumentThumbnailDto() { Id = document.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="Document"/> ID into a <see cref="DocumentThumbnailDto"/>.
            /// </summary>
            /// <param name="documentId">The <see cref="Document"/> ID to create a <see cref="DocumentThumbnailDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentThumbnailDto(String documentId)
            {
                return (documentId != null) ? new DocumentThumbnailDto() { Id = documentId } : null;
            }
        }

        /// <summary>
        /// Updates a <see cref="Docular.Client.Model.Document"/>'s payload.
        /// </summary>
        [Route("/documents/{Id}/payload", "POST")]
        private class DocumentUpdatePayloadDto : IdVoidDto
        {
            /// <summary>
            /// The new payload.
            /// </summary>
            public Stream File { get; set; }
        }

        #endregion

        #region Tags

        /// <summary>
        /// The REST request for adding (or updating) a <see cref="Tag"/> to the remote DB.
        /// </summary>
        [Route("/tags", "POST")]
        [Route("/tags/{Id}", "PUT")]
        private class TagAddDto : IReturnVoid
        {
            /// <summary>
            /// The <see cref="Category"/> to add.
            /// </summary>
            public Tag Tag { get; set; }

            /// <summary>
            /// The <see cref="Category"/>s Id.
            /// </summary>
            /// <remarks>Will be fetched from the <see cref="P:Tag"/>-property.</remarks>
            public String Id
            {
                get
                {
                    Tag tag = this.Tag;
                    return (tag != null) ? tag.Id : null;
                }
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="Tag"/> into a <see cref="TagAddDto"/>.
            /// </summary>
            /// <param name="tag">The <see cref="Tag"/> to create a <see cref="TagAddDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator TagAddDto(Tag tag)
            {
                return (tag != null) ? new TagAddDto() { Tag = tag } : null;
            }
        }

        /// <summary>
        /// Contains filtering parameters for a <see cref="Tag"/> request.
        /// </summary>
        [Route("/tags", "GET")]
        private class TagCollectionDto : TagCollectionParameters, IReturn<Tag[]> { }

        /// <summary>
        /// The REST request used to count all tags.
        /// </summary>
        [Route("/tags/count", "GET")]
        private class TagCountDto : IReturn<int> { }

        /// <summary>
        /// The REST-Request for deleting a specific <see cref="Tag"/>.
        /// </summary>
        [Route("/tags/{Id}", "DELETE")]
        private class TagDeleteDto : IdVoidDto
        {
            /// <summary>
            /// Implicitly converts the <see cref="Category"/> into a <see cref="TagDeleteDto"/>.
            /// </summary>
            /// <param name="tag">The <see cref="Tag"/> to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator TagDeleteDto(Tag tag)
            {
                return (tag != null) ? new TagDeleteDto() { Id = tag.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the tag ID into a <see cref="TagDeleteDto"/>.
            /// </summary>
            /// <param name="id">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator TagDeleteDto(String id)
            {
                return (id != null) ? new TagDeleteDto() { Id = id } : null;
            }
        }

        /// <summary>
        /// The REST request used to retreive a single <see cref="Tag"/>.
        /// </summary>
        [Route("/tags/{Id}", "GET")]
        private class TagDto : IdDto<Tag>
        {
            /// <summary>
            /// Implicitly converts the specified <see cref="Tag"/>-ID into a <see cref="TagDto"/>.
            /// </summary>
            /// <param name="tagId">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator TagDto(String tagId)
            {
                return (tagId != null) ? new TagDto() { Id = tagId } : null;
            }
        }

        #endregion

        #region Users

        /// <summary>
        /// The REST request for adding (or updating) a <see cref="User"/> to the remote DB.
        /// </summary>
        [Route("/users", "POST")]
        [Route("/users/{Id}", "PUT")]
        private class UserAddDto : IReturnVoid
        {
            /// <summary>
            /// The <see cref="Category"/> to add.
            /// </summary>
            public User User { get; set; }

            /// <summary>
            /// The <see cref="Category"/>s Id.
            /// </summary>
            /// <remarks>Will be fetched from the <see cref="P:User"/>-property.</remarks>
            public String Id
            {
                get
                {
                    User user = this.User;
                    return (user != null) ? user.Id : null;
                }
            }

            /// <summary>
            /// Implicitly converts the specified <see cref="User"/> into a <see cref="UserAddDto"/>.
            /// </summary>
            /// <param name="user">The <see cref="User"/> to create a <see cref="UserAddDto"/> from.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator UserAddDto(User user)
            {
                return (user != null) ? new UserAddDto() { User = user } : null;
            }
        }

        /// <summary>
        /// Contains filtering parameters for a <see cref="User"/> request.
        /// </summary>
        [Route("/users", "GET")]
        private class UserCollectionDto : UserCollectionParameters, IReturn<User[]> { }

        /// <summary>
        /// The REST request used to count all users.
        /// </summary>
        [Route("/users/count", "GET")]
        private class UserCountDto : IReturn<int> { }

        /// <summary>
        /// Represents a REST request obtaining the <see cref="User"/> associated with the current login data.
        /// </summary>
        [Route("/users/current", "GET")]
        private class UserCurrentDto : IReturn<User> { }

        /// <summary>
        /// The REST-Request for deleting a specific <see cref="User"/>.
        /// </summary>
        [Route("/users/{Id}", "DELETE")]
        private class UserDeleteDto : IdVoidDto
        {
            /// <summary>
            /// Implicitly converts the <see cref="Category"/> into a <see cref="UserDeleteDto"/>.
            /// </summary>
            /// <param name="user">The <see cref="User"/> to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator UserDeleteDto(User user)
            {
                return (user != null) ? new UserDeleteDto() { Id = user.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the User ID into a <see cref="UserDeleteDto"/>.
            /// </summary>
            /// <param name="id">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator UserDeleteDto(String id)
            {
                return (id != null) ? new UserDeleteDto() { Id = id } : null;
            }
        }

        /// <summary>
        /// The REST request used to retreive a single <see cref="User"/>.
        /// </summary>
        [Route("/users/{Id}", "GET")]
        private class UserDto : IdDto<Tag>
        {
            /// <summary>
            /// Implicitly converts the specified <see cref="User"/>-ID into a <see cref="UserDto"/>.
            /// </summary>
            /// <param name="userId">The ID to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator UserDto(String userId)
            {
                return (userId != null) ? new UserDto() { Id = userId } : null;
            }
        }

        #endregion

        #endregion
    }
}
