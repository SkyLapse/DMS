﻿using System;
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
    /// Defines a mechanism to work with docular users.
    /// </summary>
    [ContractClass(typeof(IUserManagerContracts))]
    public interface IUserManager
    {
        /// <summary>
        /// Uploads a new <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="addRequest">The <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task AddUserAsync(UserAddRequest addRequest);

        /// <summary>
        /// Deletes a <see cref="User"/> from the DB.
        /// </summary>
        /// <param name="deleteRequest">A <see cref="UserDeleteRequest"/> containing the ID of the <see cref="User"/> to delete.</param>
        /// <returns>A <see cref="Task"/> describing the asynchronous deleting process.</returns>
        Task DeleteUserAsync(UserDeleteRequest deleteRequest);

        /// <summary>
        /// Gets the <see cref="User"/> associated with the login data.
        /// </summary>
        /// <returns>The <see cref="User"/> associated with the transmitted login data.</returns>
        Task<User> GetCurrentUserAsync();

        /// <summary>
        /// Gets the <see cref="User"/> with the specified ID.
        /// </summary>
        /// <param name="request">A <see cref="UserRequest"/> containing the ID of the <see cref="User"/> to obtain.</param>
        /// <returns>The <see cref="User"/> with the specified ID, or <c>null</c> if the user was not found.</returns>
        Task<User> GetUserAsync(UserRequest request);

        /// <summary>
        /// Gets a filtered list of <see cref="User"/>s that match the specified criteria.
        /// </summary>
        /// <param name="collectionRequest">A collection of parameters to filter by.</param>
        /// <returns>A collection of <see cref="User"/>s that match the criteria.</returns>
        Task<User[]> GetUsersAsync(UserCollectionRequest collectionRequest);

        /// <summary>
        /// Gets the amount of <see cref="User"/>s.
        /// </summary>
        /// <returns>The amount of <see cref="User"/>s.</returns>
        Task<int> GetUserCountAsync();

        /// <summary>
        /// Uploads a changed <see cref="User"/> to the DB.
        /// </summary>
        /// <param name="updateRequest">The changed <see cref="User"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateUserAsync(UserAddRequest updateRequest);
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
        Task IUserManager.AddUserAsync(UserAddRequest addRequest)
        {
            Contract.Requires<ArgumentNullException>(addRequest != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task IUserManager.DeleteUserAsync(UserDeleteRequest deleteRequest)
        {
            Contract.Requires<ArgumentNullException>(deleteRequest != null);
            Contract.Requires<ArgumentException>(deleteRequest.Id != null);

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
        Task<User> IUserManager.GetUserAsync(UserRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);
            Contract.Requires<ArgumentException>(request.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<User[]> IUserManager.GetUsersAsync(UserCollectionRequest collectionRequest)
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
        Task IUserManager.UpdateUserAsync(UserAddRequest updateRequest)
        {
            Contract.Requires<ArgumentNullException>(updateRequest != null);
            Contract.Requires<ArgumentException>(updateRequest.Id != null);

            return null;
        }
    }
}
