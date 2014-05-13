using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    [DataContract]
    public class Category : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private Category _Parent;

        /// <summary>
        /// The <see cref="Category"/>s parent.
        /// </summary>
        [IgnoreDataMember]
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
    }
}
