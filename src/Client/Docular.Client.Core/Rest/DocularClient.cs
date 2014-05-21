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

        #region Authorization

        public Task<String> GetKey(String username, String password, String machineName)
        {
            return this.client.PostAsync<String>(new ApiKeyDto() { MachineName = machineName, Password = password, Username = username });
        }

        public Task<bool> ValidateKey(String key)
        {
            return this.client.PostAsync<bool>(new ApiKeyValidateDto() { Key = key });
        }

        #endregion

        #region Categories

        public Task AddCategoryAsync(Category category)
        {
            return this.client.PostAsync((CategoryAddDto)category);
        }

        public Task DeleteCategoryAsync(String categoryId)
        {
            return this.client.DeleteAsync((CategoryDeleteDto)categoryId);
        }

        public Task<Category> GetCategoryAsync(String categoryId)
        {
            return this.client.GetAsync<Category>((CategoryDto)categoryId);
        }

        public Task<Category[]> GetCategoriesAsync(CategoryCollectionParameters filter)
        {
            return this.client.GetAsync<Category[]>((CategoryCollectionDto)filter);
        }

        public Task<int> GetCategoryCountAsync()
        {
            return this.client.GetAsync<int>(new CategoryCountDto());
        }

        public Task UpdateCategoryAsync(Category category)
        {
            return this.client.PutAsync((CategoryAddDto)category);
        }

        #endregion

        #region Documents

        public Task AddDocumentAsync(Document document)
        {
            return this.client.PostAsync((DocumentAddDto)document);
        }

        public Task DeleteDocumentAsync(String documentId)
        {
            return this.client.DeleteAsync((DocumentDeleteDto)documentId);
        }

        public Task<Document> GetDocumentAsync(String documentId)
        {
            return this.client.GetAsync<Document>((DocumentDto)documentId);
        }

        public Task<Document[]> GetDocumentsAsync(DocumentCollectionParameters filter)
        {
            return this.client.GetAsync<Document[]>((DocumentCollectionDto)filter);
        }

        public Task<int> GetDocumentCountAsync()
        {
            return this.client.GetAsync<int>(new DocumentCountDto());
        }

        public Task<int> GetDocumentsSizeAsync(DocumentCollectionParameters filter)
        {
            return this.client.GetAsync<int>((DocumentSizeDto)filter);
        }

        public Task<Stream> GetPayloadAsync(String documentId)
        {
            return this.client.GetAsync<Stream>((DocumentPayloadDto)documentId);
        }

        public Task<Stream> GetThumbnailAsync(String documentId, int width = -1, int height = -1)
        {
            return this.client.GetAsync<Stream>(new DocumentThumbnailDto() { Width = width, Height = height, Id = documentId });
        }

        public Task UpdateDocumentAsync(Document document)
        {
            return this.client.PutAsync((DocumentAddDto)document);
        }

        public Task UpdateDocumentContentAsync(String documentId, Stream content)
        {
            return this.client.PostAsync(new DocumentUpdatePayloadDto() { Id = documentId, File = content });
        }

        #endregion

        #region Tags

        public Task AddTagAsync(Tag tag)
        {
            return this.client.PostAsync((TagAddDto)tag);
        }

        public Task DeleteTagAsync(String tagId)
        {
            return this.client.DeleteAsync((TagDeleteDto)tagId);
        }

        public Task<Tag> GetTagAsync(String tagId)
        {
            return this.client.GetAsync<Tag>((TagDto)tagId);
        }

        public Task<Tag[]> GetTagsAsync(TagCollectionParameters filter)
        {
            return this.client.GetAsync<Tag[]>((TagCollectionDto)filter);
        }

        public Task<int> GetTagCountAsync()
        {
            return this.client.GetAsync<int>(new TagCountDto());
        }

        public Task UpdateTagAsync(Tag tag)
        {
            return this.client.PutAsync((TagAddDto)tag);
        }

        #endregion

        #region Users

        public Task AddUserAsync(User user)
        {
            return this.client.PostAsync((UserAddDto)user);
        }

        public Task DeleteUserAsync(String userId)
        {
            return this.client.DeleteAsync((UserDeleteDto)userId);
        }

        public Task<User> GetCurrentUserAsync()
        {
            return this.client.GetAsync<User>(new UserCurrentDto());
        }

        public Task<User> GetUserAsync(String userId)
        {
            return this.client.GetAsync<User>((UserDto)userId);
        }

        public Task<User[]> GetUsersAsync(UserCollectionParameters filter)
        {
            return this.client.GetAsync<User[]>((UserCollectionDto)filter);
        }

        public Task<int> GetUserCountAsync()
        {
            return this.client.GetAsync<int>(new UserCountDto());
        }

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
            /// Implicitly converts the <see cref="Category"/> into a <see cref="DocumentDeleteRequest"/>.
            /// </summary>
            /// <param name="document">The <see cref="Document"/> to convert.</param>
            /// <returns>The conversion result.</returns>
            public static implicit operator DocumentDeleteDto(Document document)
            {
                return (document != null) ? new DocumentDeleteDto() { Id = document.Id } : null;
            }

            /// <summary>
            /// Implicitly converts the tag ID into a <see cref="DocumentDeleteRequest"/>.
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
            /// Implicitly converts the specified <see cref="Document"/>-ID into a <see cref="DocumentRequest"/>.
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
            /// <param name="category">The ID to convert.</param>
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
            /// <param name="category">The ID to convert.</param>
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
