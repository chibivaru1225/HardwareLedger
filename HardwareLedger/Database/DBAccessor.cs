using HardwareLedger.DBObject;
using LiteDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class DBAccessor
    {
        public String Directory { get; private set; }

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

        public List<ShopType> ShopTypes { get; set; }

        public List<ItemType> ItemTypes { get; set; }

        public List<ItemState> ItemStates { get; set; }

        public List<Malfunction> Malfunctions { get; set; }

        public List<Relation> Relations { get; set; }

        public List<CollectSchedule> CollectSchedules { get; set; }

        public List<ReserveShipping> ReserveShippings { get; set; }

        private DBAccessor()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //SafeCreateDirectory(documents + @"\HardwareLedger\Database\");
            Directory = documents + @"\HardwareLedger\Database\{0}.json";

            SafeCreateDirectory(documents + @"\HardwareLedger\Database\");
            DB = new LiteDatabase(nameof(HardwareLedger) + @".db");

            //Reserves = Get<Reserve, DBObject.Reserve>();
            //ItemTypes = Get<ItemType, DBObject.ItemType>();
            //ItemStates = Get<ItemState, DBObject.ItemState>();
            //Malfunctions = Get<Malfunction, DBObject.Malfunction>();
            //Relations = Get<Relation, DBObject.Relation>();

            Reserves = ReadJson<Reserve, DBObject.Reserve>();
            ShopTypes = ReadJson<ShopType, DBObject.ShopType>();
            ItemTypes = ReadJson<ItemType, DBObject.ItemType>();
            ItemStates = ReadJson<ItemState, DBObject.ItemState>();
            Malfunctions = ReadJson<Malfunction, DBObject.Malfunction>();
            Relations = ReadJson<Relation, DBObject.Relation>();
            CollectSchedules = ReadJson<CollectSchedule, DBObject.CollectSchedule>();
            ReserveShippings = ReadJson<ReserveShipping, DBObject.ReserveShipping>();

            //SetDummyData();
        }

        public List<T> UpsertJson<T, D>(params T[] rows) where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            var filepath = String.Format(Directory, typeof(D).Name);

            var dd = new D();
            var basedata = ReadJson<D>();
            var kcn = dd.GetKeyColumnName();

            foreach (var row in rows)
            {
                if (row is D)
                {
                    var drow = row.UpCastToDBData() as D;
                    var dkcn = drow[kcn];
                    var dbdr = (from a in basedata
                                where a[kcn].Equals(dkcn)
                                select a).FirstOrDefault();

                    if (dbdr == null)
                        basedata.Add(drow);
                    else
                        dbdr.Copy(drow);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                sw.Write(JsonConvert.SerializeObject(basedata));
            }

            return ConvertList<T, D>(basedata);
        }

        public List<T> RemoveJson<T, D>(params T[] rows) where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            var filepath = String.Format(Directory, typeof(D).Name);

            var dd = new D();
            var basedata = ReadJson<D>();
            var kcn = dd.GetKeyColumnName();

            foreach (var row in rows)
            {
                if (row is D)
                {
                    var drow = row.UpCastToDBData() as D;
                    var dkcn = drow[kcn];
                    var dbdr = (from a in basedata
                                where a[kcn].Equals(dkcn)
                                select a).FirstOrDefault();

                    if (dbdr != null)
                        basedata.Remove(dbdr);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                sw.Write(JsonConvert.SerializeObject(basedata));
            }

            return ConvertList<T, D>(basedata);
        }

        private void Upsert<T, D>(params T[] rows) where T : IPgmRow where D : DBData, new()
        {
            var dd = new D();
            var dbdata = DB.GetCollection<D>(typeof(D).Name);
            var kcn = dd.GetKeyColumnName();

            if (DB.BeginTrans())
            {
                foreach (var row in rows)
                {
                    if (row is D)
                    {
                        var drow = row.UpCastToDBData() as D;
                        var dkcn = drow[kcn];
                        var dbdr = dbdata.Find(x => x[kcn] == dkcn).FirstOrDefault();

                        if (dbdr == null)
                            dbdata.Insert(drow);
                        else
                            dbdr.Copy(drow);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }

                if (DB.Commit() == false)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        //public void Update<T, D>(params T[] rows) where T : PgmRow where D : DBData, new()
        //{
        //    var dbd = DB.GetCollection<D>(typeof(D).Name);
        //    var dd = new D();
        //    var kcn = dd.GetKeyColumnName();

        //    foreach (var row in rows)
        //    {
        //        if (row.Convertible<D>())
        //        {
        //            var drow = row.Convert<D>();
        //            var dkcn = drow[kcn];

        //            var dbdr = dbd.Find(x => x[kcn] == dkcn).FirstOrDefault();

        //            if (dbdr == null)
        //                dbd.Insert(drow);
        //            else
        //                dbdr.Copy(drow);
        //        }
        //    }
        //}

        //public List<T> Get<T, D>() where T : PgmRow, new() where D : DBData, new()
        //{
        //    var list = new List<T>();
        //    var tt = new T();

        //    var dres = DB.GetCollection<D>(typeof(D).Name);

        //    foreach (var row in dres.Query().ToEnumerable())
        //    {
        //        if (tt.Convertible<D>())
        //            list.Add((T)tt.Convert(row));
        //    }

        //    return list;
        //}

        public List<T> ReadJson<T, D>() where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            var filepath = String.Format(Directory, typeof(D).Name);
            var list = new List<T>();

            if (File.Exists(filepath) == false)
                return list;

            using (StreamReader sr = new StreamReader(filepath))
            {
                var json = sr.ReadToEnd();

                var dres = JsonConvert.DeserializeObject<List<D>>(json);

                foreach (var row in dres)
                {
                    var drow = new T();

                    if (drow.PossibleDownCast<D>())
                    {
                        drow.DownCastToIPgmRow(row);
                        list.Add(drow);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            return list;
        }

        private List<D> ReadJson<D>() where D : DBData, new()
        {
            var filepath = String.Format(Directory, typeof(D).Name);

            if (File.Exists(filepath) == false)
                return new List<D>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                var json = sr.ReadToEnd();

                return JsonConvert.DeserializeObject<List<D>>(json);
            }
        }

        private List<T> ConvertList<T, D>(List<D> list) where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            var lst = new List<T>();

            foreach (var row in list)
            {
                var drow = new T();

                if (drow.PossibleDownCast<D>())
                {
                    drow.DownCastToIPgmRow(row);
                    lst.Add(drow);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            return lst;
        }

        private List<T> Get<T, D>() where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            var list = new List<T>();

            var dres = DB.GetCollection<D>(typeof(D).Name);

            foreach (var row in dres.Query().ToEnumerable())
            {
                var drow = new T();

                if (drow.PossibleDownCast<D>())
                {
                    drow.DownCastToIPgmRow(row);
                    list.Add(drow);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            return list;
        }

        public CollectSchedule GetCollectSchedule(Reserve reserve)
        {
            var r1 = (from a in Relations
                      where a.ReserveCode == reserve.ReserveCode
                      select a).FirstOrDefault();

            if (r1 == null)
                return null;

            var r2 = (from b in CollectSchedules
                      where b.RelationCode == r1.RelationCode
                      select b).FirstOrDefault();

            return r2;
        }


        public CollectSchedule GetCollectSchedule(Malfunction malfunction)
        {
            var r1 = (from a in Relations
                      where a.MalfunctionCode == malfunction.MalfunctionCode
                      select a).FirstOrDefault();

            if (r1 == null)
                return null;

            var r2 = (from b in CollectSchedules
                      where b.RelationCode == r1.RelationCode
                      select b).FirstOrDefault();

            return r2;
        }

        public Relation GetRelation(CollectSchedule schedule)
        {
            var r1 = (from a in Relations
                      where a.RelationCode == schedule.RelationCode
                      select a).FirstOrDefault();

            return r1;
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

                UpsertJson<ItemType, DBObject.ItemType>(ItemTypes.ToArray());
            }

            if (ItemStates.Count() == 0)
            {
                ItemStates.AddRange(new List<ItemState>
                {
                    new ItemState
                    {
                        ItemStateCode = 1,
                        StateName = "テストA",
                        ApplyKbnValue = ApplyKbns.Reserve,
                        StateColorValue = Color.White,
                    },
                    new ItemState
                    {
                        ItemStateCode = 2,
                        StateName = "テストB",
                        ApplyKbnValue = ApplyKbns.Malfunction,
                        StateColorValue = Color.LightBlue,
                    },
                    new ItemState
                    {
                        ItemStateCode = 3,
                        StateName = "テストC",
                        ApplyKbnValue = ApplyKbns.Reserve | ApplyKbns.Malfunction,
                        StateColorValue = Color.LightGreen,
                    },
                    new ItemState
                    {
                        ItemStateCode = 4,
                        StateName = "テストD",
                        ApplyKbnValue = ApplyKbns.NONE,
                        StateColorValue = Color.Red,
                    },
                    new ItemState
                    {
                        ItemStateCode = 5,
                        StateName = "テストE",
                        ApplyKbnValue = ApplyKbns.MalfunctionState,
                        StateColorValue = Color.Red,
                    },
                    new ItemState
                    {
                        ItemStateCode = 6,
                        StateName = "テストF",
                        ApplyKbnValue = ApplyKbns.CollectionState,
                        StateColorValue = Color.Red,
                    },
                });

                UpsertJson<ItemState, DBObject.ItemState>(ItemStates.ToArray());
            }


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

        private static DirectoryInfo SafeCreateDirectory(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                return null;
            }

            return System.IO.Directory.CreateDirectory(path);
        }
    }
}
