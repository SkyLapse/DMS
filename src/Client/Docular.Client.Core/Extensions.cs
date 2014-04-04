using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core
{
    /// <summary>
    /// Contains extension methods.
    /// </summary>
    public static class Extensions
    {
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
