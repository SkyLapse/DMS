using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace Docular.Client.Rest.Requests
{
    /// <summary>
    /// The REST request used to count all categories.
    /// </summary>
    [Route("/categories/count", "GET")]
    public class CategoryCountRequest : IReturn<int> { }
}
