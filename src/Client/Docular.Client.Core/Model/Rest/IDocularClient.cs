﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docular.Client.Core.Model;

namespace Docular.Client.Core.Model.Rest
{
    /// <summary>
    /// Defines the way to work with a remote or local docular database.
    /// </summary>
    public interface IDocularClient : IDocumentManager, ICategoryManager, ITagManager, IUserManager
    {
    }
}