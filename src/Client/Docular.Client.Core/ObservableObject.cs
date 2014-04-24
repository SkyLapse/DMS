using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoBuf;

namespace Docular.Client
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
                this.SetProperty(ref _Name, value);
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
        /// Sets the specified property and raises the <see cref="PropertyChanged"/>-event.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of property to set.</typeparam>
        /// <param name="location">The backing field of the property to set.</param>
        /// <param name="value">The new property value.</param>
        /// <param name="propertyName">The name of the property. Leave this empty, it will be filled out by the compiler.</param>
        protected void SetProperty<T>(ref T location, T value, [CallerMemberName] String propertyName = null)
        {
            if (!ReferenceEquals(value, location))
            {
                location = value;
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
