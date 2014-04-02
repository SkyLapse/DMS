using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Client.Core.Model
{
    /// <summary>
    /// Represents an object in the DMS database.
    /// </summary>
    public class DmsObject
    {
        /// <summary>
        /// The ID. See remarks.
        /// </summary>
        /// <remarks>May not be smaller than -1.</remarks>
        public int Id { get; protected set; }

        /// <summary>
        /// Initializes a new <see cref="DmsObject"/>.
        /// </summary>
        protected DmsObject()
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
