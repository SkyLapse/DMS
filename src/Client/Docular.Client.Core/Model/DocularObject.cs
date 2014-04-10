using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Represents an object in the Docular database.
    /// </summary>
    [ProtoContract]
    public class DocularObject
    {
        /// <summary>
        /// Contains all custom fields.
        /// </summary>
        [JsonProperty("customFields"), ProtoMember(1)]
        public CustomField[] CustomFields { get; set; }

        /// <summary>
        /// The <see cref="Category"/>'s description.
        /// </summary>
        [JsonProperty("description"), ProtoMember(2)]
        public String Description { get; set; }

        /// <summary>
        /// The unique Id.
        /// </summary>
        [JsonProperty("_id"), ProtoMember(3)]
        public String Id { get; protected set; }

        /// <summary>
        /// The <see cref="DocularObject"/>s name.
        /// </summary>
        [JsonProperty("name"), ProtoMember(4)]
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IDocularClient"/> that created the <see cref="DocularObject"/>.
        /// </summary>
        [JsonIgnore]
        protected IDocularClient Client { get; set; }

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
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="DocularObject"/>.</param>
        protected DocularObject(IDocularClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        /// <param name="id">The unique Id.</param>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="DocularObject"/>.</param>
        protected DocularObject(IDocularClient client, String id)
            : this(id)
        {
            this.Client = client;
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
