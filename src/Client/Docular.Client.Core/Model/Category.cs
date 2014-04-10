using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;
using ProtoBuf;
using RestSharp.Portable;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    [ProtoContract]
    public class Category : DocularObject
    {
        /// <summary>
        /// The <see cref="Category"/>s parent.
        /// </summary>
        [JsonProperty("parent"), ProtoMember(1)]
        public Category Parent { get; set; }

        /// <summary>
        /// Initializes a new <see cref="Category"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="Category"/>.</param>
        [JsonConstructor]
        public Category(IDocularClient client)
            : base(client)
        {
            Contract.Requires<ArgumentNullException>(client != null);
        }

        /// <summary>
        /// Gets all <see cref="Document"/>s within the <see cref="Category"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that are within the <see cref="Category"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            return this.Client.GetDocumentsAsync(new Parameter() { Name = "category", Value = this.Id, Type = ParameterType.GetOrPost });
        }
    }
}
