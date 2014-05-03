using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Model;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// Retreives a single <see cref="Document"/> by its ID.
    /// </summary>
    [Route("/documents/{Id}", "GET")]
    public class DocumentRequest : IdRequest<Document> { }
}
