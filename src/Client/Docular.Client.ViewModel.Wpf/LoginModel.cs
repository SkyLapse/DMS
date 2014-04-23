using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core;
using Docular.Client.Core.Model.Rest;
using Newtonsoft.Json;
using RestSharp.Portable;

namespace Docular.Client.ViewModel.Wpf
{
    /// <summary>
    /// The model for the login window.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class LoginModel : BaseModel
    {
        /// <summary>
        /// The <see cref="IKeyStore"/> to fill.
        /// </summary>
        private IKeyStore keyStore;

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
        [JsonProperty("username")]
        public String Username
        {
            get
            {
                return _Username;
            }
            set
            {
                if (value != _Username)
                {
                    _Username = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Password;

        /// <summary>
        /// The password.
        /// </summary>
        [JsonProperty("password")]
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (value != _Password)
                {
                    _Password = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The current machine's name.
        /// </summary>
        [JsonProperty("machineName")]
        public String MachineName
        {
            get
            {
                return Environment.MachineName;
            }
        }

        /// <summary>
        /// The <see cref="ICommand"/> used to log-in.
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(async p =>
                {
                    try
                    {
                        this.Password = ((System.Windows.Controls.PasswordBox)p).Password;
                        await this.Login();
                        this.Password = null;
                    }
                    catch (Exception)
                    {
                        // TODO: Proper exception handling here, please!
                        throw;
                    }
                }, 
                p => !String.IsNullOrEmpty(this.Username) && !String.IsNullOrEmpty(this.Password) && (this.docularUri != null) && (this.keyStore != null));
            }
        }

        /// <summary>
        /// The <see cref="ICommand"/> used to open the forgot password site.
        /// </summary>
        public RelayCommand ForgotPasswordCommand
        {
            get
            {
                return new RelayCommand(p => this.ForgotPassword(), p => this.docularUri != null);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="LoginModel"/>.
        /// </summary>
        /// <param name="docularUri">The <see cref="Uri"/> of the remote docular DB. Not the /api url!</param>
        /// <param name="keyStore">The <see cref="IKeyStore"/> to store the obtained key in.</param>
        public LoginModel(IKeyStore keyStore, Uri docularUri)
            : base("Log in")
        {
            Contract.Requires<ArgumentNullException>(keyStore != null && docularUri != null);
            Contract.Requires<ArgumentException>(docularUri.AbsoluteUri.EndsWith("api/"));

            this.keyStore = keyStore;
            this.docularUri = docularUri;
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
                RestClient restClient = new RestClient(this.docularUri);
                RestRequest validateRequest = new RestRequest(DocularClient.ValidateKeys);
                validateRequest.AddParameter("key", this.keyStore.Key, ParameterType.RequestBody);

                if ((await restClient.Execute<bool>(validateRequest)).Data)
                {
                    return true;
                }

                RestRequest loginRequest = new RestRequest(DocularClient.Keys);
                loginRequest.AddParameter("nowrap", true, ParameterType.GetOrPost);
                loginRequest.AddBody(this);

                IRestResponse<String> response = await restClient.Execute<String>(loginRequest);
                if (!response.StatusCode.IsError())
                {
                    this.keyStore.Key = response.Data;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Opens the forgot password url.
        /// </summary>
        public void ForgotPassword()
        {
            System.Diagnostics.Process.Start(this.docularUri.Combine("resetpassword/").ToString());
        }
    }
}
