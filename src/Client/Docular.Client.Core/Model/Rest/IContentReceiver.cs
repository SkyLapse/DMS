using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Defines a mechanism for obtaining a <see cref="Document"/>s locally saved content.
    /// </summary>
    public interface IContentReceiver
    {
        /// <summary>
        /// Gets the <see cref="Document"/>s local content.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> of which the content to get.</param>
        /// <returns>
        /// A <see cref="Stream"/> wrapping the local <see cref="Document"/>s content or <c>null</c>, if the content is not locally available.
        /// </returns>
        Stream GetLocalContent(Document document);

        /// <summary>
        /// Gets the file name including extension of the specified <see cref="Document"/>.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> of which the file name to get.</param>
        /// <returns>The <see cref="Document"/>s full file name.</returns>
        String GetFileName(Document document);
    }
}
