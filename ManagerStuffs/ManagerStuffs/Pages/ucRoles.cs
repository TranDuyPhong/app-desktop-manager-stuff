using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Constants.Roles;
using ManagerStuffs.Constants;
using MetroFramework;
using ManagerStuffs.Bll.RolesBll;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucRoles : UserControl
    {
        private bool isInsert;

        public ucRoles()
        {
            InitializeComponent();
        }

        // Method LoadAll
        void LoadAll()
        {
            ManipulationRoles.ListRoles(gvRoles);

            ManipulationRoles.ListManipulations(gvManipulations);

            LoadManipulationsOfRole();

            // ClickRowBindingText();
        }

        // Method ClickRowBindingText
        void ClickRowBindingText()
        {
            if (gvRoles.SelectedRows.Count > 0)
            {
                txtRoleName.Text = gvRoles["RoleName", gvRoles.SelectedRows[0].Index].Value.ToString();
            }
        }

        // Method InsertRole
        void InsertRole()
        {
            switch (isInsert)
            {
                case true:
                    string roleName = txtRoleName.Text.Trim();

                    if (string.IsNullOrEmpty(roleName))
                    {
                        MetroMessageBox.Show(this, "Bạn chưa nhập Tên quyền !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                        txtRoleName.Focus();

                        return;
                    }

                    if (gvManipulationOfRole.Rows.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Bạn cần có ít nhất một thao tác cho phép đối với quyền này !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                        gvManipulations.Focus();

                        return;
                    }

                    GlobalConstants.ResponseResult resSqlite = ManipulationRoles.InsertRole(roleName, gvManipulationOfRole);

                    GlobalConstants.ResponseResult resSqlServer = RolesBll.Instance.Insert(roleName);
                    
                    switch(resSqlite.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.InsertSuccess:
                            switch(resSqlServer.TypeResponse)
                            {
                                case GlobalConstants.EnumResponse.InsertSuccess:
                                    LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - thêm một quyền [{roleName}]";

                                    ManipulationRoles.ListRoles(gvRoles);

                                    int rowIndex = gvRoles.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["RoleName"].Value.ToString().Equals(roleName)).FirstOrDefault().Index;

                                    gvRoles.CurrentCell = gvRoles.Rows[rowIndex].Cells["RoleName"];

                                    gvRoles.Rows[rowIndex].Selected = true;

                                    LoadManipulationsOfRole();

                                    ClickButtonInsertRole(true);

                                    MetroMessageBox.Show(this, $"Thêm quyền '{roleName}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                                    txtRoleName.ResetText();

                                    txtRoleName.Focus();
                                    break;
                                case GlobalConstants.EnumResponse.InsertFail:
                                    MetroMessageBox.Show(this, $"Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                                    break;
                            }
                            break;
                        case GlobalConstants.EnumResponse.InsertFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.Unique:
                            MetroMessageBox.Show(this, $"Tên quyền '{roleName}' của bạn bị trùng, xin vui lòng nhập tên quyền khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                            txtRoleName.Focus();
                            break;
                    }
                    break;
                case false:
                    if(gvManipulationOfRole.Rows.Count <= 0)
                    {
                        MetroMessageBox.Show(this, "Bạn cần có ít nhất một thao tác cho phép đối với quyền này !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                        gvManipulations.Focus();

                        return;
                    }

                    string roleNameCurrent = gvRoles["RoleName", gvRoles.SelectedRows[0].Index].Value.ToString();

                    GlobalConstants.ResponseResult resUpdate = ManipulationRoles.UpdateRole(roleNameCurrent, gvManipulationOfRole);

                    switch(resUpdate.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.EditSuccess:
                            LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - sửa quyền [{roleNameCurrent}]";

                            LoadManipulationsOfRole();

                            ClickButtonInsertRole(true);

                            MetroMessageBox.Show(this, $"Sửa thao tác cho quyền '{roleNameCurrent}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                            txtRoleName.Focus();
                            break;
                        case GlobalConstants.EnumResponse.EditFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình thay đổi dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                    break;
            }

            gvRoles.Focus();
        }

        // Method ClickButtonInsertRole
        void ClickButtonInsertRole(bool status)
        {
            btnDeleteRole.Enabled = status;
            gvRoles.Enabled = status;

            btnInsertRole.Text = status ? "Thêm quyền" : "Hủy";

            isInsert = !status;
        }

        // Method ClickRowGridViewRolesBindingText
        void LoadManipulationsOfRole()
        {
            if(gvRoles.SelectedRows.Count > 0)
            {
                ManipulationRoles.GetManipulationsByRole(gvManipulationOfRole, gvRoles.SelectedRows[0].Cells["RoleName"].Value.ToString());
            }
        }

        // Method DeleteRole
        void DeleteRole()
        {
            if(gvRoles.SelectedRows.Count > 0)
            {
                string roleName = gvRoles["RoleName", gvRoles.SelectedRows[0].Index].Value.ToString();

                DialogResult dialog = MetroMessageBox.Show(this, $"Bạn chắc chắn muốn xóa quyền '{roleName}' này chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if(dialog == DialogResult.Yes)
                {
                    GlobalConstants.ResponseResult resSqlServer = RolesBll.Instance.Delete(roleName);

                    GlobalConstants.ResponseResult resSqlite = ManipulationRoles.DeleteRole(roleName);

                    switch (resSqlServer.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.DeleteSuccess:
                            switch(resSqlite.TypeResponse)
                            {
                                case GlobalConstants.EnumResponse.DeleteSuccess:
                                    LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - xóa quyền [{roleName}]";

                                    LoadAll();

                                    MetroMessageBox.Show(this, $"Xóa quyền '{roleName}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                                    txtRoleName.Focus();
                                    break;
                                case GlobalConstants.EnumResponse.DeleteFail:
                                    MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                                    break;
                            }
                            break;
                        case GlobalConstants.EnumResponse.DeleteFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.ForeignKey:
                            MetroMessageBox.Show(this, "Quyền này đang được áp dụng cho một số user, hiện tại không thể xóa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }         
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn quyền cần xóa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }

            gvRoles.Focus();
        }

        // Event Load UserControl
        private void ucRoles_Load(object sender, EventArgs e)
        {
            lbListRoles.SetStranlateForControlSingle();
            lbManipulations.SetStranlateForControlSingle();
            lbManipulationsNot.SetStranlateForControlSingle();
            lbRoleName.SetStranlateForControlSingle();

            tableLayoutPanel2.SetStranlatesForTableLayout();

            LoadAll();

            txtRoleName.Focus();
        }

        // Event Click Button Insert Role
        private void btnInsertRole_Click(object sender, EventArgs e)
        {
            if(isInsert)
            {
                ClickButtonInsertRole(true);

                DataGridViewRow row = gvRoles.SelectedRows[0];

                int indexRow = row.Index;

                LoadAll();

                gvRoles.CurrentCell = gvRoles.Rows[indexRow].Cells["RoleName"];

                gvRoles.Rows[indexRow].Selected = true;
            }
            else
            {
                ManipulationRoles.CLearGridViewManipulationsOfRole(gvManipulationOfRole);

                ClickButtonInsertRole(false);
            }

            txtRoleName.Focus();
        }

        // Event Click Button ChangeRole
        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            InsertRole();
        }

        // Event Click Button Left
        private void btnLeft_Click(object sender, EventArgs e)
        {
            ManipulationRoles.MethodLeftManipulation(gvManipulationOfRole, gvManipulations);
        }

        // Event Click Button Right
        private void btnRight_Click(object sender, EventArgs e)
        {
            ManipulationRoles.MethodRightManipulation(gvManipulationOfRole);
        }

        // Event Click Row GridView Role
        private void gvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadManipulationsOfRole();

            // ClickRowBindingText();
        }

        // Event Click Button Delete Role
        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            DeleteRole();
        }

        // Event Keydown GridView Manipulation
        private void gvManipulations_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Left)
            {
                ManipulationRoles.MethodLeftManipulation(gvManipulationOfRole, gvManipulations);
            }
        }

        // Event Keydown GridView ManipulationOfRole
        private void gvManipulationOfRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Delete)
            {
                ManipulationRoles.MethodRightManipulation(gvManipulationOfRole);
            }
        }

        // Event Keydown GridView Roles
        private void gvRoles_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                DeleteRole();
            }
        }
    }
}
