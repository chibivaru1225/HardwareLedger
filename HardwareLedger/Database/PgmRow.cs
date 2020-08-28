using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareLedger
{
    public abstract class PgmRow
    {
        public IEnumerable<string> Properties()
        {
            return (from a in GetType().GetProperties()
                    select a.Name);
        }

        public object this[string propertyName]
        {
            get
            {
                if (!Properties().Contains(propertyName))
                    return null;

                return GetType().GetProperty(propertyName).GetValue(this);
            }
            set
            {
                if (!Properties().Contains(propertyName))
                    return;

                GetType().GetProperty(propertyName).SetValue(this, value);
            }
        }

        public abstract bool Convertible<D>() where D : DBData, new();

        public abstract D Convert<D>() where D : DBData, new();

        public abstract PgmRow Convert<D>(D data) where D : DBData, new();
    }
}
