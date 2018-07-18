using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Bll.PlaceStuffsBll;
using ManagerStuffs.Constants;
using MetroFramework;
using ManagerStuffs.Constants.Roles;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucPlaceStuffs : UserControl
    {
        public ucPlaceStuffs()
        {
            InitializeComponent();
        }

        // Method Delete
        void Delete()
        {
            if (gvPlaceStuffs.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                int rowIndex = row.Index;

                int id = Convert.ToInt32(gvPlaceStuffs["Id", row.Index].Value.ToString());

                string namePlaceStuff = gvPlaceStuffs["Name", row.Index].Value.ToString();

                DialogResult quesion = MetroMessageBox.Show(this, $"Bạn có chắn chắc muốn xóa {namePlaceStuff} chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if (quesion == DialogResult.Yes)
                {
                    GlobalConstants.ResponseResult res = PlaceStuffsBll.Instance.Delete(id);
                    switch (res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.DeleteSuccess:
                            gvPlaceStuffs.DataSource = res.Result;

                            if (gvPlaceStuffs.RowCount > 0)
                            {
                                gvPlaceStuffs.CurrentCell = gvPlaceStuffs.Rows[rowIndex - 1].Cells["Id"];

                                gvPlaceStuffs.Rows[rowIndex - 1].Selected = true;
                            }

                            ClickRowGridViewBindingText();

                            LogEvent.Log = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - xóa nơi [{namePlaceStuff}]";

                            MetroMessageBox.Show(this, $"Bạn đã xóa '{namePlaceStuff}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.DeleteFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa dữ liệu, xin vui lòng thử xóa lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.ForeignKey:
                            MetroMessageBox.Show(this, $"Bạn không thể không thể xóa {namePlaceStuff} được vì nơi này đang được sử dụng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn nơi cần xóa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Method Edit
        void Edit()
        {
            if(gvPlaceStuffs.SelectedRows.Count > 0)
            {
                string namePlaceStuffNew= txtNamePlaceStuffs.Text.Trim();

                if (string.IsNullOrEmpty(namePlaceStuffNew))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Tên nơi !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtNamePlaceStuffs.Focus();

                    return;
                }

                DataGridViewRow row = gvPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                int id = Convert.ToInt32(gvPlaceStuffs["Id", row.Index].Value.ToString());

                string nameCategoryOld = gvPlaceStuffs["Name", row.Index].Value.ToString();

                DialogResult quesion = MetroMessageBox.Show(this, $"Bạn có chắn chắc muốn sửa '{nameCategoryOld}' thành '{namePlaceStuffNew}'chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if (quesion == DialogResult.Yes)
                {
                    GlobalConstants.ResponseResult res = PlaceStuffsBll.Instance.Edit(id, namePlaceStuffNew);

                    switch (res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.EditSuccess:
                            gvPlaceStuffs.DataSource = res.Result;

                            LogEvent.Log = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - sửa nơi [{nameCategoryOld}] thành [{namePlaceStuffNew}]";

                            MetroMessageBox.Show(this, $"Sửa nơi {nameCategoryOld} thành {namePlaceStuffNew} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                            row = gvPlaceStuffs.Rows.Cast<DataGridViewRow>().FirstOrDefault(p => p.Cells["Id"].Value.ToString().Equals(id.ToString()));

                            if (row != null)
                            {
                                gvPlaceStuffs.CurrentCell = row.Cells["Id"];

                                row.Selected = true;
                            }

                            ClickRowGridViewBindingText();
                            break;
                        case GlobalConstants.EnumResponse.EditFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình thay đổi dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.Unique:
                            MetroMessageBox.Show(this, $"Tên nơi {nameCategoryOld} đã bị trùng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);

                            txtNamePlaceStuffs.Focus();
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn nơi cần sửa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Method Insert
        void Insert()
        {
            string namePlaceStuff = txtNamePlaceStuffs.Text.Trim();

            if(string.IsNullOrEmpty(namePlaceStuff))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên nơi !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtNamePlaceStuffs.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = PlaceStuffsBll.Instance.Insert(namePlaceStuff);

            switch (res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.InsertSuccess:
                    int idCategoryMax = 0;

                    if (gvPlaceStuffs.RowCount > 0)
                    {
                        idCategoryMax = Convert.ToInt32(gvPlaceStuffs["Id", gvPlaceStuffs.RowCount - 1].Value.ToString());
                    }

                    gvPlaceStuffs.DataSource = res.Result;

                    LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - thêm một nơi [{ namePlaceStuff}]";

                    MetroMessageBox.Show(this, $"Thêm nơi '{namePlaceStuff}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                    for (int i = 0; i < gvPlaceStuffs.RowCount; i++)
                    {
                        if (Convert.ToInt32(gvPlaceStuffs["Id", i].Value.ToString()) > idCategoryMax)
                        {
                            idCategoryMax = Convert.ToInt32(gvPlaceStuffs["Id", i].Value.ToString());

                            break;
                        }
                    }

                    if (idCategoryMax > 0)
                    {
                        DataGridViewRow row = gvPlaceStuffs.Rows.Cast<DataGridViewRow>().FirstOrDefault(p => p.Cells["Id"].Value.ToString().Equals(idCategoryMax.ToString()));

                        if (row != null)
                        {
                            gvPlaceStuffs.CurrentCell = row.Cells["Id"];

                            row.Selected = true;
                        }
                    }
                    else
                    {
                        gvPlaceStuffs.CurrentCell = gvPlaceStuffs.Rows[0].Cells["Id"];

                        gvPlaceStuffs.Rows[0].Selected = true;
                    }

                    ClickRowGridViewBindingText();
                    break;
                case GlobalConstants.EnumResponse.InsertFail:
                    MetroMessageBox.Show(this, "Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.Unique:
                    MetroMessageBox.Show(this, "Tên nơi bị trùng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);

                    txtNamePlaceStuffs.Focus();
                    break;
            }
        }

        // Method LoadPlaceStuffs
        void LoadPlaceStuffs()
        {
            tableLayoutPanel3.SetRoleForTableLayout();

            PlaceStuffsBll.Instance.List(gvPlaceStuffs, false);

            txtFilterPlaceStuffs.Focus();
        }

        // Method ClickRowGridViewBindingText
        void ClickRowGridViewBindingText()
        {
            if (gvPlaceStuffs.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                txtNamePlaceStuffs.Text = gvPlaceStuffs["Name", row.Index].Value.ToString();
            }
            else
            {
                gvPlaceStuffs.ResetText();
            }

            gvPlaceStuffs.Focus();
        }

        // Event Load Form
        private void ucPlaceStuffs_Load(object sender, EventArgs e)
        {
            lbFilter.SetStranlateForControlSingle();
            tableLayoutPanel3.SetStranlatesForTableLayout();
            lbNamePlaceStuff.SetStranlateForControlSingle();

            LoadPlaceStuffs();

            ClickRowGridViewBindingText();
        }

        // Event Click Row GridView
        private void gvPlaceStuffs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickRowGridViewBindingText();
        }

        // Event Type TextBox Filter PlaceStuffs
        private void txtFilterPlaceStuffs_TextChanged(object sender, EventArgs e)
        {
            PlaceStuffsBll.Instance.Search(gvPlaceStuffs, txtFilterPlaceStuffs.Text);
        }
         
        // Event Click TextBox Filter PlaceStuffs
        private void txtFilterPlaceStuffs_Click(object sender, EventArgs e)
        {
            PlaceStuffsBll.Instance.List(gvPlaceStuffs);
        }

        // Event Click Button Insert
        private void btnInsertPlaceStuffs_Click(object sender, EventArgs e)
        {
            Insert();
        }

        // Event Click Button Edit
        private void btnEditPlaceStuffs_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Event Click Button Delete
        private void btnDeletePlaceStuffs_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
