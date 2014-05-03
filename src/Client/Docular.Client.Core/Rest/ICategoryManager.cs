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
    /// Defines a mechanism for interacting with docular categories.
    /// </summary>
    [ContractClass(typeof(CategoryManagerContracts))]
    public interface ICategoryManager
    {
        /// <summary>
        /// Uploads a new <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="categoryRequest">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task AddCategoryAsync(CategoryAddRequest categoryAddRequest);

        /// <summary>
        /// Asynchronously deletes the specified <see cref="Category"/>.
        /// </summary>
        /// <param name="deleteRequest">The ID of the <see cref="Category"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteCategoryAsync(CategoryDeleteRequest deleteRequest);

        /// <summary>
        /// Gets the <see cref="Category"/> with the specified ID.
        /// </summary>
        /// <param name="categoryRequest">The id of the <see cref="Category"/> to get.</param>
        /// <returns>The <see cref="Category"/> with the specified ID, or <c>null</c> if it was not found.</returns>
        Task<Category> GetCategoryAsync(CategoryRequest categoryRequest);

        /// <summary>
        /// Gets all <see cref="Category"/>s that match the specified criteria.
        /// </summary>
        /// <param name="collectionRequest">A collection of parameters to filter by.</param>
        /// <returns></returns>
        Task<Category[]> GetCategoriesAsync(CategoryCollectionRequest collectionRequest);

        /// <summary>
        /// Gets the amount of <see cref="Category"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Category"/>s.</returns>
        Task<int> GetCategoryCountAsync();

        /// <summary>
        /// Uploads a changed <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="categoryRequest">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateCategoryAsync(CategoryAddRequest categoryRequest);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(ICategoryManager))]
    abstract class CategoryManagerContracts : ICategoryManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.AddCategoryAsync(CategoryAddRequest categoryRequest)
        {
            Contract.Requires<ArgumentNullException>(categoryRequest != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.DeleteCategoryAsync(CategoryDeleteRequest deleteRequest)
        {
            Contract.Requires<ArgumentNullException>(deleteRequest != null);
            Contract.Requires<ArgumentException>(deleteRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category> ICategoryManager.GetCategoryAsync(CategoryRequest categoryRequest)
        {
            Contract.Requires<ArgumentNullException>(categoryRequest != null);
            Contract.Requires<ArgumentException>(categoryRequest.Id != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category[]> ICategoryManager.GetCategoriesAsync(CategoryCollectionRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> ICategoryManager.GetCategoryCountAsync()
        {
            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.UpdateCategoryAsync(CategoryAddRequest categoryRequest)
        {
            Contract.Requires<ArgumentNullException>(categoryRequest != null);
            Contract.Requires<ArgumentException>(categoryRequest.Id != null);

            return null;
        }
    }
}
