using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents the HTTP "Method Not Allowed"-error.
    /// </summary>
    public class HttpMethodNotAllowedException : HttpException
    {
        /// <summary>
        /// Initializes a new <see cref="HttpInternalServerErrorException"/>.
        /// </summary>
        public HttpMethodNotAllowedException() : base("Method Not Allowed", HttpStatusCode.MethodNotAllowed) { }

        /// <summary>
        /// Initializes a new <see cref="HttpInternalServerErrorException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        public HttpMethodNotAllowedException(String message) : base(message, HttpStatusCode.MethodNotAllowed) { }

        /// <summary>
        /// Initializes a new <see cref="HttpInternalServerErrorException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="inner">The <see cref="Exception"/> that lead to this <see cref="Exception"/> to be thrown.</param>
        public HttpMethodNotAllowedException(String message, Exception inner) : base(message, inner, HttpStatusCode.MethodNotAllowed) { }
    }
}
