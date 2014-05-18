using System;
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
    /// Represents a cache for thumbnails and payloads.
    /// </summary>
    public class DocularCache : ICache
    {
        /// <summary>
        /// The folder name for the folder storing the documents payloads.
        /// </summary>
        private const String PayloadFolderName = "Payloads";

        /// <summary>
        /// The folder name for the folder storing the documents thumbnails.
        /// </summary>
        private const String ThumbnailFolderName = "Thumbnails";

        /// <summary>
        /// Gets the payload for the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the document to obtain the payload of.</param>
        /// <returns>The payload.</returns>
        public async Task<Stream> GetPayloadAsync(String id)
        {
            return await this.OpenFile(await this.OpenPayloadFolder(), id);
        }

        /// <summary>
        /// Gets the thumbnail for the <see cref="Document"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the document to obtain the thumbnail of.</param>
        /// <returns>The thumbnail.</returns>
        public async Task<Stream> GetThumbnailAsync(String id)
        {
            return await this.OpenFile(await this.OpenThumbnailFolder(), id);
        }

        /// <summary>
        /// Opens the specified file in the specified <see cref="IFolder"/>.
        /// </summary>
        /// <param name="folder">The <see cref="IFolder"/> containing the file.</param>
        /// <param name="fileName">The name of the file to open.</param>
        /// <returns>The opened file.</returns>
        private async Task<Stream> OpenFile(IFolder folder, String fileName)
        {
            Contract.Requires<ArgumentNullException>(folder != null && fileName != null);

            IFile payloadFile = await folder.GetFileAsync(fileName);
            return (payloadFile != null) ? await payloadFile.OpenAsync(FileAccess.Read) : null;
        }

        /// <summary>
        /// Invaliates the locally stored data deleting it from the device.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting operation.</returns>
        public async Task Invalidate()
        {
            await Task.WhenAll(
                Task.WhenAll((await (await this.OpenPayloadFolder()).GetFilesAsync()).Select(file => file.DeleteAsync())),
                Task.WhenAll((await (await this.OpenThumbnailFolder()).GetFilesAsync()).Select(file => file.DeleteAsync()))
            );
        }

        /// <summary>
        /// Opens the payload folder.
        /// </summary>
        /// <returns>The <see cref="IFolder"/> containing the payloads.</returns>
        private Task<IFolder> OpenPayloadFolder()
        {
            Contract.Assume(FileSystem.Current.LocalStorage != null);

            return FileSystem.Current.LocalStorage.CreateFolderAsync(PayloadFolderName, CreationCollisionOption.OpenIfExists);
        }

        /// <summary>
        /// Opens the thumbnail folder.
        /// </summary>
        /// <returns>The <see cref="IFolder"/> containing the thumbnails.</returns>
        private Task<IFolder> OpenThumbnailFolder()
        {
            Contract.Assume(FileSystem.Current.LocalStorage != null);

            return FileSystem.Current.LocalStorage.CreateFolderAsync(ThumbnailFolderName, CreationCollisionOption.OpenIfExists);
        }
    }
}
