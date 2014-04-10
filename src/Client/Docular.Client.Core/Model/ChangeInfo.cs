using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoBuf;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Contains information about a change of an item.
    /// </summary>
    [ProtoContract]
    public struct ChangeInfo
    {
        /// <summary>
        /// The <see cref="User"/> who made the change.
        /// </summary>
        [JsonProperty("user"), ProtoMember(1)]
        public User User { get; private set; }

        /// <summary>
        /// The date and time of the change.
        /// </summary>
        [JsonProperty("date"), ProtoMember(2)]
        public DateTime Date { get; private set; }

        /// <summary>
        /// Initializes a new <see cref="ChangeInfo"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> who made the change.</param>
        /// <param name="date">The date and time of the change.</param>
        public ChangeInfo(User user, DateTime date)
            : this()
        {
            this.User = user;
            this.Date = date;
        }
    }
}
