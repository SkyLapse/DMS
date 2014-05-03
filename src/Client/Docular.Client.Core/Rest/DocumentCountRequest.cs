using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace Docular.Client.Rest
{
    /// <summary>
    /// The REST request used to count all tags.
    /// </summary>
    [Route("/documents/count", "GET")]
    public class DocumentCountRequest : IReturn<int> { }
}
