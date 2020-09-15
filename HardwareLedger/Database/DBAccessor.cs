using HardwareLedger.DBObject;
using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        private Dictionary<Type, List<IPgmRow>> data;

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
            //var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //SafeCreateDirectory(documents + @"\HardwareLedger\Database\");
            //Directory = documents + @"\HardwareLedger\Database\{0}.json";
            Directory = @"Database\{0}.json";

            //SafeCreateDirectory(documents + @"\HardwareLedger\Database\");
            SafeCreateDirectory(@"Database\");

            data = new Dictionary<Type, List<IPgmRow>>();

            Reserves = ReadJson<Reserve, DBObject.Reserve>();
            ShopTypes = ReadJson<ShopType, DBObject.ShopType>();
            ItemTypes = ReadJson<ItemType, DBObject.ItemType>();
            ItemStates = ReadJson<ItemState, DBObject.ItemState>();
            Malfunctions = ReadJson<Malfunction, DBObject.Malfunction>();
            Relations = ReadJson<Relation, DBObject.Relation>();
            CollectSchedules = ReadJson<CollectSchedule, DBObject.CollectSchedule>();
            ReserveShippings = ReadJson<ReserveShipping, DBObject.ReserveShipping>();




            data.Add(typeof(Reserve), Reserves.Cast<IPgmRow>().ToList());
            data.Add(typeof(ShopType), ShopTypes.Cast<IPgmRow>().ToList());
            data.Add(typeof(ItemType), ItemTypes.Cast<IPgmRow>().ToList());
            data.Add(typeof(ItemState), ItemStates.Cast<IPgmRow>().ToList());
            data.Add(typeof(Malfunction), Malfunctions.Cast<IPgmRow>().ToList());
            data.Add(typeof(Relation), Relations.Cast<IPgmRow>().ToList());
            data.Add(typeof(CollectSchedule), CollectSchedules.Cast<IPgmRow>().ToList());
            data.Add(typeof(ReserveShipping), ReserveShippings.Cast<IPgmRow>().ToList());
        }

        public List<T> Get<T>() where T : DBData, IPgmRow, new()
        {
            if (data.ContainsKey(typeof(T)))
            {
                return data[typeof(T)].Cast<T>().ToList();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Upsert<T, D>(params T[] rows) where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            if (data.ContainsKey(typeof(T)))
            {
                data[typeof(T)] = UpsertJson<T, D>(rows).Cast<IPgmRow>().ToList();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Remove<T, D>(params T[] rows) where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            if (data.ContainsKey(typeof(T)))
            {
                data[typeof(T)] = RemoveJson<T, D>(rows).Cast<IPgmRow>().ToList();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public List<T> Reflesh<T, D>() where T : DBData, IPgmRow, new() where D : DBData, new()
        {
            if (data.ContainsKey(typeof(T)))
            {
                var d = ReadJson<T, D>();
                data[typeof(T)] = d.Cast<IPgmRow>().ToList();
                return d;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        #region JSON Operating

        /// <summary>
        /// 登録･更新を行う
        /// DはTのスーパークラスでなければならない
        /// </summary>
        /// <typeparam name="T">Database直下のクラスを指定する。IPgmRowを実装している必要がある</typeparam>
        /// <typeparam name="D">Database.DBObject下のクラスを指定する。DBDataを継承している必要がある</typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 削除を行う
        /// DはTのスーパークラスでなければならない
        /// </summary>
        /// <typeparam name="T">Database直下のクラスを指定する。IPgmRowを実装している必要がある</typeparam>
        /// <typeparam name="D">Database.DBObject下のクラスを指定する。DBDataを継承している必要がある</typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 読込を行う
        /// DはTのスーパークラスでなければならない
        /// </summary>
        /// <typeparam name="T">Database直下のクラスを指定する。IPgmRowを実装している必要がある</typeparam>
        /// <typeparam name="D">Database.DBObject下のクラスを指定する。DBDataを継承している必要がある</typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 読込を行う
        /// </summary>
        /// <typeparam name="D">Database.DBObject下のクラスを指定する。DBDataを継承している必要がある</typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
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

        #endregion

        /// <summary>
        /// D型のリストをT型のリストに変換する
        /// D→T変換不可能であれば例外をスローする
        /// </summary>
        /// <typeparam name="T">IPgmRow型</typeparam>
        /// <typeparam name="D">DBData型</typeparam>
        /// <param name="list">D型のリスト</param>
        /// <returns>T型のリスト</returns>
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

        #region spam method

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

        public ReserveShipping GetShipping(Reserve reserve)
        {
            var r1 = (from a in ReserveShippings
                      where a.ReserveCode == reserve.ReserveCode
                      select a).FirstOrDefault();

            return r1;
        }

        public Malfunction GetMalfunction(CollectSchedule schedule)
        {
            var r1 = (from a in Relations
                      where a.RelationCode == schedule.RelationCode
                      select a).FirstOrDefault();

            if (r1 == null)
                return null;

            var r2 = (from b in Malfunctions
                      where b.MalfunctionCode == r1.MalfunctionCode
                      select b).FirstOrDefault();

            return r2;
        }

        public Reserve GetReserve(CollectSchedule schedule)
        {
            var r1 = (from a in Relations
                      where a.RelationCode == schedule.RelationCode
                      select a).FirstOrDefault();

            if (r1 == null)
                return null;

            var r2 = (from b in Reserves
                      where b.ReserveCode == r1.ReserveCode
                      select b).FirstOrDefault();

            return r2;
        }

        /// <summary>
        /// IReserveCodeを実装しているインスタンスからReserveを取得する
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public Reserve GetReserve(IReserveCode res)
        {
            var r1 = (from a in Reserves
                      where a.ReserveCode == res.ReserveCode
                      select a).FirstOrDefault();

            return r1;
        }

        public Relation GetRelation(Malfunction mal)
        {
            var r1 = (from a in Relations
                      where a.MalfunctionCode == mal.MalfunctionCode
                      select a).FirstOrDefault();

            return r1;
        }

        public Relation GetRelation(Reserve res)
        {
            var r1 = (from a in Relations
                      where a.ReserveCode == res.ReserveCode
                      select a).FirstOrDefault();

            return r1;
        }

        /// <summary>
        /// IStateCodeを実装しているインスタンスからItemStateを取得する
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public ItemState GetItemState(IStateCode poco)
        {
            var r1 = (from a in ItemStates
                      where a.ItemStateCode == poco.StateCode
                      select a).FirstOrDefault();

            return r1;
        }

        /// <summary>
        /// IShopCodeを実装しているインスタンスからShopTypeを取得する
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public ShopType GetShop(IShopCode poco)
        {
            var r1 = (from a in ShopTypes
                      where a.ShopCode == poco.ShopCode
                      select a).FirstOrDefault();

            return r1;
        }

        /// <summary>
        /// ITypeCodeを実装しているインスタンスからItemTypeを取得する
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public ItemType GetItemType(ITypeCode poco)
        {
            var r1 = (from a in ItemTypes
                      where a.ItemTypeCode == poco.TypeCode
                      select a).FirstOrDefault();

            return r1;
        }

        #endregion

        /// <summary>
        /// 指定された型のキー項目の最大値を取得する
        /// </summary>
        /// <typeparam name="D">DBData型</typeparam>
        /// <returns>キー項目の最大値 1行もなければ0</returns>
        public int MaxUniqueNumber<D>() where D : DBData, new()
        {
            var d = new D();
            var dd = ReadJson<D>();

            if (dd.Count() == 0)
                return 0;

            var max = dd.Max(x => x[d.GetKeyColumnName()]);

            return (int)max;
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
