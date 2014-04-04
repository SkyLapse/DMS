using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Represents an HTTP error.
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// The <see cref="HttpStatusCode"/>.
        /// </summary>
        public HttpStatusCode StatusCode { get; protected set; }

        /// <summary>
        /// Initializes a new <see cref="HttpException"/>.
        /// </summary>
        public HttpException() { }

        /// <summary>
        /// Initializes a new <see cref="HttpException"/>.
        /// </summary>
        /// <param name="statusCode">The <see cref="HttpStatusCode"/>.</param>
        public HttpException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new <see cref="HttpException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        public HttpException(String message) : base(message) { }

        /// <summary>
        /// Initializes a new <see cref="HttpException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="statusCode">The <see cref="HttpStatusCode"/>.</param>
        public HttpException(String message, HttpStatusCode statusCode)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new <see cref="HttpException"/>.
        /// </summary>
        /// <param name="message">The <see cref="Exception"/> message.</param>
        /// <param name="inner">The <see cref="Exception"/> that lead to this <see cref="Exception"/> to be thrown.</param>
        public HttpException(String message, Exception inner) : base(message, inner) { }
    }
}
