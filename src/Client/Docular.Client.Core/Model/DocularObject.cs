using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Rest;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents an object in the Docular database.
    /// </summary>
    [DataContract]
    public abstract class DocularObject : ObservableObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private IDocularClient _DocularClient;

        /// <summary>
        /// A <see cref="IDocularClient"/> used to interact with the docular DB.
        /// </summary>
        [IgnoreDataMember]
        public IDocularClient DocularClient
        {
            get
            {
                return _DocularClient;
            }
            set
            {
                this.SetProperty(ref _DocularClient, value);
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private ChangeInfo _CreateInfo;

        /// <summary>
        /// Gets information about the creation of the <see cref="DocularObject"/>.
        /// </summary>
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember(Name = "_id")]
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
        protected DocularObject() 
        {
            this.CreateInfo = new ChangeInfo(null, DateTime.Now);
        }

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
