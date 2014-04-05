using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Defines a mechanism to work with docular users.
    /// </summary>
    [ContractClass(typeof(UserManagerContracts))]
    public interface IUserManager
    {
        /// <summary>
        /// Deletes a <see cref="User"/> from the DB.
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteUserAsync(String userId);

        /// <summary>
        /// Gets the <see cref="User"/> with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="User"/> to obtain.</param>
        /// <returns>The <see cref="User"/> with the specified ID, or <c>null</c> if the user was not found.</returns>
        Task<User> GetUserAsync(String id);

        /// <summary>
        /// Gets the amount of <see cref="User"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="User"/>s.</returns>
        Task<int> GetUserCountAsync();

        /// <summary>
        /// Uploads a new <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PostUserAsync(User user);

        /// <summary>
        /// Uploads a changed <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PutUserAsync(User user);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(IUserManager))]
    abstract class UserManagerContracts : IUserManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.DeleteUserAsync(String userId)
        {
            Contract.Requires<ArgumentNullException>(userId != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<User> IUserManager.GetUserAsync(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> IUserManager.GetUserCountAsync()
        {
            Contract.Ensures(Contract.Result<Task<int>>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.PostUserAsync(User user)
        {
            Contract.Requires<ArgumentNullException>(user != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.PutUserAsync(User user)
        {
            Contract.Requires<ArgumentNullException>(user != null);
            Contract.Requires<ArgumentNullException>(user.Id != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }
    }
}
