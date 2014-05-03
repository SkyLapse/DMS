using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;

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
        public Buzzword[] Buzzwords
        {
            get
            {
                return _Buzzwords;
            }
            set
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
        public String ExtractedContent
        {
            get
            {
                return _ExtractedContent;
            }
            set
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
        public String Mime
        {
            get
            {
                return _Mime;
            }
            set
            {
                this.SetProperty(ref _Mime, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Uri _DocumentPath;

        /// <summary>
        /// The <see cref="Uri"/> of the payload.
        /// </summary>
        public Uri DocumentPath
        {
            get
            {
                return _DocumentPath;
            }
            set
            {
                this.SetProperty(ref _DocumentPath, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Uri _ThumbnailPath;

        /// <summary>
        /// The <see cref="Uri"/> of the thumbnail image.
        /// </summary>
        public Uri ThumbnailPath
        {
            get
            {
                return _ThumbnailPath;
            }
            set
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
        public int Size
        {
            get
            {
                return _Size;
            }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(value >= 0);

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
        public Document() { }
    }
}
