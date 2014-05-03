using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// A REST request used to obtain a new key.
    /// </summary>
    [Route("/keys", "POST")]
    public class ApiKeyRequest : IReturn<String>
    {
        /// <summary>
        /// The current machine name.
        /// </summary>
        public String MachineName { get; set; }

        /// <summary>
        /// The username of the user to obtain an API key of.
        /// </summary>
        public String Username { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public String Password { get; set; }
    }
}
