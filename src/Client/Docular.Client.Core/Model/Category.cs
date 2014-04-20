using System;
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
    /// Represents a category.
    /// </summary>
    [ProtoContract]
    public class Category : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private Category _Parent;

        /// <summary>
        /// The <see cref="Category"/>s parent.
        /// </summary>
        [JsonProperty("parent"), ProtoMember(1)]
        public Category Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                if (value != _Parent)
                {
                    _Parent = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="Category"/>.
        /// </summary>
        public Category() { }

        /// <summary>
        /// Initializes a new <see cref="Category"/>.
        /// </summary>
        /// <param name="name">The <see cref="Category"/>s name.</param>
        public Category(String name)
        {
            this.Name = name;
        }
    }
}
