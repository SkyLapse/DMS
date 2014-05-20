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
    /// Contains information about a change of an item.
    /// </summary>
    [DataContract]
    public struct ChangeInfo
    {
        /// <summary>
        /// The date and time of the change.
        /// </summary>
        [DataMember]
        public DateTime Date { get; private set; }

        /// <summary>
        /// The ID of the <see cref="User"/> who made the change.
        /// </summary>
        [DataMember]
        public User User { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="ChangeInfo"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> who made the change.</param>
        /// <param name="date">The date and time of the change.</param>
        public ChangeInfo(User user, DateTime date)
            : this()
        {
            this.Date = date;
            this.User = user;
        }

        /// <summary>
        /// Initializes static properties.
        /// </summary>
        static ChangeInfo()
        {
            JsConfig<ChangeInfo>.TreatValueAsRefType = true;
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

            return (obj is ChangeInfo) && (this == ((ChangeInfo)obj));
        }

        /// <summary>
        /// Gets the object's hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return new { this.Date, this.User }.GetHashCode();
        }

        /// <summary>
        /// Checks two <see cref="ChangeInfo"/>s for equality.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> if both <see cref="ChangeInfo"/>s are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(ChangeInfo left, ChangeInfo right)
        {
            return (left.User == right.User) && (left.Date == right.Date);
        }

        /// <summary>
        /// Checks two <see cref="ChangeInfo"/>s for inequality.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> if both <see cref="ChangeInfo"/>s are inequal, otherwise <c>false</c>.</returns>
        public static bool operator !=(ChangeInfo left, ChangeInfo right)
        {
            return !(left == right);
        }
    }
}
