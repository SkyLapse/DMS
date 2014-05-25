using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a binary file.
    /// </summary>
    public abstract class BinaryObject : DocularObject
    {
        /// <summary>
        /// Backing field.
        /// </summary>
        private String _Path;

        /// <summary>
        /// The path to the file on the server.
        /// </summary>
        [DataMember]
        public String Path
        {
            get
            {
                return _Path;
            }
            set
            {
                this.SetProperty(ref _Path, value);
            }
        }
    }
}
