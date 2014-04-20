using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.ViewModel.Wpf
{
    /// <summary>
    /// Represents a basic model.
    /// </summary>
    public abstract class BaseModel : ObservableObject
    {
        /// <summary>
        /// The <see cref="IDocularClient"/> used to fetch the data.
        /// </summary>
        public IDocularClient Client { get; protected set; }

        /// <summary>
        /// Backing field.
        /// </summary>
        private bool _IsBusy;

        /// <summary>
        /// Indicates whether the model is currently busy / performing background work.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            protected set
            {
                if (value != _IsBusy)
                {
                    _IsBusy = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        protected BaseModel() { }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="name">The <see cref="BaseModel"/>s name.</param>
        protected BaseModel(String name) : base(name) { }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        protected BaseModel(IDocularClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="BaseModel"/>s name.</param>
        protected BaseModel(IDocularClient client, String name)
            : base(name)
        {
            this.Client = client;
        }

        /// <summary>
        /// Loads the data into the model.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous loading operation.</returns>
        public abstract Task LoadData();
    }
}
