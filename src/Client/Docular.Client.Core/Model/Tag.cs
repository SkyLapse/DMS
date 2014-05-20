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
    /// Represents a tag.
    /// </summary>
    public class Tag : DocularObject
    {
        /// <summary>
        /// Initializes a new <see cref="Tag"/>.
        /// </summary>
        public Tag() { }

        /// <summary>
        /// Saves the <see cref="Tag"/> to the remote DB.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous saving process.</returns>
        public override Task SaveAsync()
        {
            return this.DocularClient.UpdateTagAsync(this);
        }
    }
}
