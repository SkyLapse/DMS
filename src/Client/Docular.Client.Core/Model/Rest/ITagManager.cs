using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;
using RestSharp.Portable;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Defines a mechanism to work with docular tags.
    /// </summary>
    [ContractClass(typeof(TagManagerContracts))]
    public interface ITagManager
    {
        /// <summary>
        /// Deletes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="tagId">The ID of the <see cref="Tag"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteTagAsync(String tagId);

        /// <summary>
        /// Gets the <see cref="Tag"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Tag"/> to get.</param>
        /// <returns>The <see cref="Task"/> with the ID, or <c>null</c> if the <see cref="Tag"/> could not be found.</returns>
        Task<Tag> GetTagAsync(String id);

        /// <summary>
        /// Gets a filtered collection of <see cref="Tag"/>s.
        /// </summary>
        /// <param name="filterParameters">A collection of <see cref="Parameter"/>s to filter by.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        Task<Tag[]> GetTagsAsync(params Parameter[] filterParameters);

        /// <summary>
        /// Gets the amount of <see cref="Tag"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="Tag"/>s in the DB.</returns>
        Task<int> GetTagCountAsync();

        /// <summary>
        /// Uploads a new <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task PostTagAsync(Tag tag);

        /// <summary>
        /// Uploads a changed <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task PutTagAsync(Tag tag);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(ITagManager))]
    abstract class TagManagerContracts : ITagManager
    {
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
        Task<Tag> ITagManager.GetTagAsync(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Tag[]> ITagManager.GetTagsAsync(params Parameter[] filterParameters)
        {
            Contract.Requires<ArgumentNullException>(filterParameters != null);
            Contract.Requires<ArgumentException>(filterParameters.All(filterParam => filterParam.Type == ParameterType.GetOrPost));
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
        Task ITagManager.PostTagAsync(Tag tag)
        {
            Contract.Requires<ArgumentNullException>(tag != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ITagManager.PutTagAsync(Tag tag)
        {
            Contract.Requires<ArgumentNullException>(tag != null);
            Contract.Requires<ArgumentNullException>(tag.Id != null);

            return null;
        }
    }
}
