using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// The REST request used to retreive a single <see cref="Category"/>.
    /// </summary>
    [Route("/categories/{Id}", "GET")]
    public class CategoryRequest : IdRequest<Category>
    {
        /// <summary>
        /// Implicitly converts the specified <see cref="Category"/>-ID into a <see cref="CategoryRequest"/>.
        /// </summary>
        /// <param name="categoryId">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator CategoryRequest(String categoryId)
        {
            return (categoryId != null) ? new CategoryRequest() { Id = categoryId } : null;
        }
    }
}
