﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;
using ProtoBuf;
using RestSharp.Portable;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    [ProtoContract]
    public class User : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private String[] _Permissions;

        /// <summary>
        /// Gets the <see cref="User"/>s permission.
        /// </summary>
        [JsonProperty("permissions"), ProtoMember(1)]
        public String[] Permissions
        {
            get
            {
                return _Permissions;
            }
            set
            {
                if (value != _Permissions)
                {
                    _Permissions = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="User"/>.
        /// </summary>
        public User() { }
    }
}
