using HardwareLedger.DBObject;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class DBAccessor
    {
        private static DBAccessor instance;

        public static DBAccessor Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBAccessor();

                return instance;
            }
        }

        public LiteDatabase DB { get; private set; }

        public List<Reserve> Reserves { get; set; }

        public List<ItemType> ItemTypes { get; set; }

        public List<ItemState> ItemStates { get; set; }

        private DBAccessor()
        {
            DB = new LiteDatabase(nameof(HardwareLedger) + @".db");

            Reserves = Get<Reserve, DBObject.Reserve>();
            ItemTypes = Get<ItemType, DBObject.ItemType>();
            ItemStates = Get<ItemState, DBObject.ItemState>();

            //Update<Reserve, DBObject.Reserve>(new Reserve { ReserveCode = 100 });

            //SetDummyData();

            //Update<ItemState, DBObject.ItemState>(new ItemState { StateCode = 4, ApplyKbn = ApplyKbns.Reserve, StateColor = Color.Black, StateName = "テストD" });
        }

        public void Update<T, D>(params T[] rows) where T : PgmRow where D : DBData, new()
        {
            var dbd = DB.GetCollection<D>(typeof(D).Name);
            var dd = new D();
            var kcn = dd.GetKeyColumnName();

            foreach (var row in rows)
            {
                if (row.Convertible<D>())
                {
                    var drow = row.Convert<D>();
                    var dkcn = drow[kcn];

                    var dbdr = dbd.Find(x => x[kcn] == dkcn).FirstOrDefault();


                    if (dbdr == null)
                        dbd.Insert(drow);
                    else
                        dbdr.Copy(drow);

                    dbd.Update(drow);
                }
            }
        }

        public List<T> Get<T, D>() where T : PgmRow, new() where D : DBData, new()
        {
            var list = new List<T>();
            var tt = new T();

            var dres = DB.GetCollection<D>(typeof(D).Name);

            foreach (var row in dres.Query().ToEnumerable())
            {
                if (tt.Convertible<D>())
                    list.Add((T)tt.Convert(row));
            }

            return list;
        }

        //public List<D> Get<D>() where D : DBData
        //{
        //    //var list = new List<T>();

        //    //var dres = DB.GetCollection<D>(typeof(D).Name);

        //    //foreach (var row in dres.Query().ToEnumerable())
        //    //{
        //    //    if (row is T trow)
        //    //    {
        //    //        list.Add(trow);
        //    //    }
        //    //}

        //    return DB.GetCollection<D>(typeof(D).Name).Query().ToList();
        //}

        private void SetDummyData()
        {
            if (ItemTypes.Count() == 0)
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
            }

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


            //Reserves.AddRange(new List<Reserve>
            //{
            //    new Reserve
            //    {
            //        ReserveCode = 1,
            //        Name = "AAA",
            //        ItemTypeCode = 1,
            //        StateCode = 1,
            //        InsertTime = DateTime.Now,
            //        UpdateTime = DateTime.Now,
            //    },
            //    new Reserve
            //    {
            //        ReserveCode = 2,
            //        Name = "BBB",
            //        ItemTypeCode = 1,
            //        StateCode = 1,
            //        InsertTime = DateTime.Now,
            //        UpdateTime = DateTime.Now,
            //    },
            //    new Reserve
            //    {
            //        ReserveCode = 3,
            //        Name = "CCC",
            //        ItemTypeCode = 1,
            //        StateCode = 1,
            //        InsertTime = DateTime.Now,
            //        UpdateTime = DateTime.Now,
            //    },
            //});
        }
    }
}
