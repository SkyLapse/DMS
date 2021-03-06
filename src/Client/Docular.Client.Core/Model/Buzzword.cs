﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a buzzword in a text.
    /// </summary>
    [DataContract]
    public struct Buzzword
    {
        /// <summary>
        /// The commonness of the word inside the text.
        /// </summary>
        [DataMember]
        public float Commonness { get; private set; }

        /// <summary>
        /// The buzzword itself.
        /// </summary>
        [DataMember]
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
            Contract.Requires<ArgumentOutOfRangeException>(commonness >= 0.0f);
            Contract.Requires<ArgumentException>(!value.Contains(" "));

            this.Commonness = commonness;
            this.Value = value;
        }

        /// <summary>
        /// Initializes static properties.
        /// </summary>
        static Buzzword()
        {
            JsConfig<Buzzword>.TreatValueAsRefType = true;
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

            return (obj is Buzzword) && (this == ((Buzzword)obj));
        }

        /// <summary>
        /// Gets the object's hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return new { this.Commonness, this.Value }.GetHashCode();
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

        /// <summary>
        /// Checks two <see cref="Buzzword"/>s for equality.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> if both <see cref="Buzzword"/>s are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(Buzzword left, Buzzword right)
        {
            return (left.Value == right.Value) && (left.Commonness == right.Commonness);
        }

        /// <summary>
        /// Checks two <see cref="Buzzword"/>s for inequality.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> if both <see cref="Buzzword"/>s are inequal, otherwise <c>false</c>.</returns>
        public static bool operator !=(Buzzword left, Buzzword right)
        {
            return !(left == right);
        }
    }
}
