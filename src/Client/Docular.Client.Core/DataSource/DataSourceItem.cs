using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.DataSource
{
    /// <summary>
    /// Represents an item from a data source.
    /// </summary>
    public abstract class DataSourceItem<T>
    {
        /// <summary>
        /// Gets the date of the last edit of the item.
        /// </summary>
        public DateTime DateOfLastEdit { get; protected set; }

        /// <summary>
        /// The ID of the <see cref="DataSourceItem"/>.
        /// </summary>
        public String Id { get; protected set; }

        /// <summary>
        /// Resolves the <see cref="DataSourceItem"/> to an instance of the specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to resolve to.</typeparam>
        /// <returns>The resolved item.</returns>
        public abstract Task<T> Resolve();
    }
}
