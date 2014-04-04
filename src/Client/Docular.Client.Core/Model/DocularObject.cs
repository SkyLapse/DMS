using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents an object in the Docular database.
    /// </summary>
    public class DocularObject
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public String Id { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="IDocularClient"/> that created the <see cref="DocularObject"/>.
        /// </summary>
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
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="DocularObject"/>..</param>
        protected DocularObject(IDocularClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        /// <param name="id">The unique Id.</param>
        /// <param name="client">The <see cref="IDocularClient"/> that created the <see cref="DocularObject"/>..</param>
        protected DocularObject(IDocularClient client, String id)
            : this(id)
        {
            this.Client = client;
        }
    }
}
