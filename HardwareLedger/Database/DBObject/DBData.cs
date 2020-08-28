using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    public abstract class DBData
    {
        public abstract IEnumerable<string> Properties();

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

        public static T CopyNew<T>(T original) where T : DBData, new()
        {
            var replica = new T();

            foreach (var property in original.Properties())
            {
                replica[property] = original[property];
            }

            return replica;
        }

        public void Copy<T>(T original) where T : DBData
        {
            foreach (var property in original.Properties())
            {
                this[property] = original[property];
            }
        }

        public virtual string GetKeyColumnName() => String.Empty;

        public abstract DBData ConvertDBData<T>(T pgmrow) where T : PgmRow;
    }
}
