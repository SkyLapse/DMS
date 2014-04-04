using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Defines a platform-agnostic mechanism to obtain an API key for a user.
    /// </summary>
    public interface IKeyStore
    {
        /// <summary>
        /// Retreives the API key for the current user.
        /// </summary>
        /// <returns>The newly generated API key.</returns>
        String GetKey();
    }
}
