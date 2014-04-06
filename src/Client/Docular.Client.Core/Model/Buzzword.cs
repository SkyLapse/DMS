using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a buzzword in a text.
    /// </summary>
    public struct Buzzword
    {
        /// <summary>
        /// The commonness of the word inside the text.
        /// </summary>
        public float Commonness { get; private set; }

        /// <summary>
        /// The buzzword itself.
        /// </summary>
        public String Value { get; private set; }
        
        /// <summary>
        /// Initializes a new <see cref="Buzzword"/>.
        /// </summary>
        /// <param name="value">The buzzword itself.</param>
        /// <param name="commonness">The commonness of the word inside the text.</param>
        public Buzzword(String value, float commonness)
            : this()
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentException>(!value.Contains(" "));

            this.Commonness = commonness;
            this.Value = value;
        }

        /// <summary>
        /// Converts the <see cref="Buzzword"/> into a <see cref="String"/>.
        /// </summary>
        /// <returns>The buzzword.</returns>
        public override String ToString()
        {
            return this.Value;
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="Buzzword"/> into a <see cref="String"/>.
        /// </summary>
        /// <param name="buzzword">The <see cref="Buzzword"/> to convert.</param>
        /// <returns>The buzzword.</returns>
        public static implicit operator String(Buzzword buzzword)
        {
            return buzzword.Value;
        }
    }
}
