using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Serializers;

namespace Docular.Client.Rest
{
    /// <summary>
    /// A custom RestSharp protobuf (de)serializer.
    /// </summary>
    public class DocularProtobufSerializer : ISerializer, IDeserializer
    {
        /// <summary>
        /// The mime type.
        /// </summary>
        public System.Net.Http.Headers.MediaTypeHeaderValue ContentType { get; set; }

        /// <summary>
        /// Initializes a new <see cref="DocularProtobufSerializer"/>.
        /// </summary>
        public DocularProtobufSerializer()
        {
            this.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/protobuf");
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
            {
                return ProtoBuf.Serializer.Deserialize<T>(ms);
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
            {
                ProtoBuf.Meta.RuntimeTypeModel.Default.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
