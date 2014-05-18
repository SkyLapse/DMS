using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest.Requests
{
    /// <summary>
    /// Represents a REST request obtaining the <see cref="User"/> associated with the current login data.
    /// </summary>
    [Route("/users/current", "GET")]
    public class UserCurrentRequest : IReturn<User> { }
}
