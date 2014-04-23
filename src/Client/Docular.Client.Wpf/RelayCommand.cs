using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Docular.Client
{
    /// <summary>
    /// Represents an <see cref="ICommand"/> outsourcing the <see cref="M:ICommand.Execute"/> and <see cref="M:ICommand.CanExecute"/>
    /// methods to delegates.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The <see cref="Action{T}"/> to be executed as <see cref="M:ICommand.Execute"/>.
        /// </summary>
        public Action<object> ExecuteAction { get; private set; }

        /// <summary>
        /// The <see cref="Func{TIn, TOut}"/> to be executed as <see cref="M:ICommand.CanExecute"/>.
        /// </summary>
        public Func<object, bool> CanExecuteAction { get; private set; }

        /// <summary>
        /// The <see cref="ICommand.CanExecuteChanged"/>-event.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Initializes a new <see cref="RelayCommand"/> setting the <paramref name="executeAction"/>.
        /// </summary>
        /// <param name="executeAction">The <see cref="Action{T}"/> to be executed as <see cref="M:ICommand.Execute"/>.</param>
        public RelayCommand(Action<object> executeAction)
            : this(executeAction, null)
        {
            Contract.Requires<ArgumentNullException>(executeAction != null);
        }

        /// <summary>
        /// Initializes a new <see cref="RelayCommand"/> setting the <paramref name="executeAction"/>.
        /// </summary>
        /// <param name="executeAction">The <see cref="Action{T}"/> to be executed as <see cref="M:ICommand.Execute"/>.</param>
        /// <param name="canExecuteAction">
        /// The <see cref="Func{TIn, TOut}"/> to be executed as <see cref="M:ICommand.CanExecute"/>. Defaults to <c>true</c>
        /// if left unspecified.
        /// </param>
        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            Contract.Requires<ArgumentNullException>(executeAction != null);

            this.ExecuteAction = executeAction;
            this.CanExecuteAction = canExecuteAction;
        }

        /// <summary>
        /// Returns <c>true</c> if the method can be executed, otherwise <c>false</c>.
        /// </summary>
        /// <param name="parameter">An optional parameter.</param>
        /// <returns><c>true</c> if <see cref="M:Execute"/> can be executed, otherwise <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            return (this.CanExecuteAction == null) || this.CanExecuteAction(parameter);
        }

        /// <summary>
        /// Executes the work to do.
        /// </summary>
        /// <param name="parameter">An optional parameter.</param>
        public void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
            {
                this.ExecuteAction(parameter);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:CanExecuteChanged"/>-event.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Contains Contract.Invariant definitions.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.ExecuteAction != null);
        }
    }
}
