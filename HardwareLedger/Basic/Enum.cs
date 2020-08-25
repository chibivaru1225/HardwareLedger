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

        #region 状態区分

        public enum ItemStateTypes
        {
            BeforeErased,
            Erased,
            Abandoned,
            Discard,
            Reuse,
            PhysicalDestruction,
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
                        default: return "0";
                    }
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
