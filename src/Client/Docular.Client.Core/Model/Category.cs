using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model.Rest;
using Newtonsoft.Json;
using ProtoBuf;
using RestSharp.Portable;

namespace Docular.Client.Model
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
                this.SetProperty(ref _Parent, value);
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
