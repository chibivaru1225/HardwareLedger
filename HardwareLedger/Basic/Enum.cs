﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class Enum
    {
        #region 適用区分

        [Flags]
        public enum ApplyKbns
        {
            NONE = 0,
            Reserve = 1,
            Malfunction = 2,
            ShippingState = 4,
            CollectionState = 8,
            MalfunctionState = 16,
        }

        public class ApplyKbn
        {
            private ApplyKbns kbn;

            public ApplyKbn(ApplyKbns v)
            {
                this.kbn = v;
            }

            public ApplyKbn(int flag)
            {
                kbn = GetKbnForDBValue(flag);
            }

            public static ApplyKbn GetKbnForDBValue(int DBValue)
            {
                return (ApplyKbns)System.Enum.ToObject(typeof(ApplyKbns), DBValue);
            }

            public int DBValue
            {
                get
                {
                    return (int)this.kbn;
                }
            }

            public string ViewValue
            {
                get
                {
                    string rv = String.Empty;

                    foreach (var akbn in System.Enum.GetValues(typeof(ApplyKbns)))
                    {
                        if (akbn is ApplyKbns type)
                        {
                            if ((kbn & type) == type)
                            {
                                if (!String.IsNullOrEmpty(rv))
                                    rv += ", ";

                                rv += ViewValueStr(type);
                            }
                        }
                    }

                    return rv;
                }
            }

            public static String ViewValueStr(ApplyKbns kbn)
            {
                switch (kbn)
                {
                    case ApplyKbns.Reserve: return "予備機";
                    case ApplyKbns.Malfunction: return "故障機";
                    case ApplyKbns.ShippingState: return "発送状況";
                    case ApplyKbns.CollectionState: return "回収状況";
                    case ApplyKbns.MalfunctionState: return "故障機状況";
                    default: return String.Empty;
                }
            }

            public ApplyKbns Value
            {
                get
                {
                    return this.kbn;
                }
            }

            /// <summary>
            /// 指定された区分を内包しているかどうか
            /// 区分が｢A | B｣の重ね合わせの状態のとき、｢A｣または｢B｣を指定するとtrueになり、｢C｣を指定するとfalseになる
            /// </summary>
            /// <param name="kbn"></param>
            /// <returns></returns>
            public bool Enclose(ApplyKbns kbn)
            {
                return (kbn & this.kbn) == kbn;
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="ApplyKbn"></param>
            public static implicit operator ApplyKbns(ApplyKbn ApplyKbn)
            {
                return ApplyKbn.kbn;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="ApplyKbns"></param>
            public static implicit operator ApplyKbn(ApplyKbns ApplyKbns)
            {
                return new ApplyKbn(ApplyKbns);
            }
        }

        #endregion

        #region 適用サブ区分

        [Flags]
        public enum ApplySubKbns
        {
            NONE,
            Single,
            Multi,
        }

        public class ApplySubKbn
        {
            private ApplySubKbns skbn;

            public ApplySubKbn(ApplySubKbns v)
            {
                this.skbn = v;
            }

            public ApplySubKbn(ApplyKbn v)
            {
                this.skbn = GetApplyKbnState(v);
            }

            public static ApplySubKbn GetApplyKbnState(ApplyKbn kbn)
            {
                int i = 0;

                foreach (var akbn in System.Enum.GetValues(typeof(ApplyKbns)))
                {
                    if (akbn is ApplyKbns type && type != ApplyKbns.NONE)
                    {
                        if ((kbn & type) == type)
                            i++;
                    }
                }

                switch (i)
                {
                    case 0: return ApplySubKbns.NONE;
                    case 1: return ApplySubKbns.Single;
                    default: return ApplySubKbns.Multi;
                }
            }

            public string ViewValue
            {
                get
                {
                    return ViewValueStr(this.skbn);
                }
            }

            public static String ViewValueStr(ApplySubKbns kbn)
            {
                switch (kbn)
                {
                    case ApplySubKbns.NONE: return "なし";
                    case ApplySubKbns.Single: return "単一";
                    case ApplySubKbns.Multi: return "複数";
                    default: return String.Empty;
                }
            }

            public ApplySubKbns Value
            {
                get
                {
                    return this.skbn;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="ApplySubKbn"></param>
            public static implicit operator ApplySubKbns(ApplySubKbn ApplySubKbn)
            {
                return ApplySubKbn.skbn;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="ApplySubKbns"></param>
            public static implicit operator ApplySubKbn(ApplySubKbns ApplySubKbns)
            {
                return new ApplySubKbn(ApplySubKbns);
            }
        }

        #endregion

        #region 予備機発送状況区分

        public enum ShippingStates
        {
            Undecided,
            Etc,
            NONE,
        }

        public class ShippingState
        {
            private ShippingStates type;
            private ItemState state;

            public ShippingState(ShippingStates v)
            {
                this.type = v;
            }

            public ShippingState(string flag)
            {
                this.type = GetTypeForDBValue(flag);
            }

            public static ShippingState GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return ShippingStates.Undecided;
                    case "2": return ShippingStates.Etc;
                    default: return ShippingStates.NONE;
                }
            }

            public ShippingState(Reserve res)
            {
                this.type = GetTypeForReserve(res);

                if (this.type == ShippingStates.Etc)
                {
                    var si = DBAccessor.Instance.GetShipping(res);
                    this.state = (from a in DBAccessor.Instance.ItemStates
                                  where a.ItemStateCode == si.State
                                  select a).FirstOrDefault();
                }
            }

            public static ShippingState GetTypeForReserve(Reserve res)
            {
                var cs = DBAccessor.Instance.GetShipping(res);

                if (cs == null)
                    return ShippingStates.Undecided;

                return ShippingStates.Etc;
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case ShippingStates.Undecided: return "1";
                        case ShippingStates.Etc: return "2";
                        default: return "0";
                    }
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (type)
                    {
                        case ShippingStates.Undecided: return "未登録";
                        case ShippingStates.Etc: return state.StateName;
                        default: return String.Empty;
                    }
                }
            }

            public ShippingStates Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="ShippingState"></param>
            public static implicit operator ShippingStates(ShippingState ShippingState)
            {
                return ShippingState.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="ShippingStates"></param>
            public static implicit operator ShippingState(ShippingStates ShippingStates)
            {
                return new ShippingState(ShippingStates);
            }
        }

        #endregion

        #region 故障機回収状況区分

        public enum CollectStates
        {
            Undecided,
            Appointment,
            Done,
            NONE,
        }

        public class CollectState
        {
            private CollectStates type;
            private Reserve res;

            public CollectState(CollectStates v)
            {
                this.type = v;
            }

            public CollectState(string flag)
            {
                this.type = GetTypeForDBValue(flag);
            }

            public static CollectState GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return CollectStates.Undecided;
                    case "2": return CollectStates.Appointment;
                    case "3": return CollectStates.Done;
                    default: return CollectStates.NONE;
                }
            }

            public CollectState(Reserve res)
            {
                this.type = GetTypeForReserve(res);
            }

            public static CollectState GetTypeForReserve(Reserve res)
            {
                var cs = DBAccessor.Instance.GetCollectSchedule(res);

                if (cs == null)
                    return CollectStates.Undecided;

                if (cs.CollectTime == null)
                    return CollectStates.Appointment;
                else
                    return CollectStates.Done;
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case CollectStates.Undecided: return "1";
                        case CollectStates.Appointment: return "2";
                        case CollectStates.Done: return "3";
                        default: return "0";
                    }
                }
            }

            public static string GetViewValue(CollectStates type)
            {
                switch (type)
                {
                    case CollectStates.Undecided: return "回収予定なし";
                    case CollectStates.Appointment: return "回収予定あり";
                    case CollectStates.Done: return "回収済み";
                    default: return String.Empty;
                }
            }

            public string ViewValue
            {
                get
                {
                    return GetViewValue(this.type);
                }
            }

            //public Color RowColor
            //{
            //    get
            //    {
            //        switch (this.type)
            //        {
            //            case CollectStates.BeforeErased: return Color.White;
            //            case CollectStates.Erased: return Color.LightGreen;
            //            case CollectStates.Abandoned: return Color.Yellow;
            //            case CollectStates.Discard: return Color.LightPink;
            //            case CollectStates.Reuse: return Color.SkyBlue;
            //            case CollectStates.PhysicalDestruction: return Color.Orange;
            //            default: return Color.White;
            //        }
            //    }
            //}

            public CollectStates Value
            {
                get
                {
                    return this.type;
                }
            }

            public Reserve Reserve
            {
                get
                {
                    return this.res;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="CollectState"></param>
            public static implicit operator CollectStates(CollectState CollectState)
            {
                return CollectState.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="CollectStates"></param>
            public static implicit operator CollectState(CollectStates CollectStates)
            {
                return new CollectState(CollectStates);
            }
        }

        #endregion

        #region 在庫区分

        public enum ZaikoTypes
        {
            Zaiko,
            HiZaiko,
            NONE,
        }

        public class ZaikoType
        {
            private ZaikoTypes type;

            public ZaikoType(ZaikoTypes v)
            {
                this.type = v;
            }

            public ZaikoType(string flag)
            {
                this.type = GetTypeForDBValue(flag);
            }

            public static ZaikoType GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return ZaikoTypes.Zaiko;
                    case "2": return ZaikoTypes.HiZaiko;
                    default: return ZaikoTypes.NONE;
                }
            }

            public string DBValue
            {
                get
                {
                    return GetDBValue(this.type);
                }
            }

            public static string GetDBValue(ZaikoTypes type)
            {
                switch (type)
                {
                    case ZaikoTypes.Zaiko: return "1";
                    case ZaikoTypes.HiZaiko: return "2";
                    default: return "0";
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case ZaikoTypes.Zaiko: return "在庫品";
                        case ZaikoTypes.HiZaiko: return "非在庫";
                        default: return String.Empty;
                    }
                }
            }

            //public Color RowColor
            //{
            //    get
            //    {
            //        switch (this.type)
            //        {
            //            case ZaikoTypes.BeforeErased: return Color.White;
            //            case ZaikoTypes.Erased: return Color.LightGreen;
            //            case ZaikoTypes.Abandoned: return Color.Yellow;
            //            case ZaikoTypes.Discard: return Color.LightPink;
            //            case ZaikoTypes.Reuse: return Color.SkyBlue;
            //            case ZaikoTypes.PhysicalDestruction: return Color.Orange;
            //            default: return Color.White;
            //        }
            //    }
            //}

            public ZaikoTypes Value
            {
                get
                {
                    return this.type;
                }
            }

            /// <summary>
            /// 静的型変換
            /// Class -> Enum
            /// </summary>
            /// <param name="ZaikoType"></param>
            public static implicit operator ZaikoTypes(ZaikoType ZaikoType)
            {
                return ZaikoType.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="ZaikoTypes"></param>
            public static implicit operator ZaikoType(ZaikoTypes ZaikoTypes)
            {
                return new ZaikoType(ZaikoTypes);
            }
        }

        #endregion
    }
}
