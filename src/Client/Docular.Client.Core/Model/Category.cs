using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private Category _Parent;

        /// <summary>
        /// The <see cref="Category"/>s parent.
        /// </summary>
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
