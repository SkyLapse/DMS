using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents the reqired data for authorizating a new client.
    /// </summary>
    public struct AuthorizationData
    {
        /// <summary>
        /// The current machine's name.
        /// </summary>
        public String MachineName { get; private set; }

        /// <summary>
        /// The username.
        /// </summary>
        public String Username { get; private set; }

        /// <summary>
        /// The users' password.
        /// </summary>
        public String Password { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="AuthorizationData"/>.
        /// </summary>
        /// <param name="machineName">The current machine's name.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The users' password.</param>
        public AuthorizationData(String machineName, String username, String password)
            :this()
        {
            this.MachineName = machineName;
            this.Username = username;
            this.Password = password;
        }
    }
}
