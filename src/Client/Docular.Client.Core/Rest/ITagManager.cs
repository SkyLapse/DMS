using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using Docular.Client.Rest.Requests;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Defines a mechanism to work with docular tags.
    /// </summary>
    [ContractClass(typeof(ITagManagerContracts))]
    public interface ITagManager
    {
        /// <summary>
        /// Uploads a new <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="addRequest">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task AddTagAsync(TagAddRequest addRequest);

        /// <summary>
        /// Deletes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="deleteRequest">A <see cref="TagDeleteRequest"/> containing the required data to delete a <see cref="Tag"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteTagAsync(TagDeleteRequest deleteRequest);

        /// <summary>
        /// Gets the <see cref="Tag"/> with the specified ID.
        /// </summary>
        /// <param name="request">A <see cref="TagRequest"/> used to get the specified <see cref="Tag"/>.</param>
        /// <returns>The <see cref="Task"/> with the ID, or <c>null</c> if the <see cref="Tag"/> could not be found.</returns>
        Task<Tag> GetTagAsync(TagRequest request);

        /// <summary>
        /// Gets a filtered collection of <see cref="Tag"/>s.
        /// </summary>
        /// <param name="collectionRequest">A collection of parameters to filter by.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        Task<Tag[]> GetTagsAsync(TagCollectionRequest collectionRequest);

        /// <summary>
        /// Gets the amount of <see cref="Tag"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="Tag"/>s in the DB.</returns>
        Task<int> GetTagCountAsync();

        /// <summary>
        /// Uploads a changed <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="updateRequest">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task UpdateTagAsync(TagAddRequest updateRequest);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(ITagManager))]
    abstract class ITagManagerContracts : ITagManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ITagManager.AddTagAsync(TagAddRequest addRequest)
        {
            Contract.Requires<ArgumentNullException>(addRequest != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ITagManager.DeleteTagAsync(TagDeleteRequest deleteRequest)
        {
            Contract.Requires<ArgumentNullException>(deleteRequest != null);
            Contract.Requires<ArgumentException>(deleteRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Tag> ITagManager.GetTagAsync(TagRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);
            Contract.Requires<ArgumentException>(request.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Tag[]> ITagManager.GetTagsAsync(TagCollectionRequest collectionRequest)
        {
            Contract.Requires<ArgumentNullException>(collectionRequest != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> ITagManager.GetTagCountAsync()
        {
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ITagManager.UpdateTagAsync(TagAddRequest updateRequest)
        {
            Contract.Requires<ArgumentNullException>(updateRequest != null);
            Contract.Requires<ArgumentException>(updateRequest.Id != null);

            return null;
        }
    }
}
