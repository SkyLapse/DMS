using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Docular.Client;
using Docular.Client.Events;
using Docular.Client.Rest;
using GalaSoft.MvvmLight.Messaging;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// Represents a basic model.
    /// </summary>
    [ContractClass(typeof(BaseViewModelContracts))]
    public abstract class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private static ViewModelEventSource _EventSource = new ViewModelEventSource();

        /// <summary>
        /// The <see cref="ViewModelEventSource"/> tracing events.
        /// </summary>
        protected static ViewModelEventSource EventSource
        {
            get
            {
                return _EventSource;
            }
            private set
            {
                _EventSource = value;
            }
        }

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
        public bool IsBusy // TODO: Replace IsBusy by "refcount"-System incrementing a value if something is done and decremeting it if it is finished.
        {
            get
            {
                return _IsBusy;
            }
            protected set
            {
                this.SetProperty(ref _IsBusy, value);
            }
        }

        /// <summary>
        /// The <see cref="RelayCommand"/> used to change the current content view model.
        /// </summary>
        public RelayCommand ChangeViewModelCommand
        {
            get
            {
                return new RelayCommand(
                    p => Messenger.Default.Send<ChangeViewModelMessage>(new ChangeViewModelMessage((BaseViewModel)p)),
                    p => (p != null) && (p is BaseViewModel)
                );
            }
        }

        /// <summary>
        /// The <see cref="RelayCommand"/> used to load the data into the model.
        /// </summary>
        public RelayCommand LoadDataCommand
        {
            get
            {
                return new RelayCommand(async p => await this.LoadData());
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private Path _Icon;

        /// <summary>
        /// The <see cref="BaseViewModel"/>'s icon.
        /// </summary>
        public Path Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                this.SetProperty(ref _Icon, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="BaseViewModel"/>.
        /// </summary>
        protected BaseViewModel() : this((String)null) { }

        /// <summary>
        /// Initializes a new <see cref="BaseViewModel"/>.
        /// </summary>
        /// <param name="name">The <see cref="BaseViewModel"/>s name.</param>
        protected BaseViewModel(String name)
            : base(name)
        {
            EventSource.Initialized(this.GetType(), name);
        }

        /// <summary>
        /// Initializes a new <see cref="BaseViewModel"/>.
        /// </summary>
        /// <param name="name">The <see cref="BaseViewModel"/>s name.</param>
        /// <param name="icon">The <see cref="BaseViewModel"/>'s icon.</param>
        protected BaseViewModel(String name, Path icon)
            : this(name)
        {
            this.Icon = icon;
        }

        /// <summary>
        /// Initializes a new <see cref="BaseViewModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        protected BaseViewModel(IDocularClient client)
            : this((String)null)
        {
            this.Client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="BaseViewModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="BaseViewModel"/>s name.</param>
        protected BaseViewModel(IDocularClient client, String name)
            : this(name)
        {
            this.Client = client;
        }

        /// <summary>
        /// Initializes a new <see cref="BaseViewModel"/>.
        /// </summary>
        /// <param name="client">An <see cref="IDocularClient"/> used to fetch the data.</param>
        /// <param name="name">The <see cref="BaseViewModel"/>s name.</param>
        /// <param name="icon">The <see cref="BaseViewModel"/>'s icon.</param>
        protected BaseViewModel(IDocularClient client, String name, Path icon)
            : this(client, name)
        {
            this.Icon = icon;
        }

        /// <summary>
        /// Loads the data into the model. See remarks.
        /// </summary>
        /// <remarks>
        /// IT IS ABSOLUTELY CRUCIAL THAT THIS METHOD DOES NOT THROW ANY EXCEPTIONS AS THEY CANNOT BE CAUGHT EXCEPT FOR CATCHING
        /// UNHANDLED EXCEPTIONS USING <see cref="AppDomain.UnhandledException"/> WHEN THIS IS FIRED FROM AN ASYNC VOID EVENT HANDLER!
        /// </remarks>
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
            private BaseViewModel busyModel;

            /// <summary>
            /// Initializes a new <see cref="IsBusySwitcher"/>.
            /// </summary>
            /// <param name="model">The <see cref="BaseViewModel"/> to swich the <see cref="P:BaseModel.IsBusy"/>-state of.</param>
            public IsBusySwitcher(BaseViewModel model)
                : this()
            {
                Contract.Requires<ArgumentNullException>(model != null);

                this.busyModel = model;
                this.busyModel.IsBusy = true;
            }

            /// <summary>
            /// Disposes the <see cref="IsBusySwitcher"/> debusying the <see cref="BaseViewModel"/>.
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

    /// <summary>
    /// Contains contract definitions for abstract members of <see cref="BaseViewModel"/>.
    /// </summary>
    [ContractClassFor(typeof(BaseViewModel))]
    abstract class BaseViewModelContracts : BaseViewModel
    {
        /// <summary>
        /// Contains contract definitions, not for actual use.
        /// </summary>
        public override Task LoadData()
        {
            Contract.Ensures(Contract.Result<Task>() != null);

            return null;
        }
    }
}
