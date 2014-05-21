using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;

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
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task AddTagAsync(Tag tag);

        /// <summary>
        /// Removes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="tagId">The ID of the <see cref="Tag"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteTagAsync(String tagId);

        /// <summary>
        /// Gets the <see cref="Tag"/> with the specified ID.
        /// </summary>
        /// <param name="tagId">The ID of the <see cref="Tag"/> to obtain..</param>
        /// <returns>The <see cref="Task"/> with the ID, or <c>null</c> if the <see cref="Tag"/> could not be found.</returns>
        Task<Tag> GetTagAsync(String tagId);

        /// <summary>
        /// Gets a filtered collection of <see cref="Tag"/>s.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        Task<Tag[]> GetTagsAsync(TagCollectionParameters filter);

        /// <summary>
        /// Gets the amount of <see cref="Tag"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="Tag"/>s in the DB.</returns>
        Task<int> GetTagCountAsync();

        /// <summary>
        /// Uploads a changed <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task UpdateTagAsync(Tag tag);
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
        Task ITagManager.AddTagAsync(Tag tag)
        {
            Contract.Requires<ArgumentNullException>(tag != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ITagManager.DeleteTagAsync(String tagId)
        {
            Contract.Requires<ArgumentNullException>(tagId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Tag> ITagManager.GetTagAsync(String tagId)
        {
            Contract.Requires<ArgumentNullException>(tagId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Tag[]> ITagManager.GetTagsAsync(TagCollectionParameters filter)
        {
            Contract.Requires<ArgumentNullException>(filter != null);

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
        Task ITagManager.UpdateTagAsync(Tag tag)
        {
            Contract.Requires<ArgumentNullException>(tag != null);
            Contract.Requires<ArgumentException>(tag.Id != null);

            return null;
        }
    }
}
