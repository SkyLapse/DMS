using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Model.Rest
{
    /// <summary>
    /// Defines a mechanism for obtaining a <see cref="Document"/>s locally saved content.
    /// </summary>
    [ContractClass(typeof(ContentReceiverContracts))]
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

    /// <summary>
    /// Contains contract definitions for <see cref="IContentReceiver"/>.
    /// </summary>
    [ContractClassFor(typeof(IContentReceiver))]
    abstract class ContentReceiverContracts : IContentReceiver
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        Stream IContentReceiver.GetLocalContent(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            Contract.Ensures(Contract.Result<Stream>() != null);

            return null;
        }

        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        String IContentReceiver.GetFileName(Document document)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            Contract.Ensures(Contract.Result<String>() != null);

            return null;
        }
    }
}
