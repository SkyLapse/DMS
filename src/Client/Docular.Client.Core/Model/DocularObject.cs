using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;
using Newtonsoft.Json;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents an object in the Docular database.
    /// </summary>
    public abstract class DocularObject : ObservableObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _CreateInfo;

        /// <summary>
        /// Gets information about the creation of the <see cref="DocularObject"/>.
        /// </summary>
        [JsonProperty("createInfo")]
        public ChangeInfo CreateInfo
        {
            get
            {
                return _CreateInfo;
            }
            protected set
            {
                this.SetProperty(ref _CreateInfo, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private CustomField[] _CustomFields;

        /// <summary>
        /// Contains all custom fields.
        /// </summary>
        [JsonProperty("customFields")]
        public CustomField[] CustomFields
        {
            get
            {
                return _CustomFields;
            }
            set
            {
                this.SetProperty(ref _CustomFields, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Description;

        /// <summary>
        /// The <see cref="Category"/>'s description.
        /// </summary>
        [JsonProperty("description")]
        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                this.SetProperty(ref _Description, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _EditInfo;

        /// <summary>
        /// Gets information about the last (server side) edit of the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("editInfo")]
        public ChangeInfo EditInfo
        {
            get
            {
                return _EditInfo;
            }
            protected set
            {
                this.SetProperty(ref _EditInfo, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Id;

        /// <summary>
        /// The unique Id.
        /// </summary>
        [JsonProperty("_id")]
        public String Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                this.SetProperty(ref _Id, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        protected DocularObject() { }

        /// <summary>
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        /// <param name="id">The unique Id.</param>
        protected DocularObject(String id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Implictly gets the <see cref="DocularObject"/>'s ID.
        /// </summary>
        /// <param name="docularObject">The <see cref="DocularObject"/> to get the ID of.</param>
        /// <returns>The <see cref="DocularObject"/>'s ID.</returns>
        public static implicit operator String(DocularObject docularObject)
        {
            return (docularObject != null) ? docularObject.Id : null;
        }
    }
}
