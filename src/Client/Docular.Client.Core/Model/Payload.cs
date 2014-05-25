using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Model
{
    /// <summary>
    /// Represents a document's payload.
    /// </summary>
    public class Payload : BinaryObject 
    {
        public override Task SaveAsync()
        {
            throw new NotImplementedException();
            return this.DocularClient.UpdateDocumentContentAsync(this.Id, null); // Replace null with actual stream!
        }
    }
}
