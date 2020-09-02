using System;
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
            MalfunctionState = 4,
            CollectionState = 8,
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
                    case ApplyKbns.MalfunctionState: return "故障機状況";
                    case ApplyKbns.CollectionState: return "回収状況";
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

        #region 状態区分

        public enum ItemStateTypes
        {
            BeforeErased,
            Erased,
            Abandoned,
            Discard,
            Reuse,
            PhysicalDestruction,
            YetCollect,
            Collected,
            NONE,
        }

        public class ItemStateType
        {
            private ItemStateTypes type;

            public ItemStateType(ItemStateTypes v)
            {
                this.type = v;
            }

            public ItemStateType(string flag)
            {
                switch (flag)
                {
                    case "1": this.type = ItemStateTypes.BeforeErased; break;
                    case "2": this.type = ItemStateTypes.Erased; break;
                    case "3": this.type = ItemStateTypes.Abandoned; break;
                    case "4": this.type = ItemStateTypes.Discard; break;
                    case "5": this.type = ItemStateTypes.Reuse; break;
                    case "6": this.type = ItemStateTypes.PhysicalDestruction; break;
                    case "7": this.type = ItemStateTypes.YetCollect; break;
                    case "8": this.type = ItemStateTypes.Collected; break;
                    default: this.type = ItemStateTypes.NONE; break;
                }
            }

            public static ItemStateType GetTypeForDBValue(string DBValue)
            {
                switch (DBValue)
                {
                    case "1": return ItemStateTypes.BeforeErased;
                    case "2": return ItemStateTypes.Erased;
                    case "3": return ItemStateTypes.Abandoned;
                    case "4": return ItemStateTypes.Discard;
                    case "5": return ItemStateTypes.Reuse;
                    case "6": return ItemStateTypes.PhysicalDestruction;
                    case "7": return ItemStateTypes.YetCollect;
                    case "8": return ItemStateTypes.Collected;
                    default: return ItemStateTypes.NONE;
                }
            }

            public string DBValue
            {
                get
                {
                    switch (this.type)
                    {
                        case ItemStateTypes.BeforeErased: return "1";
                        case ItemStateTypes.Erased: return "2";
                        case ItemStateTypes.Abandoned: return "3";
                        case ItemStateTypes.Discard: return "4";
                        case ItemStateTypes.Reuse: return "5";
                        case ItemStateTypes.PhysicalDestruction: return "6";
                        case ItemStateTypes.YetCollect: return "7";
                        case ItemStateTypes.Collected: return "8";
                        default: return "0";
                    }
                }
            }

            public static ApplyKbn GetApplyKbn(ItemStateTypes type)
            {
                switch (type)
                {
                    case ItemStateTypes.Collected: return ApplyKbns.CollectionState | ApplyKbns.MalfunctionState;
                    case ItemStateTypes.YetCollect: return ApplyKbns.CollectionState | ApplyKbns.MalfunctionState;
                    default: return ApplyKbns.NONE;
                }
            }

            public ApplyKbn ApplyKbn
            {
                get
                {
                    return GetApplyKbn(this.type);
                }
            }

            public string ViewValue
            {
                get
                {
                    switch (this.type)
                    {
                        case ItemStateTypes.BeforeErased: return "未消去";
                        case ItemStateTypes.Erased: return "消去済";
                        case ItemStateTypes.Abandoned: return "廃棄待";
                        case ItemStateTypes.Discard: return "廃棄済";
                        case ItemStateTypes.Reuse: return "再利用";
                        case ItemStateTypes.PhysicalDestruction: return "物理破壊待";
                        case ItemStateTypes.YetCollect: return "未回収";
                        case ItemStateTypes.Collected: return "回収済";
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
            //            case ItemStateTypes.BeforeErased: return Color.White;
            //            case ItemStateTypes.Erased: return Color.LightGreen;
            //            case ItemStateTypes.Abandoned: return Color.Yellow;
            //            case ItemStateTypes.Discard: return Color.LightPink;
            //            case ItemStateTypes.Reuse: return Color.SkyBlue;
            //            case ItemStateTypes.PhysicalDestruction: return Color.Orange;
            //            default: return Color.White;
            //        }
            //    }
            //}

            public ItemStateTypes Value
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
            /// <param name="ItemStateType"></param>
            public static implicit operator ItemStateTypes(ItemStateType ItemStateType)
            {
                return ItemStateType.type;
            }

            /// <summary>
            /// 静的型変換
            /// Enum -> Class
            /// </summary>
            /// <param name="ItemStateTypes"></param>
            public static implicit operator ItemStateType(ItemStateTypes ItemStateTypes)
            {
                return new ItemStateType(ItemStateTypes);
            }
        }

        #endregion
    }
}
