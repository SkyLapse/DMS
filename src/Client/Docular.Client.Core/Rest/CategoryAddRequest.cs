using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// The REST request to add (or update) a <see cref="Document"/> to the remote DB.
    /// </summary>
    [Route("/categories", "POST")]
    [Route("/categories/{Id}", "PUT")]
    public class CategoryAddRequest : IReturnVoid
    {
        /// <summary>
        /// The <see cref="Category"/> to add.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// The <see cref="Category"/>s Id.
        /// </summary>
        /// <remarks>Will be fetched from the <see cref="P:Category"/>-property.</remarks>
        public String Id
        {
            get
            {
                Category category = this.Category;
                return (category != null) ? category.Id : null;
            }
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Category"/> into a <see cref="CategoryAddRequest"/>.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to create a <see cref="CategoryAddRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator CategoryAddRequest(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);

            return new CategoryAddRequest() { Category = category };
        }
    }
}
