using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client
{
    /// <summary>
    /// Contains extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Combines the specified <see cref="Uri"/> with the given relative path.
        /// </summary>
        /// <param name="baseUri">The base-<see cref="Uri"/>.</param>
        /// <param name="relativePath">The <see cref="Uri"/> to attach.</param>
        /// <returns>The combined <see cref="Uri"/>.</returns>
        public static Uri Combine(this Uri baseUri, String relativePath)
        {
            Contract.Requires<ArgumentNullException>(baseUri != null);

            return baseUri.Combine((relativePath != null) ? new Uri(relativePath, UriKind.Relative) : null);
        }

        /// <summary>
        /// Combines the specified <see cref="Uri"/> with the given relative path.
        /// </summary>
        /// <param name="baseUri">The base-<see cref="Uri"/>.</param>
        /// <param name="relativePath">The <see cref="Uri"/> to attach.</param>
        /// <returns>The combined <see cref="Uri"/>.</returns>
        public static Uri Combine(this Uri baseUri, Uri relativePath)
        {
            Contract.Requires<ArgumentNullException>(baseUri != null);

            Uri result;
            if (!Uri.TryCreate(baseUri, relativePath, out result))
            {
                throw new InvalidOperationException("Concatenating the uris failed.");
            }
            return result;
        }

        /// <summary>
        /// Checks whether the specified <see cref="HttpStatusCode"/> is an error or not.
        /// </summary>
        /// <param name="statusCode">The <see cref="HttpStatusCode"/> to check.</param>
        /// <returns><c>true</c> if the specified <see cref="HttpStatusCode"/> represents an error, otherwise <c>false</c>.</returns>
        public static bool IsError(this HttpStatusCode statusCode)
        {
            return (int)statusCode >= 400;
        }
    }
}
