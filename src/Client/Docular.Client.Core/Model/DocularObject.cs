using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
