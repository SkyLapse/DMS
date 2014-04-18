using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
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
    public partial class SidebarElement : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:CenterColumnWidth"/>-property.
        /// </summary>
        public static DependencyProperty CenterColumnWidthProperty = DependencyProperty.Register(
            "CenterColumnWidth", 
            typeof(GridLength), 
            typeof(SidebarElement),
            new PropertyMetadata(new GridLength(40, GridUnitType.Star))
        );

        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:Icon"/>-property.
        /// </summary>
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Path), typeof(SidebarElement));

        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:IsSelected"/>-property.
        /// </summary>
        public static DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            "IsSelected", 
            typeof(bool), 
            typeof(SidebarElement)
        );

        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:PageContent"/>-property.
        /// </summary>
        public static DependencyProperty PageContentProperty = DependencyProperty.Register("PageContent", typeof(object), typeof(SidebarElement));

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The width of the center column.
        /// </summary>
        [Bindable(true, BindingDirection.TwoWay)]
        public GridLength CenterColumnWidth
        {
            get
            {
                return (GridLength)(this.GetValue(CenterColumnWidthProperty) ?? default(GridLength));
            }
            set
            {
                this.SetValue(CenterColumnWidthProperty, value);
            }
        }

        /// <summary>
        /// The <see cref="SidebarElement"/>'s icon.
        /// </summary>
        [Bindable(true, BindingDirection.TwoWay)]
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
        /// Indicates whether the <see cref="SidebarElement"/> is selected or not.
        /// </summary>
        [Bindable(true, BindingDirection.TwoWay)]
        public bool IsSelected
        {
            get
            {
                return (bool)(this.GetValue(IsSelectedProperty) ?? false);
            }
            set
            {
                this.SetValue(IsSelectedProperty, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="SidebarElement"/>.
        /// </summary>
        public SidebarElement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event arguments for the <see cref="E:Selected"/>-event.
        /// </summary>
        public class SelectedEventArgs : EventArgs
        {
            /// <summary>
            /// The new content of the selected sidebar element.
            /// </summary>
            public object NewPageContent { get; private set; }

            /// <summary>
            /// Initializes a new <see cref="SelectedEventArgs"/>.
            /// </summary>
            /// <param name="newPageContent">The new content of the selected sidebar element.</param>
            public SelectedEventArgs(object newPageContent)
            {
                this.NewPageContent = newPageContent;
            }
        }
    }
}
