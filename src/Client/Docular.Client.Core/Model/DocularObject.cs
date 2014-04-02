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
        /// The ID. See remarks.
        /// </summary>
        /// <remarks>May not be smaller than -1.</remarks>
        public int Id { get; protected set; }

        /// <summary>
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        protected DocularObject()
        {
            this.Id = -1;
        }

        /// <summary>
        /// Contains Contract.Invariant definitions.
        /// </summary>
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Id >= -1);
        }
    }
}
