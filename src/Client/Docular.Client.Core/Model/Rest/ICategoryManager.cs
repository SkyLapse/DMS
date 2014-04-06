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
    /// Defines a mechanism for interacting with docular categories.
    /// </summary>
    [ContractClass(typeof(CategoryManagerContracts))]
    public interface ICategoryManager
    {
        /// <summary>
        /// Asynchronously deletes the specified <see cref="Category"/>.
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteCategoryAsync(String categoryId);

        /// <summary>
        /// Gets the <see cref="Category"/> with the specified ID.
        /// </summary>
        /// <param name="id">The id of the <see cref="Category"/> to get.</param>
        /// <returns>The <see cref="Category"/> with the specified ID, or <c>null</c> if it was not found.</returns>
        Task<Category> GetCategoryAsync(String id);

        /// <summary>
        /// Gets all <see cref="Category"/>s that match the specified criteria.
        /// </summary>
        /// <param name="filterParameters">A collection of <see cref="Parameter"/>s to filter by.</param>
        /// <returns></returns>
        Task<Category[]> GetCategoriesAsync(params Parameter[] filterParameters);

        /// <summary>
        /// Gets the amount of <see cref="Category"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Category"/>s.</returns>
        Task<int> GetCategoryCountAsync();

        /// <summary>
        /// Uploads a new <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PostCategoryAsync(Category category);

        /// <summary>
        /// Uploads a changed <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PutCategoryAsync(Category category);
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
        Task ICategoryManager.DeleteCategoryAsync(String categoryId)
        {
            Contract.Requires<ArgumentNullException>(categoryId != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category> ICategoryManager.GetCategoryAsync(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Ensures(Contract.Result<Task<Category>>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category[]> ICategoryManager.GetCategoriesAsync(params Parameter[] filterParameters)
        {
            Contract.Requires<ArgumentNullException>(filterParameters != null);
            Contract.Requires<ArgumentException>(filterParameters.All(filterParam => filterParam.Type == ParameterType.GetOrPost));
            Contract.Ensures(Contract.Result<Task<Category[]>>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<int> ICategoryManager.GetCategoryCountAsync()
        {
            Contract.Ensures(Contract.Result<Task<int>>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.PostCategoryAsync(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.PutCategoryAsync(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);
            Contract.Requires<ArgumentNullException>(category.Id != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }
    }
}
