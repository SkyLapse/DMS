using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client.Model.Rest;

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
        private ObservableCollection<T> _Items;

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
                this.SetProperty(ref _Items, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        protected CollectionViewModel() 
        {
            this.Items = new ObservableCollection<T>();
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        protected CollectionViewModel(String name) : base(name)
        {
            this.Items = new ObservableCollection<T>();
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        /// <param name="icon">The <see cref="CollectionViewModel{T}"/>'s icon.</param>
        protected CollectionViewModel(String name, Path icon)
            : base(name, icon)
        {
            this.Items = new ObservableCollection<T>();
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        protected CollectionViewModel(IDocularClient client)
            : base(client)
        {
            this.Items = new ObservableCollection<T>();
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        protected CollectionViewModel(IDocularClient client, String name)
            : base(client, name)
        {
            this.Items = new ObservableCollection<T>();
        }

        /// <summary>
        /// Initializes a new <see cref="CollectionViewModel{T}"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="CollectionViewModel{T}"/>s name.</param>
        /// <param name="icon">The <see cref="CollectionViewModel{T}"/>'s icon.</param>
        protected CollectionViewModel(IDocularClient client, String name, Path icon)
            : base(client, name, icon)
        {
            this.Items = new ObservableCollection<T>();
        }
    }
}
