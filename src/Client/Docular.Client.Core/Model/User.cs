using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;
using ServiceStack.Text;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    [DataContract]
    public class User : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private String[] _Permissions;

        /// <summary>
        /// Gets the <see cref="User"/>s permission.
        /// </summary>
        [DataMember]
        public String[] Permissions
        {
            get
            {
                return _Permissions;
            }
            set
            {
                this.SetProperty(ref _Permissions, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="User"/>.
        /// </summary>
        public User() { }
    }
}
