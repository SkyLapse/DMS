using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client;
using Docular.Client.Model;
using Docular.Client.Model.Rest;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The <see cref="Tag"/> view model.
    /// </summary>
    public class TagViewModel : CollectionViewModel<Tag>
    {
        /// <summary>
        /// Initializes a new <see cref="TagViewModel"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> used to fetch data from the database.</param>
        public TagViewModel(IDocularClient client)
            : base(client, Resources.Strings.General.TagsCaption, (Path)System.Windows.Application.Current.Resources["TicketIcon"])
        {
            Contract.Requires<ArgumentNullException>(client != null);
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadData()
        {
            using (IsBusySwitcher section = this.StartBusySection())
            {
                this.Items = new ObservableCollection<Tag>(await this.Client.GetTagsAsync());
            }
        }
    }
}
