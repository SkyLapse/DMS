using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client.Events;
using Docular.Client.Rest;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// Represents a <see cref="CollectionViewModel{T}"/> hosting a collection of items.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of items to store.</typeparam>
    public abstract class CollectionViewModel<T> : BaseViewModel
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private static CollectionViewModelEventSource _EventSource = new CollectionViewModelEventSource();

        /// <summary>
        /// The <see cref="CollectionEventSource"/> used to trace <see cref="CollectionViewModel{T}"/> events.
        /// </summary>
        protected static new CollectionViewModelEventSource EventSource
        {
            get
            {
                return _EventSource;
            }
            set
            {
                _EventSource = value;
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private ObservableCollection<T> _Items = new ObservableCollection<T>();

        /// <summary>
        /// Contains all loaded items.
        /// </summary>
        public ObservableCollection<T> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);

                this.SetProperty(ref _Items, value);
            }
        }

        /// <summary>
        /// The <see cref="ICommand"/> used to load additional data into the ViewModel.
        /// </summary>
        public RelayCommand LoadMoreCommand
        {
            get
            {
                return new RelayCommand(
                    async p => await this.LoadMore((int)p),
                    p => (p != null) && (p is int)
                );
            }
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        protected CollectionViewModel() { }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        protected CollectionViewModel(String name) : base(name) { }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        /// <param name="icon">The <see cref="CollectionViewModel{T}"/>'s icon.</param>
        protected CollectionViewModel(String name, Path icon) : base(name, icon) { }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        protected CollectionViewModel(IDocularClient client) : base(client) { }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        protected CollectionViewModel(IDocularClient client, String name) : base(client, name) { }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        /// <param name="icon">The <see cref="CollectionViewModel{T}"/>'s icon.</param>
        protected CollectionViewModel(IDocularClient client, String name, Path icon) : base(client, name, icon) { }

        /// <summary>
        /// Loads more data (e.g. if the user is scrolling down) into the model.
        /// </summary>
        /// <param name="count">The amount of additional items to load.</param>
        /// <remarks>
        /// IT IS ABSOLUTELY CRUCIAL THAT THIS METHOD DOES NOT THROW ANY EXCEPTIONS AS THEY CANNOT BE CAUGHT EXCEPT FOR CATCHING
        /// UNHANDLED EXCEPTIONS USING <see cref="AppDomain.UnhandledException"/> WHEN THIS IS FIRED FROM AN ASYNC VOID EVENT HANDLER!
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public abstract Task LoadMore(int count);

        /// <summary>
        /// Contains Contract.Invariant definitions.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Items != null);
        }
    }
}
