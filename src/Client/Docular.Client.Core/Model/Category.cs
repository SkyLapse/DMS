using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public String Description { get; private set; }

        /// <summary>
        /// Gets all <see cref="Document"/>s within the <see cref="Category"/>.
        /// </summary>
        /// <returns>An array of <see cref="Document"/>s that are within the <see cref="Category"/>.</returns>
        public Task<Document[]> GetDocumentsAsync()
        {
            Contract.Ensures(Contract.Result<Task<Document[]>>() != null);

            throw new NotImplementedException();
        }
    }
}
