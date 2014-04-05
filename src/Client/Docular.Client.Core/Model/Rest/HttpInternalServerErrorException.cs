using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents the HTTP "Internal Server Error"-error.
    /// </summary>
    public class HttpInternalServerErrorException : HttpException
    {
        /// <summary>
        /// Initializes a new <see cref="HttpInternalServerErrorException"/>.
        /// </summary>
        public HttpInternalServerErrorException() : base("Internal Server Error", HttpStatusCode.InternalServerError) { }

        /// <summary>
        /// Initializes a new <see cref="HttpInternalServerErrorException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        public HttpInternalServerErrorException(String message) : base(message, HttpStatusCode.InternalServerError) { }

        /// <summary>
        /// Initializes a new <see cref="HttpInternalServerErrorException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="inner">The <see cref="Exception"/> that lead to this <see cref="Exception"/> to be thrown.</param>
        public HttpInternalServerErrorException(String message, Exception inner) : base(message, inner, HttpStatusCode.InternalServerError) { }
    }
}
