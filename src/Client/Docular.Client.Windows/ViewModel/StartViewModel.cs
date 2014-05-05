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
        private Random random = new Random();

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
            }
        }

        /// <summary>
        /// Selects a random greeting word from the list of available words.
        /// </summary>
        public String RandomGreetingWord
        {
            get
            {
                String[] words = General.WelcomeExpressions.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                return words.ElementAt(random.Next(1, words.Length));
            }
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadData()
        {
            //this.CurrentUser = await this.Client.GetCurrentUserAsync();
        }
    }
}
