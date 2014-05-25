using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a thumbnail.
    /// </summary>
    public class Thumbnail : BinaryObject
    {
        /// <summary>
        /// Nothing to save here ;)
        /// </summary>
        /// <returns>A finished <see cref="Task"/>.</returns>
        public override Task SaveAsync()
        {
            return Task.FromResult((object)null);
        }
    }
}
