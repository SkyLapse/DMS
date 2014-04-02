using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model
{
    /// <summary>
    /// Represents a stored document.
    /// </summary>
    public class Document : DocularObject
    {
        public String ThumbnailPath { get; private set; }

        public String PayloadPath { get; private set; }
    }
}
