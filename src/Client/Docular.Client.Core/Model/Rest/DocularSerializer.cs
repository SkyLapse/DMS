using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Serializers;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// A custom RestSharp (de)serializer for proper date handling.
    /// </summary>
    public class DocularSerializer : ISerializer, IDeserializer
    {
        /// <summary>
        /// The content type.
        /// </summary>
        public System.Net.Http.Headers.MediaTypeHeaderValue ContentType { get; set; }

        /// <summary>
        /// Initializes a new <see cref="DocularSerializer"/>.
        /// </summary>
        public DocularSerializer()
        {
            this.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                CharSet = Encoding.UTF8.WebName
            };
        }

        /// <summary>
        /// Deserializes an object of the specified <see cref="Type"/> from the <see cref="RestSharp.Portable.IRestResponse"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to deserialize to.</typeparam>
        /// <param name="response">The <see cref="RestSharp.Portable.IRestResponse"/>.</param>
        /// <returns>The deserialized instance.</returns>
        public T Deserialize<T>(RestSharp.Portable.IRestResponse response)
        {
            using (MemoryStream ms = new MemoryStream(response.RawBytes))
            using (StreamReader sr = new StreamReader(ms))
            using (JsonTextReader jtr = new JsonTextReader(sr))
            {
                return new Newtonsoft.Json.JsonSerializer()
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat
                }.Deserialize<T>(jtr);
            }
        }

        /// <summary>
        /// Serializes an object to a byte-array.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The serialized data.</returns>
        public byte[] Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                new Newtonsoft.Json.JsonSerializer()
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat
                }.Serialize(sw, obj);
                return ms.ToArray();
            }
        }
    }
}
