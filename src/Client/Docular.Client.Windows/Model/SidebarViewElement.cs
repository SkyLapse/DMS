using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents an element in the sidebar.
    /// </summary>
    public class SidebarViewElement : ObservableObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private Path _Icon;

        /// <summary>
        /// The <see cref="SidebarViewElement"/>'s icon.
        /// </summary>
        public Path Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                this.SetProperty(ref _Icon, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="SidebarViewElement"/>.
        /// </summary>
        public SidebarViewElement() { }

        /// <summary>
        /// Initializes a new <see cref="SidebarViewElement"/>.
        /// </summary>
        public SidebarViewElement(String name, Path icon)
            : base(name)
        {
            this.Icon = icon;
        }
    }
}
