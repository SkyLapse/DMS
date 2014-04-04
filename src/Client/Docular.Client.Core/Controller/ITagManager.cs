﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;

namespace Docular.Client.Core.Controller
{
    /// <summary>
    /// Defines a mechanism to work with docular tags.
    /// </summary>
    public interface ITagManager
    {
        /// <summary>
        /// Deletes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteTagAsync(Tag tag);

        /// <summary>
        /// Deletes a <see cref="Tag"/> from the DB.
        /// </summary>
        /// <param name="tag">The ID of the <see cref="Tag"/> to delete.</param>
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
        /// <param name="user">The <see cref="User"/> who created the <see cref="Tag"/>.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        Task<Tag[]> GetTagsAsync(User user = null);

        /// <summary>
        /// Gets a filtered collection of <see cref="Tag"/>s.
        /// </summary>
        /// <param name="user">The ID of the <see cref="User"/> who created the <see cref="Tag"/>.</param>
        /// <returns>The <see cref="Tag"/>s that matched the search criteria.</returns>
        Task<Tag[]> GetTagsAsync(String userId = null);

        /// <summary>
        /// Gets the amount of <see cref="Tag"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="Tag"/>s in the DB.</returns>
        Task<int> GetTagCountAsync();

        /// <summary>
        /// Uploads a new / changed <see cref="Tag"/> to the server.
        /// </summary>
        /// <param name="tag">The <see cref="Tag"/> to upload.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous uploading process.</returns>
        Task PostTagAsync(Tag tag);
    }
}
