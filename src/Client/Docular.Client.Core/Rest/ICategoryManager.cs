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
    [ContractClass(typeof(ICategoryManagerContracts))]
    public interface ICategoryManager
    {
        /// <summary>
        /// Uploads a new <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task AddCategoryAsync(Category category);

        /// <summary>
        /// Asynchronously deletes the specified <see cref="Category"/>.
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteCategoryAsync(String categoryId);

        /// <summary>
        /// Gets the <see cref="Category"/> with the specified ID.
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to get.</param>
        /// <returns>The <see cref="Category"/> with the specified ID, or <c>null</c> if it was not found.</returns>
        Task<Category> GetCategoryAsync(String categoryId);

        /// <summary>
        /// Gets all <see cref="Category"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filter">A collection of parameters to filter by.</param>
        /// <returns></returns>
        Task<Category[]> GetCategoriesAsync(CategoryCollectionParameters filter);

        /// <summary>
        /// Gets the amount of <see cref="Category"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Category"/>s.</returns>
        Task<int> GetCategoryCountAsync();

        /// <summary>
        /// Uploads a changed <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task UpdateCategoryAsync(Category category);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(ICategoryManager))]
    abstract class ICategoryManagerContracts : ICategoryManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.AddCategoryAsync(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.DeleteCategoryAsync(String categoryId)
        {
            Contract.Requires<ArgumentNullException>(categoryId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category> ICategoryManager.GetCategoryAsync(String categoryId)
        {
            Contract.Requires<ArgumentNullException>(categoryId != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category[]> ICategoryManager.GetCategoriesAsync(CategoryCollectionParameters request)
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
        Task ICategoryManager.UpdateCategoryAsync(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);
            Contract.Requires<ArgumentException>(category.Id != null);

            return null;
        }
    }
}
