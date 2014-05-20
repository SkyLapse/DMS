using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a custom field of some arbitrary data.
    /// </summary>
    [DataContract]
    public struct CustomField
    {
        /// <summary>
        /// Gets the custom field's key.
        /// </summary>
        [DataMember]
        public String Key { get; private set; }

        /// <summary>
        /// Gets the custom field's value.
        /// </summary>
        [DataMember]
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

        /// <summary>
        /// Initializes static properties.
        /// </summary>
        static CustomField()
        {
            JsConfig<CustomField>.TreatValueAsRefType = true;
        }

        /// <summary>
        /// Checks whether the current object equals the specified object.
        /// </summary>
        /// <param name="obj">The object to test for equality with.</param>
        /// <returns><c>true</c> if the objects are equal, otherwise <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            return (obj is CustomField) && (this == ((CustomField)obj));
        }

        /// <summary>
        /// Gets the object's hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return new { this.Key, this.Value }.GetHashCode();
        }

        /// <summary>
        /// Checks two <see cref="CustomField"/>s for equality.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> if both <see cref="CustomField"/>s are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(CustomField left, CustomField right)
        {
            return (left.Key == right.Key) && (left.Value == right.Value);
        }

        /// <summary>
        /// Checks two <see cref="CustomField"/>s for inequality.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> if both <see cref="CustomField"/>s are inequal, otherwise <c>false</c>.</returns>
        public static bool operator !=(CustomField left, CustomField right)
        {
            return !(left == right);
        }
    }
}
