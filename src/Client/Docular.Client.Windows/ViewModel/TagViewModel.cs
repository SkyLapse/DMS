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
using Docular.Client.Rest;
using GalaSoft.MvvmLight.Ioc;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The <see cref="Tag"/> view model.
    /// </summary>
    public class TagViewModel : CollectionViewModel<Tag>
    {
        /// <summary>
        /// Initializes a new <see cref="DocumentViewModel"/>.
        /// </summary>
        public TagViewModel() : base(Resources.Strings.General.DocumentsCaption, (Path)System.Windows.Application.Current.Resources["BoxIcon"]) { }

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
                this.Items = new ObservableCollection<Tag>(
                    await this.Client.GetTagsAsync(
                        new TagCollectionParameters() { Count = 100 }
                    )
                );
            }
        }

        /// <summary>
        /// Loads more data (e.g. if the user is scrolling down) into the model.
        /// </summary>
        /// <param name="count">The amount of additional items to load.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public override async Task LoadMore(int count)
        {
            using (IsBusySwitcher section = this.StartBusySection())
            {
                foreach (Tag tag in await this.Client.GetTagsAsync(new TagCollectionParameters() { Start = this.Items.Count, Count = 100 }))
                {
                    this.Items.Add(tag);
                }
            }
        }
    }
}
