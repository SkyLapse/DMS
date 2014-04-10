﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;
using ProtoBuf;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a stored document.
    /// </summary>
    [ProtoContract]
    public class Document : DocularObject
    {
        /// <summary>
        /// Contains all repeatedly occuring words in the extracted content.
        /// </summary>
        [JsonProperty("buzzwords"), ProtoMember(1)]
        public Buzzword[] Buzzwords { get; private set; }

        /// <summary>
        /// Gets the <see cref="Category"/> the <see cref="Document"/> belongs to.
        /// </summary>
        [JsonProperty("category"), ProtoMember(2)]
        public Category Category { get; set; }

        /// <summary>
        /// Gets information about the creation of the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("createInfo"), ProtoMember(3)]
        public ChangeInfo CreateInfo { get; private set; }

        /// <summary>
        /// Gets information about the last edit of the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("editInfo"), ProtoMember(4)]
        public ChangeInfo EditInfo { get; private set; }

        /// <summary>
        /// Contains the extracted content that was read via OCR or some other content recognition method.
        /// </summary>
        [JsonProperty("content"), ProtoMember(5)]
        public String ExtractedContent { get; private set; }

        /// <summary>
        /// The document's mime type.
        /// </summary>
        [JsonProperty("mime"), ProtoMember(6)]
        public String Mime { get; private set; }

        /// <summary>
        /// The <see cref="Uri"/> of the payload.
        /// </summary>
        [JsonProperty("documentPath"), ProtoMember(7)]
        public Uri PayloadPath { get; private set; }

        /// <summary>
        /// The <see cref="Uri"/> of the thumbnail image.
        /// </summary>
        [JsonProperty("thumbnailPath"), ProtoMember(8)]
        public Uri ThumbnailPath { get; private set; }

        /// <summary>
        /// The size of the content in bytes.
        /// </summary>
        [JsonProperty("size"), ProtoMember(9)]
        public int Size { get; private set; }

        /// <summary>
        /// Gets all <see cref="Tag"/>s associated with the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("tags"), ProtoMember(10)]
        public Tag[] Tags { get; set; }

        /// <summary>
        /// Initializes a new <see cref="Document"/>. This constructor is used for deserialization.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="Document"/>.</param>
        [JsonConstructor]
        protected Document(IDocularClient client)
            : base(client)
        {
            Contract.Requires<ArgumentNullException>(client != null);
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
        public async Task<Document> Refresh()
        {
            Document document = await this.Client.GetDocumentAsync(this.Id);
            if (document != null)
            {
                this.Buzzwords = document.Buzzwords;
                this.Category = document.Category;
                this.CustomFields = document.CustomFields;
                this.EditInfo = document.EditInfo;
                this.ExtractedContent = document.ExtractedContent;
                this.Mime = document.Mime;
                this.Name = document.Name;
                this.PayloadPath = document.PayloadPath;
                this.Size = document.Size;
                this.Tags = document.Tags;
                this.ThumbnailPath = document.ThumbnailPath;
            }
            return document;
        }

        /// <summary>
        /// Saves the document to the server without updating the content.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous saving process.</returns>
        public Task Save()
        {
            return this.Save(false);
        }

        /// <summary>
        /// Saves the document to the server.
        /// </summary>
        /// <param name="uploadContent"><c>true</c> if the content shall be updated / uploaded to the server, otherwise <c>false</c>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous saving process.</returns>
        public Task Save(bool uploadContent)
        {
            return Task.WhenAll(
                this.Client.PutDocumentAsync(this), 
                uploadContent ? this.Client.PutDocumentContentAsync(this) : Task.FromResult<object>(null)
            );
        }
    }
}
