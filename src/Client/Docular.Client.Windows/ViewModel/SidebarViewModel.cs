using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Docular.Client.Model;

namespace Docular.Client.ViewModel
{
    public class SidebarViewModel : CollectionViewModel<SidebarViewElement>
    {
        public override Task LoadData()
        {
            return Task.FromResult<object>(null);
        }

        protected override void OnLoadDataCommandException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
