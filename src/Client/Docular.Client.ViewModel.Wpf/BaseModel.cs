using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        /// The <see cref="ICommand"/> used to load the data into the model.
        /// </summary>
        public RelayCommand LoadDataCommand
        {
            get
            {
                return new RelayCommand(async p =>
                {
                    try
                    {
                        await this.LoadData();
                    }
                    catch
                    {
                        throw; // TODO: Handle exception properly.
                    }
                });
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

        /// <summary>
        /// Starts a section of code that needs to have the <see cref="P:IsBusy"/>-flag set to true.
        /// </summary>
        /// <returns>A disposable <see cref="IsBusySwitcher"/> for use with the using-keyword.</returns>
        /// <example>
        /// using (var releaser = this.StartBusyAction())
        /// {
        ///     // Busy code
        /// }
        /// </example>
        protected IsBusySwitcher StartBusySection()
        {
            return new IsBusySwitcher(this);
        }

        /// <summary>
        /// Triggers the <see cref="P:IsBusy"/>-property using <see cref="IDisposable"/> and the convenient using-directive.
        /// </summary>
        /// <remarks>
        /// Always, always, always make sure to dispose this struct, otherwise the <see cref="P:IsBusy"/> property will not be reset properly.
        /// </remarks>
        protected struct IsBusySwitcher : IDisposable
        {
            /// <summary>
            /// The model which is busy.
            /// </summary>
            private BaseModel busyModel;

            /// <summary>
            /// Initializes a new <see cref="IsBusySwitcher"/>.
            /// </summary>
            /// <param name="model">The <see cref="BaseModel"/> to swich the <see cref="P:BaseModel.IsBusy"/>-state of.</param>
            public IsBusySwitcher(BaseModel model)
                : this()
            {
                Contract.Requires<ArgumentNullException>(model != null);

                this.busyModel = model;
                this.busyModel.IsBusy = true;
            }

            /// <summary>
            /// Disposes the <see cref="IsBusySwitcher"/> debusying the <see cref="BaseModel"/>.
            /// </summary>
            public void Dispose()
            {
                if (this.busyModel != null)
                {
                    this.busyModel.IsBusy = false;
                }
            }
        }
    }
}
