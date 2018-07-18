using ManagerStuffs.Model;
using ManagerStuffs.Model.RolesModel;
using ManagerStuffs.Querys.RolesQuerys;
using ManagerStuffs.Querys.Stuffs;
using ManagerStuffs.Querys.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao.RolesDao
{
    public class RolesDao
    {
        private static volatile RolesDao instance;

        private static object key = new object();

        public static RolesDao Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new RolesDao();
                    }

                    return instance;
                }
            }
        }

        private RolesDao() { }

        // Method Insert
        public int Insert(RolesModel role)
        {
            return DataProvider.Instance.Execute(RolesQuerys.Insert(role.Name));
        }

        // Method CheckForeignKey
        public int CheckForeignKey(RolesModel role)
        {
            return DataProvider.Instance.Count(RolesQuerys.CheckForeignKey(role.Name));
        }

        // Method Delete
        public int Delete(RolesModel role)
        {
            int execute = 0;

            DataTable dt = DataProvider.Instance.Query(RolesQuerys.GetRoleIdByName(role.Name));

            if(dt != null)
            {
                int roleId = Convert.ToInt32(dt.Rows[0]["ID"].ToString());

                execute = DataProvider.Instance.Execute(UsersQuery.DeleteByRoleId(roleId));

                execute += DataProvider.Instance.Execute(RolesQuerys.Delete(roleId));
            }

            return execute;
        }

        // Method GetRoleIdByRoleName
        public int GetRoleIdByName(string roleName)
        {
            DataTable dt = DataProvider.Instance.Query(RolesQuerys.GetRoleIdByName(roleName));

            return dt == null ? 0 : Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
    }
}
