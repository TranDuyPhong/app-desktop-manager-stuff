using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Querys.PlaceStuffsQuerys
{
    public class PlaceStuffsQuerys
    {
        public static string List()
        {
            return "SELECT PS.ID, PS.NAME, (SELECT COUNT(*) FROM dbo.STUFFSPLACESTUFFS AS S WHERE S.IDPLACESTUFFS = PS.ID) AS COUNTSTUFFS FROM dbo.PLACESTUFFS AS PS";
        }

        public static string CheckExsist(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "SELECT COUNT(*) FROM PLACESTUFFS WHERE ";

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

        public static string Insert(string[] parameters)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "INSERT INTO PLACESTUFFS (";

                for (int i = 0; i < parameters.Length; i++)
                {
                    query = query.Insert(query.Length, parameters[i].Substring(1)) + ", ";
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

        public static string Edit(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "UPDATE PLACESTUFFS SET ";

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

        public static string Delete(string[] parameters)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "DELETE FROM PLACESTUFFS WHERE ";

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
            return $"SELECT COUNT(*) FROM STUFFSPLACESTUFFS WHERE IDPLACESTUFFS = {id}";
        }

        public static String ListForExcel(string keyword, string sortColumn, string sortBy)
        {
            string where = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                where = $"HAVING P.NAME LIKE N'%{keyword}%'";
            }

            string sort = "";

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortBy))
            {
                sort = $"ORDER BY {sortColumn} {sortBy}";
            }

            return $"SELECT P.NAME, COUNT(*) AS 'COUNTSTUFFS' FROM dbo.PLACESTUFFS AS P, dbo.STUFFSPLACESTUFFS AS SP WHERE P.ID = SP.IDPLACESTUFFS GROUP BY P.NAME {where} {sort}";
        }
    }
}
