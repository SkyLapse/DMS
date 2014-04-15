using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Docular.Client.Windows.UI
{
    /// <summary>
    /// Interaktionslogik für SidebarEntry.xaml
    /// </summary>
    public partial class SidebarElement : UserControl
    {
        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:Icon"/>-property.
        /// </summary>
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Path), typeof(SidebarElement));

        /// <summary>
        /// The <see cref="SidebarElement"/>'s icon.
        /// </summary>
        [Bindable(true)]
        public Path Icon
        {
            get
            {
                return (Path)this.GetValue(IconProperty);
            }
            set
            {
                this.SetValue(IconProperty, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="SidebarElement"/>.
        /// </summary>
        public SidebarElement()
        {
            InitializeComponent();
        }
    }
}
