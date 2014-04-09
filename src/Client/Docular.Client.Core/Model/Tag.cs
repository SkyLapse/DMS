using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;
using RestSharp.Portable;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a tag.
    /// </summary>
    public class Tag : DocularObject
    {
        /// <summary>
        /// The <see cref="Tag"/>'s name.
        /// </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary>
        /// Initializes a new <see cref="Tag"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="Tag"/>.</param>
        [JsonConstructor]
        public Tag(IDocularClient client)
            : base(client)
        {
            Contract.Requires<ArgumentNullException>(client != null);
        }

        /// <summary>
        /// Initializes a new <see cref="Tag"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="Tag"/>.</param>
        [JsonConstructor]
        public Tag(IDocularClient client, String name, String description) 
            : base(client) 
        {
            Contract.Requires<ArgumentNullException>(client != null);

            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets all <see cref="Document"/>s with the <see cref="Tag"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that are tagged with the <see cref="Tag"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            return this.Client.GetDocumentsAsync(new Parameter() { Name = "tag", Value = this.Id, Type = ParameterType.GetOrPost });
        }
    }
}
