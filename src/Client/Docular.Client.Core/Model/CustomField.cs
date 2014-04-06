using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a custom field of some arbitrary data.
    /// </summary>
    public struct CustomField
    {
        /// <summary>
        /// Gets the custom field's key.
        /// </summary>
        [JsonProperty("key")]
        public String Key { get; private set; }

        /// <summary>
        /// Gets the custom field's value.
        /// </summary>
        [JsonProperty("value")]
        public String Value { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="CustomField"/>.
        /// </summary>
        /// <param name="key">The custom field's key.</param>
        /// <param name="value">The custom field's value.</param>
        public CustomField(String key, String value)
            : this()
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
