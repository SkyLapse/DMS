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
    /// The REST request used to retreive a single <see cref="User"/>.
    /// </summary>
    [Route("/users/{Id}", "GET")]
    public class UserRequest : IdRequest<Tag>
    {
        /// <summary>
        /// Implicitly converts the specified <see cref="User"/>-ID into a <see cref="UserRequest"/>.
        /// </summary>
        /// <param name="userId">The ID to convert.</param>
        /// <returns>The conversion result.</returns>
        public static implicit operator UserRequest(String userId)
        {
            return (userId != null) ? new UserRequest() { Id = userId } : null;
        }
    }
}
