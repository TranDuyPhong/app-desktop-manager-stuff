using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Querys.Users
{
    public static class UsersQuery
    {
        public static string Login(string username, string password)
        {
            return $"SELECT U.USERNAME, U.NAME, U.STATUS, (SELECT R.NAME FROM dbo.ROLES AS R WHERE R.ID = U.IDROLES) AS 'ROLENAME' FROM USERS AS U WHERE U.USERNAME = '{username}' AND U.PASSWORD = '{password}'";
        }

        public static string DeleteByRoleId(int roleId)
        {
            return $"DELETE FROM USERS WHERE IDROLES = {roleId}";
        }

        public static string GetUsersByRoleName(string roleName, string username)
        {
            return $"SELECT U.ID, U.USERNAME, U.NAME, U.SEX, U.BIRTHOFDATE, U.EMAIL, U.PHONENUMBER, U.STATUS, R.NAME AS 'ROLENAME' FROM dbo.USERS AS U JOIN dbo.ROLES AS R ON R.ID = U.IDROLES WHERE R.NAME = '{roleName}' AND USERNAME != '{username}'";
        }

        public static string Insert(string[] parameters)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "INSERT INTO USERS(";

                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].Contains(":"))
                    {
                        query = query.Insert(query.Length, parameters[i].Substring(1).Split(':')[0]) + ", ";
                    }
                    else
                    {
                        query = query.Insert(query.Length, parameters[i].Substring(1)) + ", ";
                    }
                }

                query = query.Substring(0, query.LastIndexOf(","));

                query = query + ")";

                query = query + " VALUES(";

                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].Contains(":"))
                    {
                        query = query.Insert(query.Length, "NULL") + ", ";
                    }
                    else
                    {
                        query = query.Insert(query.Length, parameters[i]) + ", ";
                    }
                }

                query = query.Substring(0, query.LastIndexOf(","));

                query = query + ")";
            }

            return query;
        }

        public static string CheckExist(string username)
        {
            return $"SELECT COUNT(*) FROM USERS WHERE USERNAME = '{username}'";
        }
        
        public static string Delete(int id)
        {
            return $"DELETE FROM USERS WHERE ID = {id}";
        }

        public static string CheckExistWithoutById(string username, int id)
        {
            return $"SELECT COUNT(*) FROM USERS WHERE USERNAME = '{username}' AND ID != {id}";
        }

        public static string Edit(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "UPDATE USERS SET ";

                for (int i = 0; i < parameters.Length; i++)
                {
                    query = query.Insert(query.Length, parameters[i].Substring(1)) + " = ";
                    query = query.Insert(query.Length, parameters[i]) + ", ";
                }

                query = query.Substring(0, query.LastIndexOf(","));

                query = query + $" WHERE ID = {id}";
            }

            return query;
        }

        public static string GetUserIdByUsername(string username)
        {
            return $"SELECT ID FROM USERS WHERE USERNAME = '{username}'";
        }

        public static string CheckPassword(string username, string password)
        {
            return $"SELECT COUNT(*) FROM USERS WHERE USERNAME = '{username}' AND PASSWORD = '{password}'";
        }

        public static string ChangePassword(int id, string password)
        {
            return $"UPDATE USERS SET PASSWORD = '{password}' WHERE ID = {id}";
        }

        public static string ChangeProfile(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "UPDATE USERS SET ";

                for (int i = 0; i < parameters.Length; i++)
                {
                    query = query.Insert(query.Length, parameters[i].Substring(1)) + " = ";
                    query = query.Insert(query.Length, parameters[i]) + ", ";
                }

                query = query.Substring(0, query.LastIndexOf(","));

                query = query + $" WHERE ID = {id}";
            }

            return query;
        }

        public static string ListForExcel(string keyword, string sortColumn, string sortBy, string columnFilter, object filerValue)
        {
            string where = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                where = $"WHERE U.NAME LIKE N'%{keyword}%'";
            }

            string sort = "";

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortBy))
            {
                sort = $"ORDER BY {sortColumn} {sortBy}";
            }

            string filter = "";

            if(filerValue != null && !string.IsNullOrEmpty(columnFilter))
            {
                if(!string.IsNullOrEmpty(keyword))
                {
                    filter = "AND ";
                }
                else
                {
                    filter = "WHERE ";
                }

                switch(columnFilter)
                {
                    case "ROLENAME":
                        filter += $"R.NAME = N'{filerValue}'";
                        break;
                    default:
                        filter += $"U.{columnFilter} = N'{filerValue}'";
                        break;
                }
            }

            return $"SELECT U.USERNAME, U.NAME, U.SEX, U.BIRTHOFDATE, U.EMAIL, U.PHONENUMBER, U.STATUS, U.CREATEDDATE, U.CREATEBY, U.MODIFIEDDATE, U.MODIFIEDBY, R.NAME AS 'ROLENAME' FROM dbo.USERS AS U JOIN dbo.ROLES AS R ON R.ID = U.IDROLES {where} {filter} {sort}";
        }

        public static string ListDataByColumn(string column)
        {
            string col = "";

            switch (column)
            {
                case "ROLENAME":
                    col = "R.NAME";

                    column = "ROLENAME";
                    break;
                default:
                    col = $"U.{column}";
                    break;
            }

            return $"SELECT {col} AS '{column}' FROM dbo.USERS AS U JOIN dbo.ROLES AS R ON R.ID = U.IDROLES GROUP BY {col}";
        }
    }
}
