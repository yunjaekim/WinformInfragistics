using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(InitFrom);
        }

        private void InitFrom(object sender, EventArgs e)
        {
            InitializeGrid();
            InitializeGroup();
        }

        private void InitializeGrid()
        {
            DataSet dataSet = new DataSet();

            DataTable table = new DataTable();
            table.Columns.Add("Index", typeof(int));
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));
            table.Columns.Add("R", typeof(int));
            table.Columns.Add("Z", typeof(int));

            for (int i = 1; i < 10; i++)
            {
                table.Rows.Add(new object[] { i, i, i, i, i });
            }

            DataTable childTable = new DataTable();
            childTable.Columns.Add("key", typeof(int));
            childTable.Columns.Add("value", typeof(int));

            for (int i = 1; i < 10; i++)
            {
                childTable.Rows.Add(new object[] { i, i });
            }
            
            dataSet.Tables.Add(table);
            dataSet.Tables.Add(childTable);

            dataSet.Relations.Add(dataSet.Tables[0].Columns[0], dataSet.Tables[1].Columns[0]);

            this.ultraGrid1.DataSource = dataSet;
        }

        private void InitializeGroup()
        {
            this.ultraGrid1.DisplayLayout.Bands[0].RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;

            Infragistics.Win.UltraWinGrid.UltraGridGroup num        = this.ultraGrid1.DisplayLayout.Bands[0].Groups.Add("num");
            Infragistics.Win.UltraWinGrid.UltraGridGroup position   = this.ultraGrid1.DisplayLayout.Bands[0].Groups.Add("position");
            Infragistics.Win.UltraWinGrid.UltraGridGroup rotate     = this.ultraGrid1.DisplayLayout.Bands[0].Groups.Add("rotate");

            Infragistics.Win.UltraWinGrid.UltraGridGroup group = this.ultraGrid1.DisplayLayout.Bands[0].Groups.Add("group");
            group.Header.Caption = "Total";
            
            this.ultraGrid1.DisplayLayout.Bands[0].Columns["Index"].RowLayoutColumnInfo.ParentGroup = num;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns["X"].RowLayoutColumnInfo.ParentGroup     = position;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns["Y"].RowLayoutColumnInfo.ParentGroup     = position;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns["Z"].RowLayoutColumnInfo.ParentGroup     = rotate;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns["R"].RowLayoutColumnInfo.ParentGroup     = rotate;

            this.ultraGrid1.DisplayLayout.Bands[0].Groups["num"].RowLayoutGroupInfo.ParentGroup         = group;
            this.ultraGrid1.DisplayLayout.Bands[0].Groups["position"].RowLayoutGroupInfo.ParentGroup    = group;
            this.ultraGrid1.DisplayLayout.Bands[0].Groups["rotate"].RowLayoutGroupInfo.ParentGroup      = group;
        }
        
    }
}
