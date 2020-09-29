using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareLedger
{
    public partial class FormSearchCondition : Form
    {
        public FormSearchCondition()
        {
            InitializeComponent();
        }
    }

    public interface ISearchConditionReceiver<T> where T : DataGridViewRowBase, IListOrder
    {
        void SetSortedList(IEnumerable<T> list);
    }

    public interface IListOrder
    {
        IEnumerable<SortOrderProperties> RelatedProperties { get; }
    }

    public class SortOrderProperties
    {
        /// <summary>
        /// セルに表示される値。これが基本
        /// </summary>
        public string CellValueName { get; set; }

        /// <summary>
        /// コンボボックスで表示する文字列
        /// </summary>
        public string ComboboxColumnName { get; set; }

        /// <summary>
        /// ソートに使う値。内部の値
        /// </summary>
        public string InnerValueName { get; set; }
    }

    public abstract class DataGridViewRowBase
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

    }
}
