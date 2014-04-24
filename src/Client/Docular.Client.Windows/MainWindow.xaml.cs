using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Docular.Client;
using Docular.Client.Model;
using Docular.Client.Model.Rest;
using Docular.Client.ViewModel;

namespace Docular.Client
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property of the <see cref="MainWindow"/> changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The main view model.
        /// </summary>
        private MainViewModel _RootModel;

        /// <summary>
        /// The main view model.
        /// </summary>
        public MainViewModel RootModel
        {
            get
            {
                return _RootModel;
            }
            set
            {
                if (value != _RootModel)
                {
                    _RootModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.RootModel = new MainViewModel();
        }

        /// <summary>
        /// Fires the <see cref="PropertyChanged"/>-event for the specified property name.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown"/>-event.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e"><see cref="MouseButtonEventArgs"/> describing the event.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
