using ManagerStuffs.Constants;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs.Constants.Roles
{
    public static class ManipulationRoles
    {
        public static string Admin = "Admin";

        public static string MenuRoles = "mRoles";

        public static List<ManipulationRoleModel> Roles { get; set; } = new List<ManipulationRoleModel>();

        // Method GetRoles
        public static List<ManipulationRoleModel> GetRolesByRole(string role)
        {
            Roles.Clear();

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            string selectRoles = $"SELECT * FROM ROLES WHERE ROLE = '{role}'";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = selectRoles;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Roles.Add(new ManipulationRoleModel
                            {
                                Manipulation = reader["MANIPULATION"].ToString(),
                                Role = reader["ROLE"].ToString()
                            });
                        }
                    }

                    con.Close();
                }
            }

            return Roles;
        }

        // Method GetRoles
        public static void ListRoles(MetroGrid grid)
        {
            List<RoleModel> roles = new List<RoleModel>();

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            string selectRoles = $"SELECT ROLE, COUNT(*) FROM ROLES WHERE ROLE IS NOT NULL GROUP BY ROLE";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = selectRoles;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new RoleModel
                            {
                                RoleName = reader["ROLE"].ToString(),
                                CountManipulation = Convert.ToInt32(reader["COUNT(*)"].ToString())
                            });
                        }
                    }

                    con.Close();

                    grid.DataSource = null;

                    grid.DataSource = roles;
                }
            }
        }

        // Method ListRolesForComboBox
        public static void ListRolesForComboBox(MetroComboBox cbb)
        {
            cbb.DataSource = null;

            List<RoleModel> roles = new List<RoleModel>();

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            string selectRoles = $"SELECT ROLE, COUNT(*) FROM ROLES WHERE ROLE IS NOT NULL GROUP BY ROLE";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = selectRoles;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new RoleModel
                            {
                                RoleName = reader["ROLE"].ToString(),
                                CountManipulation = Convert.ToInt32(reader["COUNT(*)"].ToString())
                            });
                        }
                    }

                    con.Close();

                    cbb.DataSource = null;

                    cbb.DataSource = roles;

                    cbb.DisplayMember = "RoleName";

                    cbb.ValueMember = "RoleName";
                }
            }
        }

        // Method GetManipulationsByRole
        public static void GetManipulationsByRole(MetroGrid grid, string role)
        {
            List<ManipulationRoleModelUI> rolesUIs = new List<ManipulationRoleModelUI>();

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            string selectRoles = $"SELECT * FROM ROLES WHERE ROLE = '{role}'";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = selectRoles;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string description = Enum.GetValues(typeof(EnumRoles)).Cast<Enum>().Where(p => p.GetControlName().Equals(reader["MANIPULATION"].ToString())).Select(p => p.GetDescription()).FirstOrDefault();

                            rolesUIs.Add(new ManipulationRoleModelUI
                            {
                                Description = description,
                                Manipulation = reader["MANIPULATION"].ToString()
                            });
                        }
                    }

                    con.Close();

                    grid.DataSource = null;

                    grid.DataSource = rolesUIs;

                    grid.Columns["Manipulation"].Visible = false;
                }
            }
        }

        // Method SetRolesForForm
        public static void SetRoleForMenu(this MenuStrip menu)
        {
            if(GlobalConstants.RoleName != Admin)
            {
                ManipulationRoleModel maniModel = Roles.Where(p => p.Manipulation.Equals(EnumRoles.AllRoles.GetControlName())).FirstOrDefault();

                ToolStripItem item = menu.Items.Cast<ToolStripItem>().Where(p => p.Name.Equals(MenuRoles)).FirstOrDefault();

                menu.Items.Remove(item);

                if (maniModel == null)
                {
                    for (int i = 0; i < menu.Items.Count; i++)
                    {
                        ManipulationRoleModel manipulationModel = Roles.Where(p => p.Manipulation.Equals(menu.Items[i].Name)).FirstOrDefault();

                        if (manipulationModel == null)
                        {
                            menu.Items.RemoveAt(i);

                            i--;
                        }
                    }
                }
            }
        }

        // Method SetRolesShowLogs
        public static bool SetRolesShowLogs()
        {
            if (GlobalConstants.RoleName != Admin)
            {
                ManipulationRoleModel maniModel = Roles.Where(p => p.Manipulation.Equals(EnumRoles.AllRoles.GetControlName())).FirstOrDefault();

                if (maniModel == null)
                {
                    return Roles.Where(p => p.Manipulation.Equals(EnumRoles.ShowLogs.GetControlName())).FirstOrDefault() != null;
                }
            }
             
            return true;
        }

        // Method SetRoleForUserControl
        public static void SetRoleForTableLayout(this TableLayoutPanel layout)
        {
            if (GlobalConstants.RoleName != Admin)
            {
                foreach(Control c in layout.Controls)
                {
                    MetroButton button = c as MetroButton;

                    if(button != null)
                    {
                        ManipulationRoleModel manipulationModel = Roles.Where(p => p.Manipulation.Equals(button.Name)).FirstOrDefault();

                        if(manipulationModel == null)
                        {
                            button.Enabled = false;
                        }
                    }
                }
            }
        }

        // Method ListRoles
        public static void ListManipulations(MetroGrid grid)
        {
            var values = Enum.GetValues(typeof(EnumRoles));

            List<ManipulationRoleModelUI> roleUIs = new List<ManipulationRoleModelUI>();

            foreach(var item in values)
            {
                Enum e = item as Enum;

                roleUIs.Add(new ManipulationRoleModelUI
                {
                    Description = e.GetDescription(),
                    Manipulation = e.GetControlName()
                });
            }
        
            grid.DataSource = null;

            grid.DataSource = roleUIs;

            grid.Columns["Manipulation"].Visible = false;
        }

        // Method InsertRole
        public static GlobalConstants.ResponseResult InsertRole(string roleName, MetroGrid grid)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            if(CheckRoleExsist(roleName))
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            int execute = 0;

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        command.CommandText = $"INSERT INTO ROLES(MANIPULATION, ROLE) VALUES('{grid["Manipulation", i].Value.ToString()}', '{roleName}')";

                        execute += command.ExecuteNonQuery();
                    }

                    con.Close();

                    if(execute == grid.Rows.Count)
                    {
                        res.TypeResponse = GlobalConstants.EnumResponse.InsertSuccess;
                    }
                    else
                    {
                        res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
                    }
                }
            }

            return res;
        }

        // Method CLearGridViewManipulationsOfRole
        public static void CLearGridViewManipulationsOfRole(MetroGrid grid)
        {
            grid.DataSource = null;

            grid.DataSource = new List<ManipulationRoleModelUI>();
        }

        // MethodLeftManipulation
        public static void MethodLeftManipulation(MetroGrid gridLeft, MetroGrid gridRight)
        {
            if(gridRight.SelectedRows.Count > 0)
            {
                List<ManipulationRoleModelUI> roleModelLefts = (List<ManipulationRoleModelUI>)gridLeft.DataSource;

                if (gridRight.SelectedRows[0].Cells["Manipulation"].Value.ToString() == EnumRoles.AllRoles.GetControlName())
                {
                    roleModelLefts.Clear();

                    roleModelLefts.Add(new ManipulationRoleModelUI
                    {
                        Description = EnumRoles.AllRoles.GetDescription(),
                        Manipulation = EnumRoles.AllRoles.GetControlName()
                    });
                }
                else
                {
                    if (roleModelLefts.Any(p => p.Manipulation.Equals(EnumRoles.AllRoles.GetControlName())))
                    {
                        roleModelLefts.Clear();
                    }

                    ManipulationRoleModelUI modelUI = roleModelLefts.Where(p => p.Manipulation.Equals(gridRight.SelectedRows[0].Cells["Manipulation"].Value.ToString())).FirstOrDefault();

                    if (modelUI == null)
                    {
                        Enum e = Enum.GetValues(typeof(EnumRoles)).Cast<Enum>().Where(p => p.GetControlName().Equals(gridRight.SelectedRows[0].Cells["Manipulation"].Value.ToString())).FirstOrDefault();

                        modelUI = new ManipulationRoleModelUI
                        {
                            Manipulation = e.GetControlName(),
                            Description = e.GetDescription()
                        };

                        roleModelLefts.Add(modelUI);
                    }
                }

                gridLeft.DataSource = null;

                gridLeft.DataSource = roleModelLefts;

                gridLeft.Columns[1].Visible = false;
            }

            gridRight.Focus();
        }

        // MethodRightManipulation
        public static void MethodRightManipulation(MetroGrid gridLeft)
        {
            if (gridLeft.SelectedRows.Count > 0)
            {
                List<ManipulationRoleModelUI> roleModelLefts = (List<ManipulationRoleModelUI>)gridLeft.DataSource;

                ManipulationRoleModelUI modelUI = roleModelLefts.Where(p => p.Manipulation.Equals(gridLeft.SelectedRows[0].Cells["Manipulation"].Value.ToString())).FirstOrDefault();

                if(modelUI != null)
                {
                    roleModelLefts.Remove(modelUI);

                    gridLeft.DataSource = null;

                    gridLeft.DataSource = roleModelLefts;

                    gridLeft.Columns[1].Visible = false;
                }
            }

            gridLeft.Focus();
        }

        // Method CheckRoleExsist
        public static bool CheckRoleExsist(string roleName)
        {
            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = $"SELECT COUNT(*) FROM ROLES WHERE ROLE = '{roleName}'";

                    object count = command.ExecuteScalar();

                    con.Close();

                    return Convert.ToInt32(count) > 0;
                }
            }
        }

        // Method UpdateRole
        public static GlobalConstants.ResponseResult UpdateRole(string roleName, MetroGrid grid)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int execute = 0;

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = $"DELETE FROM ROLES WHERE ROLE = '{roleName}'";

                    command.ExecuteNonQuery();

                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        command.CommandText = $"INSERT INTO ROLES(MANIPULATION, ROLE) VALUES('{grid["Manipulation", i].Value.ToString()}', '{roleName}')";

                        execute += command.ExecuteNonQuery();
                    }

                    con.Close();

                    if (execute == grid.Rows.Count)
                    {
                        res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;
                    }
                    else
                    {
                        res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
                    }
                }
            }

            return res;
        }

        // Method DeleteRole
        public static GlobalConstants.ResponseResult DeleteRole(string roleName)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int execute = 0;

            string originalPath = Application.StartupPath;

            string fileSQLite = originalPath + "\\Roles.db3";

            if (!File.Exists(fileSQLite))
            {
                SQLiteConnection.CreateFile("Roles.db3");
            }

            string createRoles = @"CREATE TABLE IF NOT EXISTS [ROLES]
                                   (
                                       [MANIPULATION] VARCHAR(20) NOT NULL,
                                       [ROLE] VARCHAR(50) NOT NULL
                                   )
                                 ";

            using (SQLiteConnection con = new SQLiteConnection("Data Source = Roles.db3"))
            {
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    con.Open();

                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = createRoles;

                    command.ExecuteNonQuery();

                    command.CommandText = $"DELETE FROM ROLES WHERE ROLE = '{roleName}'";

                    execute = command.ExecuteNonQuery();

                    con.Close();

                    if (execute >= 1)
                    {
                        res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;
                    }
                    else
                    {
                        res.TypeResponse = GlobalConstants.EnumResponse.DeleteFail;
                    }
                }
            }

            return res;
        }
    }
}
