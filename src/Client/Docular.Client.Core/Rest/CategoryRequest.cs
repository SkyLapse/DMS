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
    /// The REST request used to retreive a single <see cref="Category"/>.
    /// </summary>
    [Route("/categories/{Id}", "GET")]
    public class CategoryRequest : IdRequest<Category> { }
}
