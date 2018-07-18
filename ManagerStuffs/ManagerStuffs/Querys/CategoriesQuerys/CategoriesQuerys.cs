using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Querys.CategoriesQuerys
{
    public static class CategoriesQuerys
    {
        public static string List(bool? status = null)
        {
            string convertBool = "";

            if(status != null)
            {
                if(status == true)
                {
                    convertBool = "WHERE C.STATUS = 1";
                }
                else
                {
                    convertBool = "WHERE C.STATUS = 0";
                }
            }

            return $"SELECT C.ID, C.NAME, C.STATUS, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY, (SELECT COUNT(*) FROM dbo.STUFFS AS S WHERE S.IDCATEGORIES = C.ID) AS COUNTSTUFFS FROM dbo.CATEGORIES AS C {convertBool}";
        }

        public static string Insert(string[] parameters)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "INSERT INTO CATEGORIES ("; 

                for (int i = 0; i < parameters.Length; i++)
                {
                    if(parameters[i].Contains(":"))
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
                    if(parameters[i].Contains(":"))
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

        public static string CheckExsist(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "SELECT COUNT(*) FROM CATEGORIES WHERE ";

                for (int i = 0; i < parameters.Length; i++)
                {
                    query = query.Insert(query.Length, parameters[i].Substring(1)) + " =  ";
                    query = query.Insert(query.Length, parameters[i]) + ", ";
                }

                query = query.Substring(0, query.LastIndexOf(","));

                query = query + $" AND ID != {id}";
            }

            return query;
        }

        public static string Delete(string[] parameters)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "DELETE FROM CATEGORIES WHERE ";

                for (int i = 0; i < parameters.Length; i++)
                {
                    query = query.Insert(query.Length, parameters[i].Substring(1)) + " =  ";
                    query = query.Insert(query.Length, parameters[i]) + ", ";
                }

                query = query.Substring(0, query.LastIndexOf(","));
            }

            return query;
        }

        public static string CheckForeignKey(int id)
        {
            return $"SELECT COUNT(*) FROM STUFFS WHERE IDCATEGORIES = {id}";
        }

        public static string Edit(string[] parameters, int id)
        {
            string query = "";

            if(parameters != null && parameters.Length > 0)
            {
                query = "UPDATE CATEGORIES SET ";

                for(int i = 0; i < parameters.Length; i++)
                {
                    query = query.Insert(query.Length, parameters[i].Substring(1)) + " = ";
                    query = query.Insert(query.Length, parameters[i]) + ", ";
                }

                query = query.Substring(0, query.LastIndexOf(","));

                query = query + $" WHERE ID = {id}";
            }

            return query;
        }

        public static string ListForExcel(string keyword, string sortColumn, string sortBy)
        {
            string where = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                where = $"HAVING C.NAME LIKE N'%{keyword}%'";
            }

            string sort = "";

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortBy))
            {
                sort = $"ORDER BY {sortColumn} {sortBy}";
            }

            return $"SELECT C.NAME, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY, COUNT(*) AS 'COUNTSTUFFS' FROM dbo.CATEGORIES AS C, dbo.STUFFS AS S WHERE S.IDCATEGORIES = C.ID GROUP BY C.NAME, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY {where} {sort}";
        }
    }
}
