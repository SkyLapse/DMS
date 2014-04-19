using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:CurrentPageContentSource"/>-property.
        /// </summary>
        public static readonly DependencyProperty CurrentContentProperty = DependencyProperty.Register("CurrentContent", typeof(object), typeof(Sidebar));

        /// <summary>
        /// The underlying <see cref="DependencyProperty"/> for the <see cref="P:CurrentlySelectedElement"/>-property.
        /// </summary>
        public static readonly DependencyProperty CurrentlySelectedElementProperty = DependencyProperty.Register(
            "CurrentlySelectedElement", 
            typeof(SidebarElement), 
            typeof(Sidebar),
            new PropertyMetadata(CurrentlySelectedElementChanged)
        );

        /// <summary>
        /// Used for synchronizing the selected state.
        /// </summary>
        private object isSelectedLock = new object();

        /// <summary>
        /// The current source of the page content of the selected sidebar element.
        /// </summary>
        public object CurrentContent
        {
            get
            {
                return (object)this.GetValue(CurrentContentProperty);
            }
            set
            {
                this.SetValue(CurrentContentProperty, value);
            }
        }
        
        /// <summary>
        /// The currently sselected <see cref="SidebarElement"/>.
        /// </summary>
        public SidebarElement CurrentlySelectedElement
        {
            get
            {
                return (SidebarElement)this.GetValue(CurrentlySelectedElementProperty);
            }
            set
            {
                this.SetValue(CurrentlySelectedElementProperty, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="Sidebar"/>.
        /// </summary>
        public Sidebar()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseDown-event occuring when the mouse was pressed on one of the sidebar elements.
        /// </summary>
        /// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        /// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        private void SidebarElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Contract.Assume(sender != null && e != null);

            SidebarElement sendingElement = (SidebarElement)sender;
            lock (this.isSelectedLock)
            {
                foreach (SidebarElement element in this.Content.Children.Cast<SidebarElement>().Except(new[] { sendingElement }).Where(element => element != null))
                {
                    element.IsSelected = false;
                }
                sendingElement.IsSelected = true;
                this.CurrentlySelectedElement = sendingElement;
            }
        }

        /// <summary>
        /// A callback handler for the event when the currently selected element changed.
        /// </summary>
        /// <param name="sender">The <see cref="DependencyObject"/> that raised the event.</param>
        /// <param name="e"><see cref="DependencyPropertyChangedEventArgs"/> describing the event.</param>
        public static void CurrentlySelectedElementChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentException>(e.NewValue != null);

            ((Sidebar)sender).CurrentContent = ((SidebarElement)e.NewValue).PageContent;
        }

        /// <summary>
        /// Event arguments for the event when the menu changed.
        /// </summary>
        public class MenuChangedEventArgs : EventArgs
        {
            /// <summary>
            /// The <see cref="Uri"/> of the source of the new page content.
            /// </summary>
            public Uri MenuPageContent { get; private set; }

            /// <summary>
            /// Initializes a new <see cref="MenuChangedEventArgs"/>.
            /// </summary>
            /// <param name="menuPageContent">The <see cref="Uri"/> of the source of the new page content.</param>
            public MenuChangedEventArgs(Uri menuPageContent)
            {
                Contract.Requires<ArgumentNullException>(menuPageContent != null);
            }
        }
    }
}
