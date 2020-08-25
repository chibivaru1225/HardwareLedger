using HardwareLedger.JSONObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class JSONAccessor
    {
        private static JSONAccessor instance;

        public static JSONAccessor Instance
        {
            get
            {
                if (instance == null)
                    instance = new JSONAccessor();

                return instance;
            }
        }

        private Dictionary<Type, Type> kp;

        private Dictionary<Type, List<IJSONData>> data;

        private JSONAccessor()
        {
            kp = new Dictionary<Type, Type>();
            kp.Add(typeof(Reserve), typeof(JSONObject.Reserve));
            kp.Add(typeof(ItemType), typeof(JSONObject.ItemType));
        }

        public void Update<T>(IEnumerable<T> data) where T : IPgmDataRow
        {
            if (kp.ContainsKey(typeof(T)) == false)
                return;


        }

        public List<T> GetData<T>() where T : IPgmDataRow
        {
            var list = new List<T>();

            if (false == kp.ContainsKey(typeof(T)))
                return list;

            var value = kp[typeof(T)];

            if (false == data.ContainsKey(value))
                return list;

            var jsondata = data[value];

            foreach (var json in jsondata)
            {
            }

            return list;
        }
    }
}
