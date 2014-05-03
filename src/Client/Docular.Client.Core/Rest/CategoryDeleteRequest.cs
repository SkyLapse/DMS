﻿using System;
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
    /// The REST-Request for deleting a specific <see cref="Category"/>.
    /// </summary>
    [Route("/categories/{Id}", "DELETE")]
    public class CategoryDeleteRequest : IdVoidRequest
    {
        /// <summary>
        /// Implicitly converts the <see cref="Category"/> into a <see cref="CategoryDeleteRequest"/>.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator CategoryDeleteRequest(Category category)
        {
            Contract.Requires<ArgumentNullException>(category != null);

            return new CategoryDeleteRequest() { Id = category.Id };
        }

        /// <summary>
        /// Implicitly converts the category ID into a <see cref="CategoryDeleteRequest"/>.
        /// </summary>
        /// <param name="id">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator CategoryDeleteRequest(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return new CategoryDeleteRequest() { Id = id };
        }
    }
}