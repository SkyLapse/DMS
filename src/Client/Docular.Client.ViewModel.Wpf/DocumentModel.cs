using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core;
using Docular.Client.Core.Model;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.ViewModel.Wpf
{
    /// <summary>
    /// The <see cref="Document"/> view model.
    /// </summary>
    public class DocumentModel : CollectionModel<Document>
    {
        /// <summary>
        /// Initializes a new <see cref="DocumentModel"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> used to fetch data from the database.</param>
        public DocumentModel(IDocularClient client)
            : base(client, "Documents")
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
                this.Items = new ObservableCollection<Document>(await this.Client.GetDocumentsAsync());
            }
        }
    }
}
