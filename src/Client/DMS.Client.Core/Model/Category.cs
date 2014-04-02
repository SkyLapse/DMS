using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Client.Core.Model
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category : DmsObject
    {
        /// <summary>
        /// Gets all <see cref="Document"/>s within the <see cref="Category"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that are within the <see cref="Category"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            Contract.Ensures(Contract.Result<Document[]>() != null);

            throw new NotImplementedException();
        }
    }
}
