using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category : DocularObject
    {
        /// <summary>
        /// The <see cref="Category"/>'s description.
        /// </summary>
        [JsonProperty("description")]
        public String Description { get; private set; }

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
