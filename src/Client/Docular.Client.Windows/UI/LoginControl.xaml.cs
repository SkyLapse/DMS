using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    /// Interaktionslogik für LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        /// <summary>
        /// The Uri of the forgot password link.
        /// </summary>
        private String forgotPasswordUri = null;

        /// <summary>
        /// Initializes a new <see cref="LoginControl"/>.
        /// </summary>
        public LoginControl()
        {
            DocularClientConfigurationSection clientConfig = 
                (DocularClientConfigurationSection)ConfigurationManager.GetSection("ClientConfiguration") ?? new DocularClientConfigurationSection();
            this.forgotPasswordUri = clientConfig.DocularResetPasswordUri;

            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the event when the user clicked on the log in button.
        /// </summary>
        /// <param name="sender">The button that was clicked.</param>
        /// <param name="e"><see cref="RoutedEventArgs"/>.</param>
        private void btnDoLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the event when the user clicked on the forgot password field.
        /// </summary>
        /// <param name="sender">The label that was clicked on.</param>
        /// <param name="e"><see cref="MouseButtonEventArgs"/>.</param>
        private void tblForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(forgotPasswordUri);
        }
    }
}
