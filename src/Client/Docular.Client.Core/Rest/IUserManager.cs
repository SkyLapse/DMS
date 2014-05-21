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
    /// Defines a mechanism to work with docular users.
    /// </summary>
    [ContractClass(typeof(IUserManagerContracts))]
    public interface IUserManager
    {
        /// <summary>
        /// Uploads a new <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task AddUserAsync(User user);

        /// <summary>
        /// Deletes a <see cref="User"/> from the DB.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteUserAsync(String userId);

        /// <summary>
        /// Gets the <see cref="User"/> associated with the login data.
        /// </summary>
        /// <returns>The <see cref="User"/> associated with the transmitted login data.</returns>
        Task<User> GetCurrentUserAsync();

        /// <summary>
        /// Gets the <see cref="User"/> with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to obtain.</param>
        /// <returns>The <see cref="User"/> with the specified ID, or <c>null</c> if the user was not found.</returns>
        Task<User> GetUserAsync(String userId);

        /// <summary>
        /// Gets a filtered list of <see cref="User"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns>A collection of <see cref="User"/>s that match the criteria.</returns>
        Task<User[]> GetUsersAsync(UserCollectionParameters filter);

        /// <summary>
        /// Gets the amount of <see cref="User"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="User"/>s.</returns>
        Task<int> GetUserCountAsync();

        /// <summary>
        /// Uploads a changed <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The changed <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateUserAsync(User user);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(IUserManager))]
    abstract class IUserManagerContracts : IUserManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.AddUserAsync(User user)
        {
            Contract.Requires<ArgumentNullException>(user != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.DeleteUserAsync(String userId)
        {
            Contract.Requires<ArgumentNullException>(userId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<User> IUserManager.GetCurrentUserAsync()
        {
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<User> IUserManager.GetUserAsync(String userId)
        {
            Contract.Requires<ArgumentNullException>(userId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<User[]> IUserManager.GetUsersAsync(UserCollectionParameters collectionRequest)
        {
            Contract.Requires<ArgumentNullException>(collectionRequest != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> IUserManager.GetUserCountAsync()
        {
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.UpdateUserAsync(User user)
        {
            Contract.Requires<ArgumentNullException>(user != null);
            Contract.Requires<ArgumentException>(user.Id != null);

            return null;
        }
    }
}
