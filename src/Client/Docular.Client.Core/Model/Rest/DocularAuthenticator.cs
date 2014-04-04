using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Authenticates a REST-request with the docular DB.
    /// </summary>
    public class DocularAuthenticator : IAuthenticator
    {
        /// <summary>
        /// The <see cref="IKeyStore"/> used to obtain the key.
        /// </summary>
        public IKeyStore KeyStore { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="DocularAuthenticator"/>.
        /// </summary>
        /// <param name="keyStore">The <see cref="IKeyStore"/> used to obtain the API key.</param>
        public DocularAuthenticator(IKeyStore keyStore) 
        {
            Contract.Requires<ArgumentNullException>(keyStore != null);

            this.KeyStore = keyStore;
        }

        /// <summary>
        /// Authorizes the specified <see cref="IRestRequest"/>.
        /// </summary>
        /// <param name="client">The <see cref="IRestClient"/> that triggered the request.</param>
        /// <param name="request">The <see cref="IRestRequest"/> to be authenticated.</param>
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("API-KEY", this.KeyStore.GetKey());
        }
    }
}
