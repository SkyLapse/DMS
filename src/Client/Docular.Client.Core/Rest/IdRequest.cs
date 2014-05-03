using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Returns a single element by its ID.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of element to obtain.</typeparam>
    public abstract class IdRequest<T> : IReturn<T>
    {
        /// <summary>
        /// The ID of the element to retreive.
        /// </summary>
        public String Id { get; set; }
    }
}
