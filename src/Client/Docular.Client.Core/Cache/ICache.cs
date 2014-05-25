using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using PCLStorage;

namespace Docular.Client.Cache
{
    /// <summary>
    /// Defines mechanisms to locally cache data.
    /// </summary>
    [ContractClass(typeof(ICacheContracts))]
    public interface ICache
    {
        /// <summary>
        /// Adds an item to the cache.
        /// </summary>
        /// <param name="name">The name of the cache item.</param>
        /// <param name="content">The cached data.</param>
        /// <param name="store">The store storing the cache data. If null is specified, the default store will be chosen.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous caching operation.</returns>
        Task Add(String name, Stream content, String store = null);

        /// <summary>
        /// Retreives an item from the cache.
        /// </summary>
        /// <param name="name">The name of the cache item.</param>
        /// <param name="store">The store storing the cache data. If null is specified, the default store will be opened.</param>
        /// <returns>The cached data or <c>null</c> if the file could not be found.</returns>
        Task<Stream> Get(String name, String store = null);
    }

    /// <summary>
    /// Contains the contract definitions for <see cref="ICache"/>.
    /// </summary>
    [ContractClassFor(typeof(ICache))]
    abstract class ICacheContracts : ICache
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task Add(String name, Stream content, String store = null)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(content != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task<Stream> Get(String name, String store = null)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Ensures(Contract.Result<Task<Stream>>() != null);

            return null;
        }
    }
}
