using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client;
using Docular.Client.Model;
using Docular.Client.Resources.Strings;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The starting page view model.
    /// </summary>
    public class StartViewModel : BaseViewModel
    {
        /// <summary>
        /// An instance of <see cref="Random"/>.
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Backing field.
        /// </summary>
        private User _CurrentUser;

        /// <summary>
        /// The current user using the client.
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return _CurrentUser;
            }
            set
            {
                this.SetProperty(ref _CurrentUser, value);
                this.OnPropertyChanged("GreetingSentence");
            }
        }

        /// <summary>
        /// Gets the greeting sentence displayed on the start view.
        /// </summary>
        public String GreetingSentence
        {
            get
            {
                User currentUser = this.CurrentUser;
                return String.Format(
                    StartView.WelcomeFormatText,
                    this.GetRandomGreetingWord(),
                    (currentUser != null) ? currentUser.Name : null
                );
            }
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override Task LoadData()
        {
            //this.CurrentUser = await this.Client.GetCurrentUserAsync();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Gets a greeting word from the list of available ones.
        /// </summary>
        /// <returns>The greeting word.</returns>
        private String GetRandomGreetingWord()
        {
            String[] words = StartView.WelcomeExpressions.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return words.ElementAt(random.Next(0, words.Length));
        }
    }
}
