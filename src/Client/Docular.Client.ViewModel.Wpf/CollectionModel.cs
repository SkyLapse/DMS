using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.ViewModel.Wpf
{
    /// <summary>
    /// Represents a <see cref="BaseModel"/> hosting a collection of items.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of items to store.</typeparam>
    public abstract class CollectionModel<T> : BaseModel
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
                if (value != _Items)
                {
                    _Items = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        protected CollectionModel() { }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="name">The <see cref="BaseModel"/>s name.</param>
        protected CollectionModel(String name) : base(name) { }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        protected CollectionModel(IDocularClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="BaseModel"/>s name.</param>
        protected CollectionModel(IDocularClient client, String name)
            : base(name)
        {
            this.Client = client;
        }
    }
}
