using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public String Name { get; private set; }

        /// <summary>
        /// The <see cref="Tag"/>'s name.
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Gets all <see cref="Document"/>s with the <see cref="Tag"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that are tagged with the <see cref="Tag"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            Contract.Ensures(Contract.Result<Task<Document[]>>() != null);

            throw new NotImplementedException();
        }
    }
}
