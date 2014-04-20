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
    /// Represents a tag.
    /// </summary>
    [ProtoContract]
    public class Tag : DocularObject
    {
        /// <summary>
        /// Initializes a new <see cref="Tag"/>.
        /// </summary>
        public Tag() { }

        /// <summary>
        /// Initializes a new <see cref="Tag"/>.
        /// </summary>
        /// <param name="description">The <see cref="Tag"/>s description.</param>
        /// <param name="name">The <see cref="Tag"/>s name.</param>
        public Tag(String name, String description) 
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
