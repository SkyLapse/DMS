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
    /// The REST request for adding (or updating) a <see cref="User"/> to the remote DB.
    /// </summary>
    [Route("/users", "POST")]
    [Route("/users/{Id}", "PUT")]
    public class UserAddRequest : IReturnVoid
    {
        /// <summary>
        /// The <see cref="Category"/> to add.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The <see cref="Category"/>s Id.
        /// </summary>
        /// <remarks>Will be fetched from the <see cref="P:User"/>-property.</remarks>
        public String Id
        {
            get
            {
                User user = this.User;
                return (user != null) ? user.Id : null;
            }
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="User"/> into a <see cref="UserAddRequest"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to create a <see cref="UserAddRequest"/> from.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator UserAddRequest(User user)
        {
            Contract.Requires<ArgumentNullException>(user != null);

            return new UserAddRequest() { User = user };
        }
    }
}
