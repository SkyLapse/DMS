using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Defines mechanisms to work with docular API keys.
    /// </summary>
    [ContractClass(typeof(IApiKeyManagerContracts))]
    public interface IApiKeyManager
    {
        /// <summary>
        /// Gets a new key from the server.
        /// </summary>
        /// <param name="machineName">The name of the current machine.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="username">The user's name.</param>
        /// <returns>A new API key.</returns>
        Task<String> GetKey(String username, String password, String machineName);

        /// <summary>
        /// Checks whether the specified API key is still valid.
        /// </summary>
        /// <param name="key">The key to validate.</param>
        /// <returns><c>true</c> if the key is valid, otherwise <c>false</c>.</returns>
        Task<bool> ValidateKey(String key); 
    }

    /// <summary>
    /// Contains contract definitions for <see cref="IApiKeyManager"/>.
    /// </summary>
    [ContractClassFor(typeof(IApiKeyManager))]
    abstract class IApiKeyManagerContracts : IApiKeyManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<String> IApiKeyManager.GetKey(String username, String password, String machineName)
        {
            Contract.Requires<ArgumentException>(machineName != null);
            Contract.Requires<ArgumentException>(password != null);
            Contract.Requires<ArgumentException>(username != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<bool> IApiKeyManager.ValidateKey(String key)
        {
            Contract.Requires<ArgumentNullException>(key != null);

            return null;
        }
    }
}
