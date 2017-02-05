using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
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
            CreateUnboundColumn();
        }

        private void InitializeGrid()
        {
            DataSet dataSet = new DataSet();

            DataTable personInfo = dataSet.Tables.Add("PersonInfo");
            personInfo.Columns.Add("Index",     typeof(int));
            personInfo.Columns.Add("Name",      typeof(string));
            personInfo.Columns.Add("SnowId",    typeof(int));

            personInfo.Rows.Add(1, "jaekim1", 1);
            personInfo.Rows.Add(2, "jaekim2", 2);
            personInfo.Rows.Add(3, "jaekim3", 2);
            personInfo.Rows.Add(4, "jaekim4", 2);

            DataTable snowInfo = dataSet.Tables.Add("SnowInfo");
            snowInfo.PrimaryKey = new DataColumn[] { snowInfo.Columns.Add("Key", typeof(int)) };
            snowInfo.Columns.Add("Value", typeof(string));

            snowInfo.Rows.Add(1, "ski");
            snowInfo.Rows.Add(2, "board");

            dataSet.Relations.Add(
                dataSet.Tables["SnowInfo"].Columns["Key"],
                dataSet.Tables["PersonInfo"].Columns["SnowId"]);
            
            this.ultraGrid1.DataSource = dataSet;
            
        }
        private void CreateUnboundColumn()
        {
            
            this.ultraGrid1.DisplayLayout.Bands[0].Columns["SnowId"].Hidden = true;

            this.ultraGrid1.DisplayLayout.Bands[0].Columns.Add("Snow");
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ultraGrid1.Rows)
            {    
                int snowID = (int)row.Cells["SnowId"].Value;
                DataRow snowRow = (ultraGrid1.DataSource as DataSet).Tables["SnowInfo"].Rows.Find(snowID);
                row.Cells["Snow"].Value = snowRow.ItemArray[1];
            }
        }
        
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
    }
}
