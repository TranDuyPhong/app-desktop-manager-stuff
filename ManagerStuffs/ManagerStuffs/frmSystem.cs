using DevExpress.XtraBars.ToastNotifications;
using ManagerStuffs.Constants;
using ManagerStuffs.Constants.Languages;
using ManagerStuffs.Constants.Roles;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs
{
    public partial class frmSystem : MetroForm
    {
        public frmSystem()
        {
            InitializeComponent();
        }

        private ToolStripMenuItem itemCurrent;

        public string NameOfUser { get; set; }

        // Method FollowFileConfig
        void FollowFileConfig()
        {
            FileSystemWatcher followFileConfig = new FileSystemWatcher();

            followFileConfig.Path = GlobalConstants.PathFolderConfig;

            followFileConfig.Changed += FollowFileConfig_Changed;

            followFileConfig.EnableRaisingEvents = true;
        }

        // Method ReadLogs
        void ReadLogs(MetroGrid grid, List<LogModel> logs)
        {
            if(ManipulationRoles.SetRolesShowLogs())
            {
                grid.DataSource = null;

                grid.DataSource = logs;
            }
        }

        // Method SelectMenuForDevExpress (DevExpress)
        void SelectMenuForDevExpress(string page)
        {
            page = page.Substring(page.IndexOf("m") + 1);

            Type frmType = typeof(MetroForm);

            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(p => frmType.IsAssignableFrom(p) && p.Name.Contains(page)).FirstOrDefault();

            if (type != null)
            {
                Form f = this.MdiChildren.Where(p => p.GetType() == type).FirstOrDefault();

                if (f != null)
                {
                    f.Activate();
                }
                else
                {
                    f = Activator.CreateInstance(type) as Form;

                    f.MdiParent = this;

                    f.Show();
                }
            }
        }

        // Method SelectMenuForMetro (DevExpress)
        void SelectMenuForMetro(ToolStripMenuItem item)
        {
            string page = item.Name.Substring(item.Name.IndexOf("m") + 1);

            Type typeUserControl = typeof(UserControl);

            Type userControl = Assembly.GetExecutingAssembly().GetTypes().Where(p => typeUserControl.IsAssignableFrom(p) &&
                    p.Namespace == "ManagerStuffs.Pages" && p.Name.Substring(2).Equals((page))).FirstOrDefault();

            if(userControl != null)
            {
                Control control = pnParent.Controls.Cast<Control>().Where(p => p.Name.Contains(page) && p.GetType() == userControl).FirstOrDefault();

                if (control != null)
                {
                    control.Refresh();
                }
                else
                {
                    control = Activator.CreateInstance(userControl) as UserControl;

                    pnParent.Controls.Clear();

                    control.Dock = DockStyle.Fill;

                    pnParent.Controls.Add(control);

                    if (itemCurrent == null)
                    {
                        itemCurrent = item;
                    }

                    itemCurrent.BackColor = Color.FromArgb(255, 255, 255);

                    itemCurrent = item;

                    item.BackColor = Color.FromArgb(89, 171, 227);
                }
            }
        }

        // Event Click Menu
        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolTipItem = sender as ToolStripMenuItem;

            SelectMenuForMetro(toolTipItem);
        }
        
        // Event Load Form
        private void frmSystem_Load(object sender, EventArgs e)
        {
            menuStrip1.SetRoleForMenu();

            menuStrip1.SetStranlatesForMenuStrip();

            toolStrip1.SetStranlatesForToolStrip();

            changePassword.SetStranlateForItem();
            changeProfile.SetStranlateForItem();

            lbFilter.SetStranlateForControlSingle();

            lbUser.Text = NameOfUser;
            lbRole.Text = GlobalConstants.RoleName;

            notifyIcon1.ShowBalloonTip(2000, "Phần mềm quản lý vật tư Stuffs", "Chào mừng", ToolTipIcon.Info);

            if(menuStrip1.Items.Count == 0)
            {
                return;
            }

            SelectMenuForMetro(menuStrip1.Items.Cast<ToolStripMenuItem>().FirstOrDefault());

            ReadLogs(gvLogs, GlobalConstants.ReadLogs());

            lbVersion.Text = GlobalConstants.Config.Version;
            lbDateUsed.Text = GlobalConstants.Config.DateUse;

            FollowFileConfig();

            LogEvent.AddLog += LogEvent_AddLog;
        }

        // Event File Config Change
        private void FollowFileConfig_Changed(object sender, FileSystemEventArgs e)
        {
            GlobalConstants.GetConfig();

            lbVersion.Text = GlobalConstants.Config.Version;
            lbDateUsed.Text = GlobalConstants.Config.DateUse;
        }

        // Event Add Log
        private void LogEvent_AddLog(object sender, CustomLogEventArg e)
        {
            ReadLogs(gvLogs, e.Logs);
        }

        // Event Click Text Box Search Log
        private void txtSearchLogs_Click(object sender, EventArgs e)
        {
            GlobalConstants.ReadLogs();
        }

        // Event Type Text Box Search Log
        private void txtSearchLogs_TextChanged(object sender, EventArgs e)
        {
            ReadLogs(gvLogs, GlobalConstants.SearchLog(txtSearchLogs.Text));
        }

        // Event Click ChangePassword
        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword();

            frmChangePassword.ShowDialog();

            frmChangePassword = null;
        }

        // Event Click ChangeProfile
        private void thayĐổiThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeProfile frmChangeProfile = new frmChangeProfile(this);

            frmChangeProfile.ShowDialog();

            frmChangeProfile = null;
        }
    }
}
