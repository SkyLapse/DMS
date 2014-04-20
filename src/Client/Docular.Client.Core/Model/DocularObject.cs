using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;
using ProtoBuf;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents an object in the Docular database.
    /// </summary>
    [ProtoContract]
    public abstract class DocularObject : ObservableObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _CreateInfo;

        /// <summary>
        /// Gets information about the creation of the <see cref="DocularObject"/>.
        /// </summary>
        [JsonProperty("createInfo"), ProtoMember(1)]
        public ChangeInfo CreateInfo
        {
            get
            {
                return _CreateInfo;
            }
            protected set
            {
                if (value != _CreateInfo)
                {
                    _CreateInfo = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private CustomField[] _CustomFields;

        /// <summary>
        /// Contains all custom fields.
        /// </summary>
        [JsonProperty("customFields"), ProtoMember(2)]
        public CustomField[] CustomFields
        {
            get
            {
                return _CustomFields;
            }
            set
            {
                if (value != _CustomFields)
                {
                    _CustomFields = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Description;

        /// <summary>
        /// The <see cref="Category"/>'s description.
        /// </summary>
        [JsonProperty("description"), ProtoMember(3)]
        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (value != _Description)
                {
                    _Description = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _EditInfo;

        /// <summary>
        /// Gets information about the last (server side) edit of the <see cref="Document"/>.
        /// </summary>
        [JsonProperty("editInfo"), ProtoMember(4)]
        public ChangeInfo EditInfo
        {
            get
            {
                return _EditInfo;
            }
            protected set
            {
                if (value != _EditInfo)
                {
                    _EditInfo = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Id;

        /// <summary>
        /// The unique Id.
        /// </summary>
        [JsonProperty("_id"), ProtoMember(5)]
        public String Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                if (value != _Id)
                {
                    _Id = value;
                    this.OnPropertyChanged();
                }
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
