using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoBuf;

namespace Docular.Client.Core
{
    /// <summary>
    /// Represents an object that notifies its subscribers of changes in its properties.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property of the <see cref="ObservableObject"/> changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Name;

        /// <summary>
        /// The <see cref="ObservableObject"/>s name.
        /// </summary>
        [JsonProperty("name"), ProtoMember(6)]
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ObservableObject"/>.
        /// </summary>
        protected ObservableObject() { }

        /// <summary>
        /// Initializes a new <see cref="ObservableObject"/>.
        /// </summary>
        /// <param name="name">The <see cref="ObservableObject"/>'s name.</param>
        protected ObservableObject(String name)
        {
            this.Name = name;
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
    }
}
