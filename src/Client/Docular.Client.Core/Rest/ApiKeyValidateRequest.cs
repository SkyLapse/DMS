using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// A REST request used for validating an existing API key.
    /// </summary>
    [Route("/keys/validate", "POST")]
    public class ApiKeyValidateRequest : IReturn<bool>
    {
        /// <summary>
        /// The api key to validate.
        /// </summary>
        public String Key { get; set; }
    }
}
