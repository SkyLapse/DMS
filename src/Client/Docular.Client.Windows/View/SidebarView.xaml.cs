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

namespace Docular.Client.View
{
    /// <summary>
    /// Interaktionslogik für SidebarView.xaml
    /// </summary>
    public partial class SidebarView : UserControl
    {
        ///// <summary>
        ///// Used for synchronizing the selected state.
        ///// </summary>
        //private object isSelectedLock = new object();

        ///// <summary>
        ///// Occurs when the main page was selected.
        ///// </summary>
        //public event EventHandler MainPageSelected;

        ///// <summary>
        ///// Occurs when the search page was selected.
        ///// </summary>
        //public event EventHandler SearchPageSelected;

        ///// <summary>
        ///// Occurs when the documents page was selected.
        ///// </summary>
        //public event EventHandler DocumentsPageSelected;

        ///// <summary>
        ///// Occurs when the categories page was selected.
        ///// </summary>
        //public event EventHandler CategoriesPageSelected;

        ///// <summary>
        ///// Occurs when the tags page was selected.
        ///// </summary>
        //public event EventHandler TagsPageSelected;

        ///// <summary>
        ///// Occurs when the settings page was selected.
        ///// </summary>
        //public event EventHandler SettingsPageSelected;

        /// <summary>
        /// Initializes a new <see cref="SidebarView"/>.
        /// </summary>
        public SidebarView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Raises the specified <see cref="EventHandler"/> with <see cref="EventArgs.Empty"/>.
        /// </summary>
        /// <param name="handler">The <see cref="EventHandler"/> to execute.</param>
        private void RaiseEvent(EventHandler handler)
        {
            this.RaiseEvent(handler, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the specified <see cref="EventHandler"/> with <see cref="EventArgs.Empty"/>.
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/> to pass to the handler..</param>
        /// <param name="handler">The <see cref="EventHandler"/> to execute.</param>
        private void RaiseEvent(EventHandler handler, EventArgs e)
        {
            if (handler != null)
            {
                handler(this, e);
            }
        }

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on the main sidebar element.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void MainElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    this.SidebarElement_MouseDown(sender, e);
        //    this.RaiseEvent(this.MainPageSelected);
        //}

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on the main sidebar element.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void SearchElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    this.SidebarElement_MouseDown(sender, e);
        //    this.RaiseEvent(this.SearchPageSelected);
        //}

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on the categories sidebar element.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void CategoriesElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    this.SidebarElement_MouseDown(sender, e);
        //    this.RaiseEvent(this.CategoriesPageSelected);
        //}

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on the documents sidebar element.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void DocumentsElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    this.SidebarElement_MouseDown(sender, e);
        //    this.RaiseEvent(this.DocumentsPageSelected);
        //}

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on the tags sidebar element.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void TagsElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    this.SidebarElement_MouseDown(sender, e);
        //    this.RaiseEvent(this.TagsPageSelected);
        //}

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on the settings sidebar element.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void SettingsElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    this.SidebarElement_MouseDown(sender, e);
        //    this.RaiseEvent(this.SettingsPageSelected);
        //}

        ///// <summary>
        ///// Handles the MouseDown-event occuring when the mouse was pressed on one of the sidebar elements.
        ///// </summary>
        ///// <param name="sender">The <see cref="SidebarElement"/> that triggered the event.</param>
        ///// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        //private void SidebarElement_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Contract.Assume(sender != null && e != null);

        //    SidebarElement sendingElement = (SidebarElement)sender;
        //    lock (this.isSelectedLock)
        //    {
        //        foreach (SidebarElement element in this.Content.Children.Cast<SidebarElement>().Except(new[] { sendingElement }).Where(element => element != null))
        //        {
        //            element.IsSelected = false;
        //        }
        //        sendingElement.IsSelected = true;
        //    }
        //}
    }
}
