using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;
using Newtonsoft.Json;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a stored document.
    /// </summary>
    public class Document : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private Buzzword[] _Buzzwords;

        /// <summary>
        /// Contains all repeatedly occuring words in the extracted content.
        /// </summary>
        [JsonProperty("buzzwords")]
        public Buzzword[] Buzzwords
        {
            get
            {
                return _Buzzwords;
            }
            private set
            {
                this.SetProperty(ref _Buzzwords, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Category _Category;
        
        /// <summary>
        /// Gets the <see cref="Category"/> the <see cref="Document"/> belongs to.
        /// </summary>
        [JsonProperty("category")]
        public Category Category
        {
            get
            {
                return _Category;
            }
            set
            {
                this.SetProperty(ref _Category, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _ExtractedContent;

        /// <summary>
        /// Contains the extracted content that was read via OCR or some other content recognition method.
        /// </summary>
        [JsonProperty("content")]
        public String ExtractedContent
        {
            get
            {
                return _ExtractedContent;
            }
            private set
            {
                this.SetProperty(ref _ExtractedContent, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Mime;

        /// <summary>
        /// The document's mime type.
        /// </summary>
        [JsonProperty("mime")]
        public String Mime
        {
            get
            {
                return _Mime;
            }
            private set
            {
                this.SetProperty(ref _Mime, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Uri _PayloadPath;

        /// <summary>
        /// The <see cref="Uri"/> of the payload.
        /// </summary>
        [JsonProperty("documentPath")]
        public Uri PayloadPath
        {
            get
            {
                return _PayloadPath;
            }
            private set
            {
                this.SetProperty(ref _PayloadPath, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Uri _ThumbnailPath;

        /// <summary>
        /// The <see cref="Uri"/> of the thumbnail image.
        /// </summary>
        [JsonProperty("thumbnailPath")]
        public Uri ThumbnailPath
        {
            get
            {
                return _ThumbnailPath;
            }
            private set
            {
                this.SetProperty(ref _ThumbnailPath, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private int _Size;

        /// <summary>
        /// The size of the content in bytes.
        /// </summary>
        [JsonProperty("size")]
        public int Size
        {
            get
            {
                return _Size;
            }
            private set
            {
                this.SetProperty(ref _Size, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Tag[] _Tags;

        /// <summary>
        /// Gets all <see cref="Tag"/>s associated with the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("tags")]
        public Tag[] Tags
        {
            get
            {
                return _Tags;
            }
            set
            {
                this.SetProperty(ref _Tags, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="Document"/>. This constructor is used for deserialization.
        /// </summary>
        protected Document() { }

        /// <summary>
        /// Initializes a new <see cref="Document"/>.
        /// </summary>
        /// <param name="buzzwords">All repeatedly occuring words in the extracted content.</param>
        /// <param name="mime">The document's mime type.</param>
        /// <param name="size">The size of the content in bytes.</param>
        /// <param name="createInfo">Information about the creation of the <see cref="Document"/>.</param>
        /// <param name="editInfo">Information about the last edit of the <see cref="Document"/>.</param>
        /// <param name="extractedContent">Extracted content that was read via OCR or some other content recognition method.</param>
        /// <param name="payloadPath">The <see cref="Uri"/> of the payload.</param>
        /// <param name="thumbnailPath">The <see cref="Uri"/> of the thumbnail image.</param>
        public Document(
                    ChangeInfo createInfo,
                    ChangeInfo editInfo,
                    String mime,
                    Buzzword[] buzzwords,
                    String extractedContent,
                    Uri payloadPath,
                    Uri thumbnailPath,
                    int size
                )
        {
            Contract.Requires<ArgumentNullException>(mime != null);
            Contract.Requires<ArgumentNullException>(buzzwords != null && extractedContent != null);
            Contract.Requires<ArgumentNullException>(payloadPath != null && thumbnailPath != null);
            Contract.Requires<ArgumentException>(size >= 0);

            this.Buzzwords = buzzwords;
            this.CreateInfo = createInfo;
            this.EditInfo = editInfo;
            this.ExtractedContent = extractedContent;
            this.Mime = mime;
            this.PayloadPath = payloadPath;
            this.Size = size;
            this.ThumbnailPath = thumbnailPath;
        }

        /// <summary>
        /// Initializes a new <see cref="Document"/>.
        /// </summary>
        /// <param name="buzzwords">All repeatedly occuring words in the extracted content.</param>
        /// <param name="category">All repeatedly occuring words in the extracted content.</param>
        /// <param name="createInfo">Information about the creation of the <see cref="Document"/>.</param>
        /// <param name="editInfo">Information about the last edit of the <see cref="Document"/>.</param>
        /// <param name="extractedContent">Extracted content that was read via OCR or some other content recognition method.</param>
        /// <param name="payloadPath">The <see cref="Uri"/> of the payload.</param>
        /// <param name="thumbnailPath">The <see cref="Uri"/> of the thumbnail image.</param>
        /// <param name="mime">The document's mime type.</param>
        /// <param name="size">The size of the content in bytes.</param>
        /// <param name="tags">All <see cref="Tag"/>s associated with the <see cref="Document"/>.</param>
        public Document(
                    ChangeInfo createInfo,
                    ChangeInfo editInfo,
                    String mime,
                    Category category,
                    Buzzword[] buzzwords,
                    String extractedContent,
                    Uri payloadPath,
                    Uri thumbnailPath,
                    int size,
                    Tag[] tags
                )
            : this(createInfo, editInfo, mime, buzzwords, extractedContent, payloadPath, thumbnailPath, size)
        {
            Contract.Requires<ArgumentNullException>(mime != null);
            Contract.Requires<ArgumentNullException>(buzzwords != null && extractedContent != null);
            Contract.Requires<ArgumentNullException>(payloadPath != null && thumbnailPath != null);
            Contract.Requires<ArgumentNullException>(category != null && tags != null);
            Contract.Requires<ArgumentException>(size >= 0);

            this.Category = category;
            this.Tags = tags;
        }
    }
}
