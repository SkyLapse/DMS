using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docular.Client.Core.Model
{
    public class CustomField : DocularObject
    {
        public String Key { get; private set; }

        public String Value { get; private set; }

        private CustomField() { }

        public CustomField(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
