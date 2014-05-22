using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client;
using Docular.Client.Rest;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The model for the login window.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// The <see cref="Uri"/> to the remote docular DB.
        /// </summary>
        private Uri docularUri;

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Username;

        /// <summary>
        /// The username.
        /// </summary>
        public String Username
        {
            get
            {
                return _Username;
            }
            set
            {
                this.SetProperty(ref _Username, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Password;

        /// <summary>
        /// The password.
        /// </summary>
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                this.SetProperty(ref _Password, value);
            }
        }

        /// <summary>
        /// The current machine's name.
        /// </summary>
        public String MachineName
        {
            get
            {
                return Environment.MachineName;
            }
        }

        /// <summary>
        /// The <see cref="RelayCommand"/> used to log-in.
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(async p =>
                {
                    try
                    {
                        // This is a little bit dirty (since we're referencing the View from the ViewModel) but there's no other way.
                        this.Password = ((System.Windows.Controls.PasswordBox)p).Password;
                        await this.Login();
                        this.Password = null; // Assign null to avoid unnecessary references to password in memory
                    }
                    catch (Exception)
                    {
                        // TODO: Proper exception handling here, please!
                        throw;
                    }
                },
                p => (!String.IsNullOrEmpty(this.Username) && !String.IsNullOrEmpty(this.Password) && (this.docularUri != null)));
            }
        }

        /// <summary>
        /// The <see cref="RelayCommand"/> used to open the forgot password site.
        /// </summary>
        public RelayCommand ForgotPasswordCommand
        {
            get
            {
                return new RelayCommand(
                    p => this.ForgotPassword(), 
                    p => this.docularUri != null
                );
            }
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override Task LoadData()
        {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous login operation.</returns>
        public async Task<bool> Login()
        {
            using (IsBusySwitcher switcher = this.StartBusySection())
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Opens the forgot password url.
        /// </summary>
        public void ForgotPassword()
        {

        }

        /// <summary>
        /// Contains Contract.Invariant definitions.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.docularUri != null);
        }
    }
}

