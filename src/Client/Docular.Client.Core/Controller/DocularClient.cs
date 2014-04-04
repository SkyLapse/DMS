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
    /// Represents a client for working with a docular DB.
    /// </summary>
    public class DocularClient : IDocularClient
    {
        public Task DeleteDocumentAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDocumentAsync(String documentId)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetContentAsync(Document document)
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

        public Task<Document[]> GetDocumentsAsync(User user = null, Category category = null, Tag tag = null)
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

        public Task<Stream> GetThumbnailAsync(Document document)
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

        public Task UploadContentAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task UploadContentAsync(String documentId, System.IO.Stream content)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Category category)
        {
            throw new NotImplementedException();
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

        public Task DeleteTagAsync(Tag tag)
        {
            throw new NotImplementedException();
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

        public Task DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
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
    }
}
