using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class Excel
    {
        /// <summary>
        /// シートを作成する
        /// </summary>
        /// <returns></returns>
        public static string CreateHardwareLedger()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var excelpath = documents + @"\HardwareLedger\Excel-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xlsx";

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var res = new List<ReservePrintRow>();

                    foreach (var re in DBAccessor.Instance.Get<Reserve>())
                        res.Add(re);

                    CreateSheet(workbook, "予備機台帳", res);


                    var mal = new List<MalfunctionPrintRow>();

                    foreach (var ma in DBAccessor.Instance.Get<Malfunction>())
                        mal.Add(ma);

                    CreateSheet(workbook, "故障機台帳", mal);


                    workbook.SaveAs(excelpath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return excelpath;
        }

        /// <summary>
        /// ワークシートを作成する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="workbook"></param>
        /// <param name="sheetname"></param>
        /// <param name="list"></param>
        private static void CreateSheet<T>(XLWorkbook workbook, string sheetname, List<T> list) where T : IExcelPrintRow, new()
        {
            var sheet = workbook.Worksheets.Add(sheetname);

            var t = new T();

            //何列目に何の項目を当てはめるかは再帰的に決まってくる
            //列→行の順に当てはめていく
            for (int k = 0; k < t.PrintColumnKeyValues().Count(); k++)
            {
                var element = t.PrintColumnKeyValues().ElementAt(k);
                sheet.Cell(1, 1 + k).Value = element.Item2;

                for (int i = 0; i < list.Count(); i++)
                {
                    sheet.Cell(2 + i, k + 1).Value = list[i][element.Item1];
                }
            }

            //セルの大きさを内容物に合わせる
            sheet.ColumnsUsed().AdjustToContents();

            //罫線を引く
            sheet.Range(sheet.Cell(1, 1), sheet.Cell(1 + list.Count(), t.PrintColumnKeyValues().Count())).Style
                           .Border.SetTopBorder(XLBorderStyleValues.Thin)
                           .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                           .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                           .Border.SetRightBorder(XLBorderStyleValues.Thin);
        }

        /// <summary>
        /// 印刷用データのインターフェース
        /// </summary>
        private interface IExcelPrintRow
        {
            IEnumerable<String> PrintColumns();

            IEnumerable<(String, String)> PrintColumnKeyValues();

            object this[string propertyName] { get; set; }
        }

        /// <summary>
        /// 予備機印刷用
        /// </summary>
        private class ReservePrintRow : IExcelPrintRow
        {
            public int ReserveCode { get; set; }

            public ItemType ItemType { get; set; }

            public string ItemTypeStr => ItemType.ItemTypeName;

            public string Name { get; set; }

            public string ModelNo { get; set; }

            public ItemState ItemState { get; set; }

            public string ItemStateStr => ItemState.StateName;

            public ZaikoType Zaiko { get; set; }

            public string ZaikoStr => Zaiko.ViewValue;

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            public ShippingState ShippingState { get; set; }

            public String ShippingStateStr => ShippingState.ViewValue;

            public ShopType ShippingShop { get; set; }

            public String ShippingShopStr => ShippingShop == null ? String.Empty : ShippingShop.FullName;

            public ReserveShipping Shipping { get; set; }

            public String ShippingTimeStr => Shipping == null ? String.Empty : Shipping.ShippingTime.ToString("yyyy/MM/dd HH:mm:ss");

            /// <summary>
            /// 予備機→予備機印刷用変換
            /// </summary>
            /// <param name="res"></param>
            public static implicit operator ReservePrintRow(Reserve res)
            {
                var row = new ReservePrintRow();

                row.ReserveCode = res.ReserveCode;
                row.ItemType = DBAccessor.Instance.GetItemType(res);
                row.Name = res.Name;
                row.ModelNo = res.ModelNo;
                row.ItemState = DBAccessor.Instance.GetItemState(res);
                row.Zaiko = res.Zaiko;
                row.InsertTime = res.InsertTime;
                row.UpdateTime = res.UpdateTime;
                row.ShippingState = new ShippingState(res);
                row.Shipping = DBAccessor.Instance.GetShipping(res);
                row.ShippingShop = row.Shipping == null ? null : DBAccessor.Instance.GetShop(row.Shipping);

                return row;
            }

            /// <summary>
            /// プロパティを疑似的に連想配列化している
            /// </summary>
            /// <param name="propertyName"></param>
            /// <returns></returns>
            public object this[string propertyName]
            {
                get
                {
                    if (!PrintColumns().Contains(propertyName))
                        return null;

                    return GetType().GetProperty(propertyName).GetValue(this);
                }
                set
                {
                    if (!PrintColumns().Contains(propertyName))
                        return;

                    GetType().GetProperty(propertyName).SetValue(this, value);
                }
            }

            /// <summary>
            /// 印刷する項目
            /// </summary>
            /// <returns></returns>
            public IEnumerable<string> PrintColumns()
            {
                yield return nameof(ReserveCode);
                yield return nameof(ItemTypeStr);
                yield return nameof(Name);
                yield return nameof(ModelNo);
                yield return nameof(ItemStateStr);
                yield return nameof(ZaikoStr);
                yield return nameof(InsertTimeStr);
                yield return nameof(UpdateTimeStr);
                yield return nameof(ShippingStateStr);
                yield return nameof(ShippingShopStr);
                yield return nameof(ShippingTimeStr);
            }

            /// <summary>
            /// 印刷する項目と対応する行の名前
            /// </summary>
            /// <returns></returns>
            public IEnumerable<(String, String)> PrintColumnKeyValues()
            {
                yield return (nameof(ReserveCode), "予備機コード");
                yield return (nameof(ItemTypeStr), "種別");
                yield return (nameof(Name), "名前");
                yield return (nameof(ModelNo), "型番");
                yield return (nameof(ItemStateStr), "状態");
                yield return (nameof(ZaikoStr), "在庫区分");
                yield return (nameof(InsertTimeStr), "追加日時");
                yield return (nameof(UpdateTimeStr), "更新日時");
                yield return (nameof(ShippingStateStr), "発送状況");
                yield return (nameof(ShippingShopStr), "発送先店舗");
                yield return (nameof(ShippingTimeStr), "発送日時");
            }
        }
        private class MalfunctionPrintRow : IExcelPrintRow
        {
            public int MalfunctionCode { get; set; }

            public ItemType ItemType { get; set; }

            public string ItemTypeStr => ItemType.ItemTypeName;

            public string Name { get; set; }

            public string ModelNo { get; set; }

            public ItemState ItemState { get; set; }

            public string ItemStateStr => ItemState.StateName;

            public ZaikoType Zaiko { get; set; }

            public string ZaikoStr => Zaiko.ViewValue;

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            /// <summary>
            /// 故障機→故障機印刷用変換
            /// </summary>
            /// <param name="mal"></param>
            public static implicit operator MalfunctionPrintRow(Malfunction mal)
            {
                var row = new MalfunctionPrintRow();

                row.MalfunctionCode = mal.MalfunctionCode;
                row.ItemType = DBAccessor.Instance.GetItemType(mal);
                row.Name = mal.Name;
                row.ModelNo = mal.ModelNo;
                row.ItemState = DBAccessor.Instance.GetItemState(mal);
                row.Zaiko = mal.Zaiko;
                row.InsertTime = mal.InsertTime;
                row.UpdateTime = mal.UpdateTime;

                return row;
            }

            /// <summary>
            /// プロパティを疑似的に連想配列化している
            /// </summary>
            /// <param name="propertyName"></param>
            /// <returns></returns>
            public object this[string propertyName]
            {
                get
                {
                    if (!PrintColumns().Contains(propertyName))
                        return null;

                    return GetType().GetProperty(propertyName).GetValue(this);
                }
                set
                {
                    if (!PrintColumns().Contains(propertyName))
                        return;

                    GetType().GetProperty(propertyName).SetValue(this, value);
                }
            }

            /// <summary>
            /// 印刷する項目
            /// </summary>
            /// <returns></returns>
            public IEnumerable<string> PrintColumns()
            {
                yield return nameof(MalfunctionCode);
                yield return nameof(ItemTypeStr);
                yield return nameof(Name);
                yield return nameof(ModelNo);
                yield return nameof(ItemStateStr);
                yield return nameof(ZaikoStr);
                yield return nameof(InsertTimeStr);
                yield return nameof(UpdateTimeStr);
            }


            /// <summary>
            /// 印刷する項目と対応する行の名前
            /// </summary>
            /// <returns></returns>
            public IEnumerable<(String, String)> PrintColumnKeyValues()
            {
                yield return (nameof(MalfunctionCode), "故障機コード");
                yield return (nameof(ItemTypeStr), "種別");
                yield return (nameof(Name), "名前");
                yield return (nameof(ModelNo), "型番");
                yield return (nameof(ItemStateStr), "状態");
                yield return (nameof(ZaikoStr), "在庫区分");
                yield return (nameof(InsertTimeStr), "追加日時");
                yield return (nameof(UpdateTimeStr), "更新日時");
            }
        }
    }
}
