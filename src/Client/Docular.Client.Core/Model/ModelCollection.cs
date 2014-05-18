using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Model
{
    public class ModelCollection<T> : ObservableObject, IEnumerable<T>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private ObservableCollection<T> _Items = new ObservableCollection<T>();

        public ObservableCollection<T> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                this.SetProperty(ref _Items, value);
            }
        }

        public ModelCollection()
        {
            this.Items.CollectionChanged += (s, e) =>
            {
                NotifyCollectionChangedEventHandler handler = this.CollectionChanged;
                if (handler != null)
                {
                    handler(s, e);
                }
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            ObservableCollection<T> items = this.Items;
            return (items != null) ? items.GetEnumerator() : null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
