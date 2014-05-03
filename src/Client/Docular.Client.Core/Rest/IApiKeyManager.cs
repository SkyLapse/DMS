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
    [ContractClass(typeof(ApiKeyManagerContracts))]
    public interface IApiKeyManager
    {
        /// <summary>
        /// Gets a new key from the server.
        /// </summary>
        /// <param name="keyRequest">The REST request used to obtain the key.</param>
        /// <returns>A new API key.</returns>
        Task<String> GetKey(ApiKeyRequest keyRequest);

        /// <summary>
        /// Checks whether the specified API key is still valid.
        /// </summary>
        /// <param name="validateRequest">A REST request containing the key to be validated.</param>
        /// <returns><c>true</c> if the key is valid, otherwise <c>false</c>.</returns>
        Task<bool> ValidateKey(ApiKeyValidateRequest validateRequest); 
    }

    /// <summary>
    /// Contains contract definitions for <see cref="IApiKeyManager"/>.
    /// </summary>
    [ContractClassFor(typeof(IApiKeyManager))]
    abstract class ApiKeyManagerContracts : IApiKeyManager
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<string> IApiKeyManager.GetKey(ApiKeyRequest keyRequest)
        {
            Contract.Requires<ArgumentNullException>(keyRequest != null);
            Contract.Requires<ArgumentException>(keyRequest.MachineName != null);
            Contract.Requires<ArgumentException>(keyRequest.Password != null);
            Contract.Requires<ArgumentException>(keyRequest.Username != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Task<bool> IApiKeyManager.ValidateKey(ApiKeyValidateRequest validateRequest)
        {
            Contract.Requires<ArgumentNullException>(validateRequest != null);
            Contract.Requires<ArgumentException>(validateRequest.Key != null);

            return null;
        }
    }
}
