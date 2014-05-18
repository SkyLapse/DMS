using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Defines mechanisms to locally cache document payloads and thumbnails.
    /// </summary>
    [ContractClass(typeof(ICacheContracts))]
    public interface ICache
    {
        /// <summary>
        /// Gets the thumbnail for the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the document to obtain the thumbnail of.</param>
        /// <returns>The thumbnail.</returns>
        Task<Stream> GetThumbnailAsync(String id);

        /// <summary>
        /// Gets the payload for the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the document to obtain the payload of.</param>
        /// <returns>The payload.</returns>
        Task<Stream> GetPayloadAsync(String id);

        /// <summary>
        /// Invaliates the locally stored data deleting it from the device. See remarks.
        /// </summary>
        /// <remarks>
        /// Due to thread-safety, the method only deletes the files that were present when it was called, it does not make
        /// sure the cache folder is emptied completely.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting operation.</returns>
        Task Invalidate();
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
        public Task<Stream> GetThumbnailAsync(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task<Stream> GetPayloadAsync(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public Task Invalidate()
        {
            return null;
        }
    }
}
