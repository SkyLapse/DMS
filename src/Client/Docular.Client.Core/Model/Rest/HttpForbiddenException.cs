using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents the HTTP "Forbidden"-error.
    /// </summary>
    public class HttpForbiddenException : HttpException
    {
        /// <summary>
        /// Initializes a new <see cref="HttpForbiddenException"/>.
        /// </summary>
        public HttpForbiddenException() : base("Forbidden", HttpStatusCode.Forbidden) { }

        /// <summary>
        /// Initializes a new <see cref="HttpForbiddenException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        public HttpForbiddenException(String message) : base(message, HttpStatusCode.Forbidden) { }

        /// <summary>
        /// Initializes a new <see cref="HttpForbiddenException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="inner">The <see cref="Exception"/> that lead to this <see cref="Exception"/> to be thrown.</param>
        public HttpForbiddenException(String message, Exception inner) : base(message, inner, HttpStatusCode.Forbidden) { }
    }
}
