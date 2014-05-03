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
    /// Contains filtering parameters for a <see cref="User"/> request.
    /// </summary>
    [Route("/users", "GET")]
    public class UserCollectionRequest : DefaultParameters, IReturn<User[]>
    {
        /// <summary>
        /// The default <see cref="UserCollectionRequest"/> returning all available <see cref="User"/>s.
        /// </summary>
        public static UserCollectionRequest Default
        {
            get
            {
                return new UserCollectionRequest();
            }
        }
    }
}
