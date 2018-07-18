using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Constants.Excels;
using ManagerStuffs.Bll.StuffsBll;
using ManagerStuffs.Bll.Users;
using ManagerStuffs.Bll.PlaceStuffsBll;
using ManagerStuffs.Bll.CategoriesBll;
using MetroFramework.Controls;
using MetroFramework;
using ManagerStuffs.Constants;
using OfficeOpenXml;
using ManagerStuffs.Constants.Excels.Export;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucExportExcels : UserControl
    {
        public ucExportExcels()
        {
            InitializeComponent();
        }

        private string columnFilter = "";

        // Method LoadAll
        void LoadAll()
        {
            ManipulationExcel.ListTablesForComboBox(cbbTables);
        }

        // Method LoadList
        void LoadList(string sortColumn, string sortBy, string columnFilter, object filterValue)
        {
            if(cbbTables.SelectedIndex > -1)
            {
                string keyword = txtName.Text.Trim();

                switch(cbbTables.SelectedValue.ToString())
                {
                    case "STUFFS":
                        StuffsBll.Instance.ListForExcel(gvData, keyword, sortColumn, sortBy, columnFilter, filterValue);
                        break;
                    case "USERS":
                        UsersBll.Instance.ListForExcel(gvData, keyword, sortColumn, sortBy, columnFilter, filterValue);
                        break;
                    case "ROLES":
                        
                        break;
                    case "PLACESTUFFS":
                        PlaceStuffsBll.Instance.ListForExcel(gvData, keyword, sortColumn, sortBy);
                        break;
                    case "STUFFSPLACESTUFFS":
                       
                        break;
                    case "CATEGORIES":
                        CategoriesBll.Instance.ListForExcel(gvData, keyword, sortColumn, sortBy);
                        break;
                }
            }
        }

        // Method 
        void Sort(DataGridViewColumn col)
        {
            if (col != null)
            {
                string sortBy = (col.Tag == null || col.Tag.ToString() == "DESC") ? "ASC" : "DESC";

                int colIndex = col.Index;

                LoadList(col.Name, sortBy, "", "");

                gvData.Columns[colIndex].Tag = sortBy;

                gvData.Columns[colIndex].HeaderText = gvData.Columns[colIndex].HeaderText + (sortBy == "ASC" ? " + " : " - ");

                gvData.Columns[colIndex].HeaderCell.Style.BackColor = Color.FromArgb(103, 65, 114);

                gvData.Columns[colIndex].HeaderCell.Style.ForeColor = Color.White;
            }
        }

        // Method ExportExcel
        void ExportExcel()
        {
            if(gvData.Rows.Count > 0)
            {
                GlobalConstants.ResponseResult res = ManipulationExportExcel.ExportExcel(GlobalConstants.Username, cbbTables.Text, cbbTables.Text, gvData);

                switch (res.TypeResponse)
                {
                    case GlobalConstants.EnumResponse.NotExsistPath:
                        MetroMessageBox.Show(this, "Đường dẫn không hợp lệ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
                        break;
                    case GlobalConstants.EnumResponse.ExportSuccess:
                        MetroMessageBox.Show(this, "Xuất excel thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                        break;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bảng này không có dữ liệu để xuất ra excel !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Method Filter
        void Filter(DataGridViewColumn col)
        {
            if(col != null)
            {
                ctmnGridViewData.Items.Clear();

                Dictionary<string, object> dics = new Dictionary<string, object>();

                switch (cbbTables.SelectedValue.ToString())
                {
                    case "STUFFS":
                        dics = StuffsBll.Instance.ListDataByCoumn(col.Name);
                        break;
                    case "USERS":
                        dics = UsersBll.Instance.ListDataByCoumn(col.Name);
                        break;
                    case "ROLES":

                        break;
                    case "PLACESTUFFS":
                        
                        break;
                    case "STUFFSPLACESTUFFS":

                        break;
                    case "CATEGORIES":
                        
                        break;
                }

                foreach (KeyValuePair<string, object> item in dics)
                {
                    ToolStripItem toolItem = new ToolStripMenuItem(item.Key);

                    toolItem.Tag = item.Value;

                    toolItem.Click += ToolItem_Click;

                    ctmnGridViewData.Items.Add(toolItem);
                }

                ctmnGridViewData.Show(new Point(Cursor.Position.X, Cursor.Position.Y));

                columnFilter = col.Name;
            }
        }
        
        // Event Click Item 
        private void ToolItem_Click(object sender, EventArgs e)
        {
            LoadList("", "", columnFilter, (sender as ToolStripItem).Tag);
        }

        // Event Click Button Filter
        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadList("", "", "", "");
        }

        // Event Click Button ExportExcel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        // Event Load Form
        private void ucExportExcels_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetStranlatesForTableLayout();
            tableLayoutPanel2.SetStranlatesForTableLayout();

            LoadAll();
        }

        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn col = (sender as MetroGrid).Columns[e.ColumnIndex];

            if (e.Button == MouseButtons.Left)
            {
                Sort(col);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Filter(col);
            }
        }
    }
}
