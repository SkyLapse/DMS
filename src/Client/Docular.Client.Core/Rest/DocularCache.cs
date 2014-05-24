using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Events;
using Docular.Client.Model;
using PCLStorage;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Represents a cache.
    /// </summary>
    public class DocularCache : ICache
    {
        /// <summary>
        /// The <see cref="EventSource"/> used to trace cache events.
        /// </summary>
        private static CacheEventSource cacheEventSource = new CacheEventSource();

        /// <summary>
        /// Initializes a new <see cref="DocularCache"/>.
        /// </summary>
        public DocularCache() { }

        /// <summary>
        /// Adds an item to the cache.
        /// </summary>
        /// <param name="store">The store storing the cache data.</param>
        /// <param name="name">The name of the cache item.</param>
        /// <param name="content">The cached data.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous caching operation.</returns>
        public async Task Add(String name, Stream content, String store = null)
        {
            await this.WriteToFileAsync(content, await this.OpenStore(store), name);
            cacheEventSource.ItemStored(name, store, content.Length);
        }

        /// <summary>
        /// Retreives an item from the cache.
        /// </summary>
        /// <param name="storeName">The name of the store storing the cache data.</param>
        /// <param name="name">The name of the cache item.</param>
        /// <returns>The cached data or null if the file could not be found.</returns>
        public async Task<Stream> Get(String name, String storeName = null)
        {
            try
            {
                Stream data = await (await (await this.OpenStore(storeName)).GetFileAsync(name)).OpenAsync(FileAccess.Read);
                cacheEventSource.ItemReceived(name, storeName, data.Length);
                return data;
            }
            catch (FileNotFoundException)
            {
                cacheEventSource.ItemNotFound(name, storeName);
                return null;
            }
        }

        /// <summary>
        /// Invaliates all local stores deleting the cached data from the device.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting operation.</returns>
        public async Task Invalidate()
        {
            await Task.WhenAll(
                (await (await this.OpenCacheFolder()).GetFoldersAsync()).Select(folder => this.Invalidate(folder))
            );
        }

        /// <summary>
        /// Invaliates the locally stored data deleting it from the device. See remarks.
        /// </summary>
        /// <param name="store">The cache store to invalidate.</param>
        /// <remarks>
        /// Due to thread-safety, the method only deletes the files that were present when it was called, it does not make
        /// sure the cache folder is emptied completely.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting operation.</returns>
        public async Task Invalidate(String store)
        {
            await this.Invalidate(await this.OpenStore(store));
        }

        /// <summary>
        /// Invalidates the specified cache-store deleting all it's files.
        /// </summary>
        /// <param name="store">The store to invalidate.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous invalidating operation.</returns>
        public async Task Invalidate(IFolder store)
        {
            Contract.Requires<ArgumentNullException>(store != null);

            await Task.WhenAll((await store.GetFilesAsync()).Select(file => file.DeleteAsync()));
            cacheEventSource.Invalidated(store.Name);
        }

        /// <summary>
        /// Opens the cache folder.
        /// </summary>
        /// <returns>The folder containing the cache stores.</returns>
        private Task<IFolder> OpenCacheFolder()
        {
            Contract.Assume(FileSystem.Current != null);
            Contract.Assume(FileSystem.Current.LocalStorage != null);

            return FileSystem.Current.LocalStorage.CreateFolderAsync("Cache", CreationCollisionOption.OpenIfExists);
        }

        /// <summary>
        /// Opens the cache store with the specified name.
        /// </summary>
        /// <param name="name">The name of the store to open.</param>
        /// <returns>The cache store.</returns>
        private async Task<IFolder> OpenStore(String name)
        {
            return await (await this.OpenCacheFolder()).CreateFolderAsync(name ?? "Default", CreationCollisionOption.OpenIfExists);
        }

        /// <summary>
        /// Writes the specified byte data to the file with the specified name, overwriting it, if it exists.
        /// </summary>
        /// <param name="content">The new file content.</param>
        /// <param name="folder">The <see cref="IFolder"/> the file resides in.</param>
        /// <param name="fileName">The name of the file to access.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous writing process.</returns>
        private async Task WriteToFileAsync(Stream content, IFolder folder, String fileName)
        {
            Contract.Requires<ArgumentNullException>(content != null && folder != null && fileName != null);

            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (Stream fs = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                await content.CopyToAsync(fs);
            }
        }
    }
}
