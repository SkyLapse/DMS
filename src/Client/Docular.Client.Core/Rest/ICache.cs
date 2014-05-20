﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using PCLStorage;

namespace Docular.Client.Rest
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
        /// <returns>The cached data.</returns>
        Task<Stream> Get(String name, String store = null);

        /// <summary>
        /// Invaliates all of the locally stored data deleting it from the device. See remarks.
        /// </summary>
        /// <remarks>
        /// Due to thread-safety, the method only deletes the files that were present when it was called, it does not make
        /// sure the cache folder is emptied completely.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting operation.</returns>
        Task Invalidate();

        /// <summary>
        /// Invaliates the locally stored data deleting it from the device. See remarks.
        /// </summary>
        /// <param name="store">The cache store to invalidate. If <c>null</c> is specified, nothing will be invalidated.</param>
        /// <remarks>
        /// Due to thread-safety, the method only deletes the files that were present when it was called, it does not make
        /// sure the cache folder is emptied completely.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting operation.</returns>
        Task Invalidate(String store);
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
            Contract.Requires<ArgumentNullException>(store != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(content != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task<Stream> Get(String name, String store = null)
        {
            Contract.Requires<ArgumentNullException>(store != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task Invalidate()
        {
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task Invalidate(String store)
        {
            return null;
        }
    }
}
