using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.Windows
{
    /// <summary>
    /// Retreives the API key for an app instance.
    /// </summary>
    public class WindowsKeyStore : IKeyStore
    {
        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <returns>The API key.</returns>
        public String GetKey()
        {
            throw new NotImplementedException();
        }
    }
}
