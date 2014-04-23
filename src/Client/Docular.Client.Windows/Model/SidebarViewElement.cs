using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Docular.Client.Windows.Model
{
    public class SidebarViewElement : ObservableObject
    {
        private String _Name;

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private Path _Icon;

        public Path Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                if (value != _Icon)
                {
                    _Icon = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
