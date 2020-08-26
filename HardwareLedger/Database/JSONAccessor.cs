using HardwareLedger.JSONObject;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

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

        public LiteDatabase DB { get; private set; }

        public List<Reserve> Reserves { get; set; }

        public List<ItemType> ItemTypes { get; set; }

        public List<ItemState> ItemStates { get; set; }

        private JSONAccessor()
        {
            DB = new LiteDatabase(nameof(HardwareLedger) + @".db");

            ////DB.DropCollection(nameof(JSONObject.Reserve));
            ////DB.DropCollection(nameof(JSONObject.ItemType));

            //var reserve = DB.GetCollection<JSONObject.Reserve>(nameof(JSONObject.Reserve));
            //var itemtype = DB.GetCollection<JSONObject.ItemType>(nameof(JSONObject.ItemType));
            ////var malfunction = Database.GetCollection<JSONObject.Malfunction>(nameof(JSONObject.Malfunction));
            ////var reservehistory = Database.GetCollection<JSONObject.ReserveHistory>(nameof(JSONObject.ReserveHistory));

            ////reserve.DeleteAll();
            ////itemtype.DeleteAll();

            ////reserve.EnsureIndex(x => x.ReserveCode);
            ////itemtype.EnsureIndex(x => x.ItemTypeCode);
            ////malfunction.EnsureIndex(x => x., true);
            ////reservehistory.EnsureIndex(x => x, true);

            //var r = new JSONObject.Reserve();
            //r.ItemTypeCode = 1;
            //r.Name = "テスト";
            //r.InsertTime = DateTime.Now;
            //r.UpdateTime = DateTime.Now;
            //r.State = "0";
            //r.ReserveCode = reserve.Count() == 0 ? 1 : reserve.Max(x => x.ReserveCode) + 1;

            //reserve.Insert(r);
            //DB.Commit();

            //var i = new JSONObject.ItemType();
            //i.ItemTypeCode = itemtype.Count() == 0 ? 1 : itemtype.Max(x => x.ItemTypeCode) + 1;
            //i.ItemTypeName = "テスト";

            //var ii = itemtype.Insert(i);
            //DB.Commit();

            //var r2 = (from a in reserve.Query()
            //          select a).ToArray();

            //var i2 = (from a in itemtype.Query()
            //          select a).ToArray();

            Reserves = new List<Reserve>();
            ItemTypes = new List<ItemType>();
            ItemStates = new List<ItemState>();

            SetDummyData();
        }

        //public List<TP> GetRows<TD, TP>() where TD : IJSONData where TP : IPgmDataRow
        //{


        //    return null;
        //}

        private void SetDummyData()
        {
            ItemTypes.AddRange(new List<ItemType>
            {
                new ItemType
                {
                    ItemTypeCode = 1,
                    ItemTypeName = "デスクトップPC"
                },
                new ItemType
                {
                    ItemTypeCode = 2,
                    ItemTypeName = "ノートPC"
                },
                new ItemType
                {
                    ItemTypeCode = 3,
                    ItemTypeName = "プリンタ"
                },
            });

            ItemStates.AddRange(new List<ItemState>
            {
                new ItemState
                {
                    StateCode = 1,
                    StateName = "テストA",
                    ApplyKbn = ApplyKbns.Reserve,
                    StateColor = Color.White,
                },
                new ItemState
                {
                    StateCode = 2,
                    StateName = "テストB",
                    ApplyKbn = ApplyKbns.Malfunction,
                    StateColor = Color.LightBlue,
                },
                new ItemState
                {
                    StateCode = 3,
                    StateName = "テストC",
                    ApplyKbn = ApplyKbns.Reserve | ApplyKbns.Malfunction,
                    StateColor = Color.LightGreen,
                },
                new ItemState
                {
                    StateCode = 4,
                    StateName = "テストD",
                    ApplyKbn = ApplyKbns.NONE,
                    StateColor = Color.Red,
                },
            });
        }
    }
}
