using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Client.Core.Model
{
    /// <summary>
    /// Represents a tag.
    /// </summary>
    public class Tag : DmsObject
    {
        /// <summary>
        /// Gets all <see cref="Document"/>s with the <see cref="Tag"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that are tagged with the <see cref="Tag"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            Contract.Ensures(Contract.Result<Document[]>() != null);

            throw new NotImplementedException();
        }
    }
}
