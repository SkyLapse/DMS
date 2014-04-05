using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents the HTTP "Not Found"-error.
    /// </summary>
    public class HttpNotFoundException : HttpException
    {
        /// <summary>
        /// Initializes a new <see cref="HttpNotFoundException"/>.
        /// </summary>
        public HttpNotFoundException() : base("Not Found", HttpStatusCode.NotFound) { }

        /// <summary>
        /// Initializes a new <see cref="HttpNotFoundException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        public HttpNotFoundException(String message) : base(message, HttpStatusCode.NotFound) { }

        /// <summary>
        /// Initializes a new <see cref="HttpNotFoundException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="inner">The <see cref="Exception"/> that lead to this <see cref="Exception"/> to be thrown.</param>
        public HttpNotFoundException(String message, Exception inner) : base(message, inner, HttpStatusCode.NotFound) { }
    }
}
