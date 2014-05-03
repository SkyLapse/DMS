using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Represents a REST request with an ID returning nothing..
    /// </summary>
    public abstract class IdVoidRequest : IReturnVoid
    {
        /// <summary>
        /// The ID of the <see cref="Category"/> to delete.
        /// </summary>
        public String Id { get; set; }
    }
}
