using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Bll.CategoriesBll;
using MetroFramework;
using ManagerStuffs.Constants;
using MetroFramework.Controls;
using ManagerStuffs.Constants.Roles;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucCategories : UserControl
    {
        public ucCategories()
        {
            InitializeComponent();
        }

        // Method DeleteCategory
        void DeleteCategory()
        {
            if (gvCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvCategories.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                int rowIndex = row.Index;

                int id = Convert.ToInt32(gvCategories["Id", row.Index].Value.ToString());

                string nameCategory = gvCategories["Name", row.Index].Value.ToString();

                DialogResult quesion = MetroMessageBox.Show(this, $"Bạn có chắn chắc muốn xóa {nameCategory} chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if (quesion == DialogResult.Yes)
                {
                    GlobalConstants.ResponseResult res = CategoriesBll.Instance.Delete(id);
                    switch (res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.DeleteSuccess:
                            gvCategories.DataSource = res.Result;

                            if(gvCategories.RowCount > 0)
                            {
                                gvCategories.CurrentCell = gvCategories.Rows[rowIndex - 1].Cells["Id"];

                                gvCategories.Rows[rowIndex - 1].Selected = true;
                            }

                            ClickRowGridViewBindingText();

                            LogEvent.Log = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - xóa một danh mục vật tư [{nameCategory}]";

                            MetroMessageBox.Show(this, $"Bạn đã xóa '{nameCategory}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.DeleteFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa dữ liệu, xin vui lòng thử xóa lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.ForeignKey:
                            MetroMessageBox.Show(this, $"Bạn không thể không thể xóa {nameCategory} được vì danh mục này đang được sử dụng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn danh mục vật tư cần xóa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Method EditCategory
        void EditCategory()
        {
            if(gvCategories.SelectedRows.Count > 0)
            {
                string categoryName = txtNameCategories.Text.Trim();

                if (string.IsNullOrEmpty(categoryName))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Tên danh mục !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtNameCategories.Focus();

                    return;
                }

                DataGridViewRow row = gvCategories.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                int id = Convert.ToInt32(gvCategories["Id", row.Index].Value.ToString());

                string nameCategoryOld = gvCategories["Name", row.Index].Value.ToString();

                string nameCategoryNew = txtNameCategories.Text.Trim();

                DialogResult quesion = MetroMessageBox.Show(this, $"Bạn có chắn chắc muốn sửa '{nameCategoryOld}' thành '{nameCategoryNew}'chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if (quesion == DialogResult.Yes)
                {
                    GlobalConstants.ResponseResult res = CategoriesBll.Instance.Edit(id, nameCategoryNew, cbStatus.Checked, GlobalConstants.Username);

                    switch(res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.EditSuccess:
                            gvCategories.DataSource = res.Result;

                            LogEvent.Log = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - sửa danh mục vật tư [{nameCategoryOld}] thành [{nameCategoryNew}]";

                            MetroMessageBox.Show(this, $"Sửa danh mục vật tư {nameCategoryOld} thành {nameCategoryNew} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                            row = gvCategories.Rows.Cast<DataGridViewRow>().FirstOrDefault(p => p.Cells["Id"].Value.ToString().Equals(id.ToString()));

                            if(row != null)
                            {
                                gvCategories.CurrentCell = row.Cells["Id"];

                                row.Selected = true;
                            }

                            ClickRowGridViewBindingText();
                            break;
                        case GlobalConstants.EnumResponse.EditFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình thay đổi dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.Unique:
                            MetroMessageBox.Show(this, $"Tên danh mục {nameCategoryOld} đã bị trùng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);

                            txtNameCategories.Focus();
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn danh mục vật tư cần sửa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Method InsertCategory
        void InsertCategory()
        {
            string categoryName = txtNameCategories.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên danh mục !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtNameCategories.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = CategoriesBll.Instance.Insert(categoryName, cbStatus.Checked, GlobalConstants.Username);

            switch (res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.InsertSuccess:
                    int idCategoryMax = 0;

                    if(gvCategories.RowCount > 0)
                    {
                        idCategoryMax = Convert.ToInt32(gvCategories["Id", gvCategories.RowCount - 1].Value.ToString());
                    }

                    gvCategories.DataSource = res.Result;

                    LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - thêm một danh mục vật tư [{ categoryName}]";

                    MetroMessageBox.Show(this, $"Thêm danh mục '{categoryName}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                    for (int i = 0; i < gvCategories.RowCount; i++)
                    {
                        if (Convert.ToInt32(gvCategories["Id", i].Value.ToString()) > idCategoryMax)
                        {
                            idCategoryMax = Convert.ToInt32(gvCategories["Id", i].Value.ToString());

                            break;
                        }
                    }

                    if(idCategoryMax > 0)
                    {
                        DataGridViewRow row = gvCategories.Rows.Cast<DataGridViewRow>().FirstOrDefault(p => p.Cells["Id"].Value.ToString().Equals(idCategoryMax.ToString()));

                        if (row != null)
                        {
                            gvCategories.CurrentCell = row.Cells["Id"];

                            row.Selected = true;
                        }
                    }
                    else
                    {
                        gvCategories.CurrentCell = gvCategories.Rows[0].Cells["Id"];

                        gvCategories.Rows[0].Selected = true;
                    }

                    ClickRowGridViewBindingText();
                    break;
                case GlobalConstants.EnumResponse.InsertFail:
                    MetroMessageBox.Show(this, "Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.Unique:
                    MetroMessageBox.Show(this, "Tên danh mục bị trùng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);

                    txtNameCategories.Focus();
                    break;
            }
        }

        // Method 
        void ClickRowGridViewBindingText()
        {
            if(gvCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvCategories.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                txtNameCategories.Text = gvCategories["Name", row.Index].Value.ToString();
                cbStatus.Checked = Convert.ToBoolean(gvCategories["Status", row.Index].Value);
            } else
            {
                txtNameCategories.ResetText();
                cbStatus.Checked = false;
            }

            gvCategories.Focus();
        }

        // Method LoadCategories
        void LoadCategories()
        {
            CategoriesBll.Instance.List(gvCategories, false);

            txtFilterCategories.Focus();
        }

        // Method Overide Refresh
        public override void Refresh()
        {
            LoadCategories();

            base.Refresh();
        }

        // Event Type Button Insert
        private void btnInsertCategories_Click(object sender, EventArgs e)
        {
            InsertCategory();
        }

        // Event Type Button Edit
        private void btnEditCategories_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        // Event Type Button Delete
        private void btnDeleteCategories_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        // Event Load UserControl
        private void ucCategories_Load(object sender, EventArgs e)
        {
            tableLayoutPanel3.SetRoleForTableLayout();

            tableLayoutPanel3.SetStranlatesForTableLayout();
            lbFilter.SetStranlateForControlSingle();
            tableLayoutPanel2.SetStranlatesForTableLayout();

            LoadCategories();

            ClickRowGridViewBindingText();
        }

        // Event Type TextBox Search
        private void txtFilterCategories_TextChanged(object sender, EventArgs e)
        {
            CategoriesBll.Instance.Search(gvCategories, txtFilterCategories.Text);
        }

        // Event Click TextBox Search
        private void txtFilterCategories_Click(object sender, EventArgs e)
        {
            CategoriesBll.Instance.List(gvCategories);
        }

        // Event Click Row GridView
        private void gvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickRowGridViewBindingText();
        }

        // Event Press Function Delete
        private void gvCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 46)
            {
                DeleteCategory();
            }

            gvCategories.Focus();
        }
    }
}
