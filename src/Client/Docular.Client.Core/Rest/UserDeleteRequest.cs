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
    /// The REST-Request for deleting a specific <see cref="User"/>.
    /// </summary>
    [Route("/users/{Id}", "DELETE")]
    public class UserDeleteRequest : IdVoidRequest
    {
        /// <summary>
        /// Implicitly converts the <see cref="Category"/> into a <see cref="UserDeleteRequest"/>.
        /// </summary>
        /// <param name="User">The <see cref="User"/> to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator UserDeleteRequest(User User)
        {
            Contract.Requires<ArgumentNullException>(User != null);

            return new UserDeleteRequest() { Id = User.Id };
        }

        /// <summary>
        /// Implicitly converts the User ID into a <see cref="UserDeleteRequest"/>.
        /// </summary>
        /// <param name="category">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator UserDeleteRequest(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            return new UserDeleteRequest() { Id = id };
        }
    }
}
