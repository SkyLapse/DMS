using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents the HTTP "Unauthorized"-error.
    /// </summary>
    public class HttpUnauthorizedException : HttpException
    {
        /// <summary>
        /// Initializes a new <see cref="HttpUnauthorizedException"/>.
        /// </summary>
        public HttpUnauthorizedException() : base("Unauthorized", HttpStatusCode.Unauthorized) { }

        /// <summary>
        /// Initializes a new <see cref="HttpUnauthorizedException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        public HttpUnauthorizedException(String message) : base(message, HttpStatusCode.Unauthorized) { }

        /// <summary>
        /// Initializes a new <see cref="HttpUnauthorizedException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="inner">The <see cref="Exception"/> that lead to this <see cref="Exception"/> to be thrown.</param>
        public HttpUnauthorizedException(String message, Exception inner) : base(message, inner, HttpStatusCode.Unauthorized) { }
    }
}
