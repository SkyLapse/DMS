using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Rest.Requests
{
    /// <summary>
    /// Defines the default parameters for any REST collection request.
    /// </summary>
    [DataContract]
    public abstract class CollectionRequest
    {
        /// <summary>
        /// The index to start searching at.
        /// </summary>
        [DataMember]
        public int Start { get; set; }

        /// <summary>
        /// Backing field.
        /// </summary>
        private int _Count = 0;

        /// <summary>
        /// The amount of results to return.
        /// </summary>
        [DataMember]
        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                _Count = value;
            }
        }

        [DataMember(Name = "nowrap")]
        public bool NoWrap
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _OrderBy = "createInfo.date";

        /// <summary>
        /// Specifies the field the collection shall be sorted by before applying the query, defaults to the item creation time.
        /// </summary>
        [DataMember]
        public String OrderBy
        {
            get
            {
                return _OrderBy;
            }
            set
            {
                _OrderBy = value;
            }
        }

        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Order = "a";

        /// <summary>
        /// Orders the collection to be searched in ascending 'a' or descending 'd' order before applying the query.
        /// </summary>
        [DataMember]
        public String Order
        {
            get
            {
                return _Order;
            }
            set
            {
                Contract.Requires<ArgumentException>(value == null || value.ToLowerInvariant() == "a" || value.ToLowerInvariant() == "d");

                _Order = value;
            }
        }
    }
}
