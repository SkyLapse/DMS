using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;

namespace Docular.Client.Core.Controller
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
        /// <param name="category">The <see cref="Category"/> to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous deleting process.</returns>
        Task DeleteCategoryAsync(Category category);

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
        /// <param name="user">The <see cref="User"/> who created the <see cref="Category"/>. If null is specified, there will be no filtering.</param>
        /// <param name="parent">The parent <see cref="Category"/> it has to be a child of. If null is specified, there will be no filtering.</param>
        /// <returns></returns>
        Task<Category[]> GetCategoriesAsync(User user = null, Category parent = null);

        /// <summary>
        /// Gets all <see cref="Category"/>s that match the specified criteria.
        /// </summary>
        /// <param name="userId">
        /// The ID of the <see cref="User"/> who created the <see cref="Category"/>. If null is specified, there will be no filtering.
        /// </param>
        /// <param name="parentId">
        /// The ID of the parent <see cref="Category"/> it has to be a child of. If null is specified, there will be no filtering.
        /// </param>
        /// <returns></returns>
        Task<Category[]> GetCategoriesAsync(String userId = null, String parentId = null);

        /// <summary>
        /// Gets the amount of <see cref="Category"/>s.
        /// </summary>
        /// <returns>The amount of stored <see cref="Category"/>s.</returns>
        Task<int> GetCategoryCountAsync();

        /// <summary>
        /// Uploads a new / changed <see cref="Category"/> to the server.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to upload.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous uploading process.</returns>
        Task PostCategoryAsync(Category category);
    }

    /// <summary>
    /// Contains contract definitions.
    /// </summary>
    [ContractClassFor(typeof(ICategoryManager))]
    abstract class CategoryManagerContracts
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task ICategoryManager.DeleteCategoryAsync(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }

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
            Contract.Ensures(Contract.Result<Category[]>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category[]> ICategoryManager.GetCategoriesAsync(User user, Category parent)
        {
            Contract.Requires<ArgumentNullException>(user != null);
            Contract.Requires<ArgumentNullException>(parent != null);
            Contract.Ensures(Contract.Result<Category[]>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<Category[]> ICategoryManager.GetCategoriesAsync(String userId, String parentId)
        {
            Contract.Requires<ArgumentNullException>(userId != null);
            Contract.Requires<ArgumentNullException>(parentId != null);
            Contract.Ensures(Contract.Result<Category[]>() != null);

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
    }
}
