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
using Docular.Client.ViewModel;

namespace Docular.Client.View
{
    /// <summary>
    /// Interaktionslogik für SidebarView.xaml
    /// </summary>
    public partial class SidebarView : UserControl
    {
        /// <summary>
        /// Initializes a new <see cref="SidebarView"/>.
        /// </summary>
        public SidebarView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles a change in source collection of the sidebar elements.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e"><see cref="DataTransferEventArgs"/>.</param>
        private void ElementControl_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (this.ElementControl.Items.Count > 0)
            {
                DockPanel.SetDock((UIElement)this.ElementControl.ItemContainerGenerator.ContainerFromIndex(this.ElementControl.Items.Count - 1), Dock.Bottom);
            }
        }
    }
}
