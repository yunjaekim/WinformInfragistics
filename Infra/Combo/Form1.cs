using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(InitForm);
        }
        private void InitForm(object sender, EventArgs e)
        {
            InitializeGrid();
            InitializeCombo();
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // ultraGrid & Column 0
            e.Layout.Bands[0].Columns[0].ValueList = this.ultraCombo1;
        }

        private void InitializeGrid()
        {
            DataTable table = new DataTable();

            // col
            for (int i = 0; i < 4; i++)
            {
                string colName = "Column" + (i + 1).ToString();
                table.Columns.Add(colName, typeof(string));
            }
            // row
            for (int i = 0; i < 10; i++)
            {
                table.Rows.Add(new object[]
                {
                    (i + 1).ToString(),
                    (i + 2).ToString(),
                    (i + 3).ToString(),
                    (i + 4).ToString(),
                });
            }

            this.ultraGrid1.DataSource = table;
        }
        private void InitializeCombo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("key", Type.GetType("System.Int32"));
            table.Columns.Add("Value", typeof(string));

            for (int i = 0; i < 3; i++)
            {
                table.Rows.Add(new object[] { i, i.ToString() });
            }

            // 변경 내용 table에 적용.
            table.AcceptChanges();

            this.ultraCombo1.SetDataBinding(table, null);
            this.ultraCombo1.ValueMember    = "Key";
            this.ultraCombo1.DisplayMember  = "Value";
        }
    }
}
