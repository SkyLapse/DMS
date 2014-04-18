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
    /// Interaktionslogik für Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:CurrentPageContent"/>-property.
        /// </summary>
        public static DependencyProperty CurrentPageContentProperty = DependencyProperty.Register("CurrentPageContent", typeof(object), typeof(Sidebar));

        /// <summary>
        /// The content of the currently displayed page.
        /// </summary>
        [Bindable(true, BindingDirection.OneWay)]
        public object CurrentPageContent
        {
            get
            {
                return this.GetValue(CurrentPageContentProperty);
            }
            protected set
            {
                this.SetValue(CurrentPageContentProperty, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="Sidebar"/>.
        /// </summary>
        public Sidebar()
        {
            InitializeComponent();
        }

        private void SidebarElement_Selected(object sender, SidebarElement.SelectedEventArgs e)
        {
            this.CurrentPageContent = e.NewPageContent;
        }
    }
}
