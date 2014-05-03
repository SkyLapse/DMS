using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a custom field of some arbitrary data.
    /// </summary>
    public struct CustomField
    {
        /// <summary>
        /// Gets the custom field's key.
        /// </summary>
        public String Key { get; private set; }

        /// <summary>
        /// Gets the custom field's value.
        /// </summary>
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
