using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client;
using Docular.Client.Model;
using Docular.Client.Model.Rest;
using GalaSoft.MvvmLight.Ioc;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// The <see cref="Document"/> view model.
    /// </summary>
    public class DocumentViewModel : CollectionViewModel<Document>
    {
        /// <summary>
        /// The <see cref="RelayCommand"/> used to show a <see cref="Document"/> in the detail view.
        /// </summary>
        public RelayCommand ShowDetailDisplayDocumentCommand
        {
            get
            {
                return new RelayCommand(
                    p => this.DetailDisplayDocument = (Document)p,
                    p => (p != null)
                );
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Document _DetailDisplayDocument;

        /// <summary>
        /// The <see cref="Document"/> to display in the detail view on the side.
        /// </summary>
        public Document DetailDisplayDocument
        {
            get
            {
                return _DetailDisplayDocument;
            }
            set
            {
                this.SetProperty(ref _DetailDisplayDocument, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="DocumentViewModel"/>.
        /// </summary>
        [PreferredConstructor]
        public DocumentViewModel() : base(Resources.Strings.General.DocumentsCaption, (Path)System.Windows.Application.Current.Resources["BoxIcon"]) { }

        /// <summary>
        /// Initializes a new <see cref="DocumentViewModel"/>.
        /// </summary>
        /// <param name="client">The <see cref="IDocularClient"/> used to fetch data from the database.</param>
        public DocumentViewModel(IDocularClient client)
            : base(client, Resources.Strings.General.DocumentsCaption, (Path)System.Windows.Application.Current.Resources["BoxIcon"])
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
