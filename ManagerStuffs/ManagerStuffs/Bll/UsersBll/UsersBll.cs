using ManagerStuffs.Constants;
using ManagerStuffs.Dao.RolesDao;
using ManagerStuffs.Dao.Users;
using ManagerStuffs.Model.Users;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll.Users
{
    public class UsersBll
    {
        private static volatile UsersBll instance;

        private static object key = new object();

        public static UsersBll Instance
        {
            get
            {
                lock(key)
                {
                    if (instance == null)
                    {
                        instance = new UsersBll();
                    }

                    return instance;
                }
            }
        }

        private UsersBll() { }

        // Method Login
        public GlobalConstants.ResponseResult Login(string username, string password)
        {
            UsersModel user = UsersDao.Instance.Login(username.Trim(), password.Trim());

            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            if(user == null)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.LoginFail;
            }
            else if (user != null && !user.Status)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.BlockUser;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.LoginSuccess;

                res.Result = user;

                GlobalConstants.RoleName = user.RoleName;

                GlobalConstants.Username = user.Username;
            }

            return res;
        }

        // Method GetUsersByRoleName
        public void GetUsersByRoleName(MetroGrid grid, string roleName, string username)
        {
            roleName = roleName.Trim();

            grid.DataSource = null;

            grid.DataSource = (from p in UsersDao.Instance.GetUsersByRoleName(roleName, username)
                               select new
                               {
                                   Id = p.Id,
                                   Username = p.Username,
                                   Name = p.Name,
                                   RoleName = p.RoleName,
                                   Sex = p.Sex,
                                   BirthOfDate = p.BirthOfDate,
                                   Email = p.Email,
                                   PhoneNumber = p.PhoneNumber,
                                   Status = p.Status,
                               }).ToList();
        }

        // Method Insert
        public GlobalConstants.ResponseResult Insert(string username, string password, string name, bool sex, DateTime birthOfDate, string email, string phone, bool status, string roleName, string createdBy)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            username = username.Trim();

            int checkExist = UsersDao.Instance.CheckExist(username);
            
            if(checkExist > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            int roleId = RolesDao.Instance.GetRoleIdByName(roleName.Trim());

            if(roleId == 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.NotExsist;

                return res;
            }

            int execute = UsersDao.Instance.Insert(new UsersModel
            {
                Username = username,
                Password = password.Trim(),
                Name = name.Trim(),
                Sex = sex,
                BirthOfDate = birthOfDate,
                Email = email,
                PhoneNumber = phone,
                Status = status,
                CreatedBy = createdBy,
                CreatedDate = DateTime.Now,
                IdRoles = roleId
            }, new string[] 
            {
                "@USERNAME",
                "@PASSWORD",
                "@NAME",
                "@SEX",
                "@BIRTHOFDATE",
                "@EMAIL",
                "@PHONENUMBER",
                "@STATUS",
                "@CREATEDDATE",
                "@CREATEBY",
                "@MODIFIEDDATE:NULL",
                "@IDROLES"
            });

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
            }

            return res;
        }

        // Method Delete
        public GlobalConstants.ResponseResult Delete(int id, string usernameDelete, string usernameCurrent)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int execute = UsersDao.Instance.Delete(id);

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteFail;
            }

            return res;
        }

        // Method Edit
        public GlobalConstants.ResponseResult Edit(int id, string username, string password, string name, bool sex, DateTime birthOfDate, string email, string phone, bool status, string roleName, string editedBy)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            username = username.Trim();

            int checkExsist = UsersDao.Instance.CheckExistWithoutById(username, id);

            if(checkExsist > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            int roleId = RolesDao.Instance.GetRoleIdByName(roleName.Trim());

            if (roleId == 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.NotExsist;

                return res;
            }

            int execute = UsersDao.Instance.Edit(new UsersModel
            {
                Id = id,
                Username = username,
                Password = password,
                Name = name,
                Sex = sex,
                BirthOfDate = birthOfDate,
                Email = email,
                PhoneNumber = phone,
                Status = status,
                ModifiedDate = DateTime.Now,
                ModifiedBy = editedBy,
                IdRoles = roleId
            }, new string[] 
            {
                "@USERNAME",
                "@PASSWORD",
                "@NAME",
                "@SEX",
                "@BIRTHOFDATE",
                "@EMAIL",
                "@PHONENUMBER",
                "@STATUS",
                "@MODIFIEDDATE",
                "@MODIFIEDBY",
                "@IDROLES"
            });

            if (execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
            }

            return res;
        }

        // Method ChangePassword
        public GlobalConstants.ResponseResult ChangePassword(string username, string passwordOld, string passwordNew)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            username = username.Trim();
            passwordOld = passwordOld.Trim();
            passwordNew = passwordNew.Trim();

            int checkPassword = UsersDao.Instance.CheckPassword(username, passwordOld);

            if(checkPassword <= 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.NotMatch;

                return res;
            }

            int userId = UsersDao.Instance.GetUserIdByUsername(username);

            if(userId == 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.NotExsist;

                return res;
            }

            int execute = UsersDao.Instance.ChangePassword(userId, passwordNew);

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
            }

            return res;
        }

        // Method ChangeProfile
        public GlobalConstants.ResponseResult ChangeProfile(string username, string name, bool sex, DateTime birthOfDate, string email, string phone)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int userId = UsersDao.Instance.GetUserIdByUsername(username);

            if(userId == 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.NotExsist;

                return res;
            }

            int execute = UsersDao.Instance.ChangeProfile(new UsersModel
            {
                Id = userId,
                Name = name.Trim(),
                Sex = sex,
                BirthOfDate = birthOfDate,
                Email = email.Trim(),
                PhoneNumber = phone.Trim()
            }, new string[] 
            {
                "@NAME",
                "@SEX",
                "@BIRTHOFDATE",
                "@EMAIL",
                "@PHONENUMBER"
            });

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
            }

            return res;
        }

        // Method ListForExcel
        public void ListForExcel(MetroGrid grid, string keyword, string sortColumn, string sortBy, string columnFilter, object filterValue)
        {
            grid.Rows.Clear();

            grid.Columns.Clear();

            List<UsersModel> stuffs = UsersDao.Instance.ListForExcel(keyword, !string.IsNullOrEmpty(sortColumn) ? HelperBll.GetColumnNameInSQLByPropertyName<UsersModel>(sortColumn) : "", sortBy, !string.IsNullOrEmpty(columnFilter) ? HelperBll.GetColumnNameInSQLByPropertyName<UsersModel>(columnFilter) : "", filterValue);

            UsersModel nameOf = new UsersModel();

            grid.Columns.Add(nameof(nameOf.Name), nameof(nameOf.Name));
            grid.Columns.Add(nameof(nameOf.RoleName), nameof(nameOf.RoleName));
            grid.Columns.Add(nameof(nameOf.Sex), nameof(nameOf.Sex));
            grid.Columns.Add(nameof(nameOf.BirthOfDate), nameof(nameOf.BirthOfDate));
            grid.Columns.Add(nameof(nameOf.Email), nameof(nameOf.Email));
            grid.Columns.Add(nameof(nameOf.PhoneNumber), nameof(nameOf.PhoneNumber));
            grid.Columns.Add(nameof(nameOf.Status), nameof(nameOf.Status));
            grid.Columns.Add(nameof(nameOf.CreatedDate), nameof(nameOf.CreatedDate));
            grid.Columns.Add(nameof(nameOf.CreatedBy), nameof(nameOf.CreatedBy));
            grid.Columns.Add(nameof(nameOf.ModifiedDate), nameof(nameOf.ModifiedDate));
            grid.Columns.Add(nameof(nameOf.ModifiedBy), nameof(nameOf.ModifiedBy));

            for (int i = 0; i < stuffs.Count; i++)
            {
                grid.Rows.Add();

                grid[nameof(nameOf.Name), i].Value = stuffs[i].Name;
                grid[nameof(nameOf.RoleName), i].Value = stuffs[i].RoleName;
                grid[nameof(nameOf.Sex), i].Value = stuffs[i].Sex ? "Nam" : "Nữ";
                grid[nameof(nameOf.BirthOfDate), i].Value = stuffs[i].BirthOfDate;
                grid[nameof(nameOf.Email), i].Value = stuffs[i].Email;
                grid[nameof(nameOf.PhoneNumber), i].Value = stuffs[i].PhoneNumber;
                grid[nameof(nameOf.Status), i].Value = stuffs[i].Status ? "Kích hoạt" : "Khóa";
                grid[nameof(nameOf.CreatedDate), i].Value = stuffs[i].CreatedDate;
                grid[nameof(nameOf.CreatedBy), i].Value = stuffs[i].CreatedBy;
                grid[nameof(nameOf.ModifiedDate), i].Value = stuffs[i].ModifiedDate.ToString() == "01-Jan-01 12:00:00 AM" ? "" : stuffs[i].ModifiedDate.ToString();
                grid[nameof(nameOf.ModifiedBy), i].Value = stuffs[i].ModifiedBy;
            }
        }

        // Method ListDataByCoumn
        public Dictionary<string, object> ListDataByCoumn(string column)
        {
            List<string> data = UsersDao.Instance.ListDataByColumn(HelperBll.GetColumnNameInSQLByPropertyName<UsersModel>(column));

            Dictionary<string, object> dics = new Dictionary<string, object>();

            Type t = HelperBll.GetTypeOfProperty<UsersModel>(column);

            if (t != null && t == typeof(Boolean))
            {
                switch(column)
                {
                    case "Sex":
                        foreach(string item in data)
                        {
                            if (item == "True")
                            {
                                dics.Add("Nam", 1);
                            }
                            else if (item == "False")
                            {
                                dics.Add("Nữ", 0);
                            }
                        }
                        break;
                    case "Status":
                        foreach (string item in data)
                        {
                            if (item == "True")
                            {
                                dics.Add("Kích hoạt", 1);
                            }
                            else if (item == "False")
                            {
                                dics.Add("Khóa", 1);
                            }
                        }
                        break;
                }

                return dics;
            }
            else
            {
                foreach (string item in data)
                {
                    dics.Add(item, item);
                }

                return dics;
            }
        }
    }
}
