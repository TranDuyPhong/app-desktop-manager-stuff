using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Querys.RolesQuerys
{
    public static class RolesQuerys
    {
        public static string Insert(string name)
        {
            return $"INSERT INTO ROLES(NAME) VALUES('{name}')";
        }

        public static string CheckForeignKey(string name)
        {
            return $"SELECT COUNT(*) FROM dbo.USERS AS U JOIN dbo.ROLES AS R ON R.ID = U.IDROLES WHERE R.NAME = '{name}'";
        }

        public static string GetRoleIdByName(string name)
        {
            return $"SELECT ID FROM ROLES WHERE NAME = '{name}'";
        }

        public static string Delete(int roleId)
        {
            return $"DELETE FROM ROLES WHERE ID = {roleId}";
        }
    }
}
