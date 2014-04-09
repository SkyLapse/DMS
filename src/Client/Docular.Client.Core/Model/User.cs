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
    /// Represents a user.
    /// </summary>
    public class User : DocularObject
    {
        /// <summary>
        /// Initializes a new <see cref="User"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> that created the user.</param>
        [JsonConstructor]
        public User(IDocularClient client)
            : base(client)
        {
            Contract.Requires<ArgumentNullException>(client != null);
        }

        /// <summary>
        /// Gets all <see cref="Document"/>s created by the current <see cref="User"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that were created by the <see cref="User"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            return this.Client.GetDocumentsAsync(new Parameter() { Name = "user", Value = this.Id, Type = ParameterType.GetOrPost });
        }
    }
}
