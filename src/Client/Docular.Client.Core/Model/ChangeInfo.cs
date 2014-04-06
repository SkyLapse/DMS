using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Contains information about a change of an item.
    /// </summary>
    public struct ChangeInfo
    {
        /// <summary>
        /// The <see cref="User"/> who made the change.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; private set; }

        /// <summary>
        /// The date and time of the change.
        /// </summary>
        [JsonProperty("date")]
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
