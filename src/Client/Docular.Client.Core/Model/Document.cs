using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a stored document.
    /// </summary>
    public class Document : DocularObject
    {
        /// <summary>
        /// Contains all repeatedly occuring words in the extracted content.
        /// </summary>
        [JsonProperty("buzzwords")]
        public Buzzword[] Buzzwords { get; private set; }

        /// <summary>
        /// Gets the <see cref="Category"/> the <see cref="Document"/> belongs to.
        /// </summary>
        [JsonProperty("category")]
        public Category Category { get; set; }

        /// <summary>
        /// Gets information about the creation of the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("createInfo")]
        public ChangeInfo CreateInfo { get; private set; }

        /// <summary>
        /// Gets information about the last edit of the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("editInfo")]
        public ChangeInfo EditInfo { get; private set; }

        /// <summary>
        /// Contains the extracted content that was read via OCR or some other content recognition method.
        /// </summary>
        [JsonProperty("content")]
        public String ExtractedContent { get; private set; }

        /// <summary>
        /// The document's mime type.
        /// </summary>
        [JsonProperty("mime")]
        public String Mime { get; private set; }

        /// <summary>
        /// The <see cref="Uri"/> of the payload.
        /// </summary>
        [JsonProperty("documentPath")]
        public Uri PayloadPath { get; private set; }

        /// <summary>
        /// The <see cref="Uri"/> of the thumbnail image.
        /// </summary>
        [JsonProperty("thumbnailPath")]
        public Uri ThumbnailPath { get; private set; }

        /// <summary>
        /// The size of the content in bytes.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; private set; }

        /// <summary>
        /// Gets all <see cref="Tag"/>s associated with the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        /// <summary>
        /// Initializes a new <see cref="Document"/>.
        /// </summary>
        private Document() 
        {
            this.Buzzwords = Enumerable.Empty<Buzzword>().ToArray();
            this.ExtractedContent = String.Empty;
            this.Mime = String.Empty;
            this.PayloadPath = new Uri(String.Empty);
            this.ThumbnailPath = new Uri(String.Empty);
        }

        /// <summary>
        /// Initializes a new <see cref="Document"/>.
        /// </summary>
        /// <param name="buzzwords">All repeatedly occuring words in the extracted content.</param>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="Document"/>.</param>
        /// <param name="mime">The document's mime type.</param>
        /// <param name="size">The size of the content in bytes.</param>
        /// <param name="createInfo">Information about the creation of the <see cref="Document"/>.</param>
        /// <param name="editInfo">Information about the last edit of the <see cref="Document"/>.</param>
        /// <param name="extractedContent">Extracted content that was read via OCR or some other content recognition method.</param>
        /// <param name="payloadPath">The <see cref="Uri"/> of the payload.</param>
        /// <param name="thumbnailPath">The <see cref="Uri"/> of the thumbnail image.</param>
        public Document(
                    IDocularClient client,
                    ChangeInfo createInfo,
                    ChangeInfo editInfo,
                    String mime,
                    Buzzword[] buzzwords,
                    String extractedContent,
                    Uri payloadPath,
                    Uri thumbnailPath,
                    int size
                )
            : base(client)
        {
            Contract.Requires<ArgumentNullException>(client != null);
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
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="Document"/>.</param>
        /// <param name="createInfo">Information about the creation of the <see cref="Document"/>.</param>
        /// <param name="editInfo">Information about the last edit of the <see cref="Document"/>.</param>
        /// <param name="extractedContent">Extracted content that was read via OCR or some other content recognition method.</param>
        /// <param name="payloadPath">The <see cref="Uri"/> of the payload.</param>
        /// <param name="thumbnailPath">The <see cref="Uri"/> of the thumbnail image.</param>
        /// <param name="mime">The document's mime type.</param>
        /// <param name="size">The size of the content in bytes.</param>
        /// <param name="tags">All <see cref="Tag"/>s associated with the <see cref="Document"/>.</param>
        public Document(
                    IDocularClient client,
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
            : this(client, createInfo, editInfo, mime, buzzwords, extractedContent, payloadPath, thumbnailPath, size)
        {
            Contract.Requires<ArgumentNullException>(client != null);
            Contract.Requires<ArgumentNullException>(mime != null);
            Contract.Requires<ArgumentNullException>(buzzwords != null && extractedContent != null);
            Contract.Requires<ArgumentNullException>(payloadPath != null && thumbnailPath != null);
            Contract.Requires<ArgumentNullException>(category != null && tags != null);
            Contract.Requires<ArgumentException>(size >= 0);

            this.Category = category;
            this.Tags = tags;
        }

        /// <summary>
        /// Refreshes the <see cref="Document"/> fetching all changes from the remote DB.
        /// </summary>
        /// <returns>The modified <see cref="Document"/>.</returns>
        public Task<Document> Refresh()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the document to the server.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous saving process.</returns>
        public Task Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Contains Contract.Invariant definitions.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Buzzwords != null);
            Contract.Invariant(this.ExtractedContent != null);
            Contract.Invariant(this.Mime != null);
            Contract.Invariant(this.PayloadPath != null);
            Contract.Invariant(this.Size >= 0);
            Contract.Invariant(this.ThumbnailPath != null);
        }
    }
}
