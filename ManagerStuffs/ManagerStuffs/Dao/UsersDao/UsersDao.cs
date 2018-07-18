using ManagerStuffs.Model.Users;
using ManagerStuffs.Querys.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao.Users
{
    public class UsersDao
    {
        private static volatile UsersDao instance;

        private static object key = new object();

        public static UsersDao Instance
        {
            get
            {
                lock(key)
                {
                    if (instance == null)
                    {
                        instance = new UsersDao();
                    }

                    return instance;
                }
            }
        }

        private UsersDao() { } 

        // Method Login
        public UsersModel Login(string username, string password)
        {
            DataTable dt = DataProvider.Instance.Query(UsersQuery.Login(username, password));

            List<UsersModel> users = HelperDao.GenerateList<UsersModel>(dt);

            return users.FirstOrDefault();
        }

        // Method GetUserByRoleName
        public List<UsersModel> GetUsersByRoleName(string roleName, string username)
        {
            DataTable dt = DataProvider.Instance.Query(UsersQuery.GetUsersByRoleName(roleName, username));

            return HelperDao.GenerateList<UsersModel>(dt);
        }

        // Method Insert
        public int Insert(UsersModel user, string[] parameters)
        {
            Dictionary<string, object> dicParas = HelperDao.GenerateParameter<UsersModel>(user, parameters);

            return DataProvider.Instance.Execute(UsersQuery.Insert(parameters), dicParas);
        }

        // Method CheckExist
        public int CheckExist(string username)
        {
            return DataProvider.Instance.Count(UsersQuery.CheckExist(username));
        }

        // Method CheckExist
        public int CheckExistWithoutById(string username, int id)
        {
            return DataProvider.Instance.Count(UsersQuery.CheckExistWithoutById(username, id));
        }

        // Method Delete
        public int Delete(int id)
        {
            return DataProvider.Instance.Execute(UsersQuery.Delete(id));
        }

        // Method Edit
        public int Edit(UsersModel user, string[] parameters)
        {
            Dictionary<string, object> dicParas = HelperDao.GenerateParameter<UsersModel>(user, parameters);

            return DataProvider.Instance.Execute(UsersQuery.Edit(parameters, user.Id), dicParas);
        }

        // Method GetUserIdByUsername
        public int GetUserIdByUsername(string username)
        {
            DataTable dt = DataProvider.Instance.Query(UsersQuery.GetUserIdByUsername(username));

            return dt == null ? 0 : Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }

        // Method CheckPassword
        public int CheckPassword(string username, string password)
        {
            return DataProvider.Instance.Count(UsersQuery.CheckPassword(username, password));
        }
        
        // Method ChangePassword
        public int ChangePassword(int id, string password)
        {
            return DataProvider.Instance.Execute(UsersQuery.ChangePassword(id, password));
        }

        // Method ChangeProfile
        public int ChangeProfile(UsersModel user, string[] parameters)
        {
            Dictionary<string, object> dicParas = HelperDao.GenerateParameter<UsersModel>(user, parameters);

            return DataProvider.Instance.Execute(UsersQuery.ChangeProfile(parameters, user.Id), dicParas);
        }

        // Method ListForExcel
        public List<UsersModel> ListForExcel(string keyword, string sortColumn, string sortBy, string columnFilter, object filterValue)
        {
            DataTable dt = DataProvider.Instance.Query(UsersQuery.ListForExcel(keyword, sortColumn, sortBy, columnFilter, filterValue));

            return HelperDao.GenerateList<UsersModel>(dt);
        }

        // Method ListDataByColumn
        public List<string> ListDataByColumn(string column)
        {
            DataTable dt = DataProvider.Instance.Query(UsersQuery.ListDataByColumn(column));

            List<string> data = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                data.Add(row[column].ToString());
            }

            return data;
        }
    }
}
