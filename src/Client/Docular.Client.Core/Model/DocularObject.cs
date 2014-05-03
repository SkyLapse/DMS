using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents an object in the Docular database.
    /// </summary>
    public abstract class DocularObject : ObservableObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _CreateInfo;

        /// <summary>
        /// Gets information about the creation of the <see cref="DocularObject"/>.
        /// </summary>
        public ChangeInfo CreateInfo
        {
            get
            {
                return _CreateInfo;
            }
            set
            {
                this.SetProperty(ref _CreateInfo, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private CustomField[] _CustomFields;

        /// <summary>
        /// Contains all custom fields.
        /// </summary>
        public CustomField[] CustomFields
        {
            get
            {
                return _CustomFields;
            }
            set
            {
                this.SetProperty(ref _CustomFields, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Description;

        /// <summary>
        /// The <see cref="Category"/>'s description.
        /// </summary>
        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                this.SetProperty(ref _Description, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _EditInfo;

        /// <summary>
        /// Gets information about the last (server side) edit of the <see cref="Document"/>.
        /// </summary>
        public ChangeInfo EditInfo
        {
            get
            {
                return _EditInfo;
            }
            set
            {
                this.SetProperty(ref _EditInfo, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Id;

        /// <summary>
        /// The unique Id.
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "_id")]
        public String Id
        {
            get
            {
                return _Id;
            }
            set
            {
                this.SetProperty(ref _Id, value);
            }
        }

        /// <summary>
        /// Initializes a new <see cref="DocularObject"/>.
        /// </summary>
        protected DocularObject() { }

        /// <summary>
        /// Implictly gets the <see cref="DocularObject"/>'s ID.
        /// </summary>
        /// <param name="docularObject">The <see cref="DocularObject"/> to get the ID of.</param>
        /// <returns>The <see cref="DocularObject"/>'s ID.</returns>
        public static implicit operator String(DocularObject docularObject)
        {
            return (docularObject != null) ? docularObject.Id : null;
        }
    }
}
