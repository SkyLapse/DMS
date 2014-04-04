using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        /// <summary>
        /// The adress of the the remote host.
        /// </summary>
        public Uri DocularUri { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="docularUri">The adress of the remote host.</param>
        public DocularClient(String docularUri)
            : this(new Uri(docularUri)) 
        {
            Contract.Requires<ArgumentNullException>(docularUri != null);
        }

        /// <summary>
        /// Initializes a new <see cref="DocularClient"/>.
        /// </summary>
        /// <param name="docularUri">The adress of the remote host.</param>
        public DocularClient(Uri docularUri)
        {
            Contract.Requires<ArgumentNullException>(docularUri != null);
            Contract.Requires<ArgumentException>(!docularUri.IsFile);
            Contract.Requires<ArgumentException>(docularUri.AbsoluteUri.EndsWith("api") || docularUri.AbsoluteUri.EndsWith("api/"));
            
            if (docularUri.AbsoluteUri.EndsWith("api"))
            {
                Uri result;
                if (!Uri.TryCreate(docularUri, "/", out result))
                {
                    throw new Exception("An unknown error occured when appending '/' to the docular URI.");
                }
                this.DocularUri = result;
            }
            else
            {
                this.DocularUri = docularUri;
            }
        }

        public Task DeleteDocumentAsync(Document document)
        {
            return this.DeleteDocumentAsync(document.Id);
        }

        public Task DeleteDocumentAsync(String documentId)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetContentAsync(Document document)
        {
            return this.GetContentAsync(document.Id);
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
            return this.GetDocumentsAsync((user != null) ? user.Id : null, (category != null) ? category.Id : null, (tag != null) ? tag.Id : null);
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
            return this.GetThumbnailAsync(document.Id);
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
    }
}
