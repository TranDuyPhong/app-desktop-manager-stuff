using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Querys.Stuffs
{
    public static class StuffsQuerys
    {
        public static string ListPaging(int pageSizes, int pages = 1)
        {
            return $"SELECT TOP {pageSizes} S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, C.NAME AS CATEGORY, (SELECT P.NAME FROM dbo.STUFFSPLACESTUFFS AS SP, dbo.PLACESTUFFS AS P WHERE SP.IDSTUFFS = S.ID AND P.ID = SP.IDPLACESTUFFS) AS PLACESTUFF FROM dbo.STUFFS AS S JOIN dbo.CATEGORIES AS C ON C.ID = S.IDCATEGORIES WHERE S.ID NOT IN (SELECT TOP {(pages - 1) * pageSizes} ID FROM dbo.STUFFS)";
        }   

        public static string List(bool? status = null)
        {
            string convertBool = "";

            if (status != null)
            {
                if (status == true)
                {
                    convertBool = "WHERE S.STATUS = 1";
                }
                else
                {
                    convertBool = "WHERE S.STATUS = 0";
                }
            }

            return $"SELECT S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, S.IDCATEGORIES, C.NAME AS CATEGORY, (SELECT P.NAME FROM dbo.STUFFSPLACESTUFFS AS SP, dbo.PLACESTUFFS AS P WHERE SP.IDSTUFFS = S.ID AND P.ID = SP.IDPLACESTUFFS) AS PLACESTUFF FROM dbo.STUFFS AS S JOIN dbo.CATEGORIES AS C ON C.ID = S.IDCATEGORIES {convertBool}";
        }

        public static string Insert(string[] parameters)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "INSERT INTO STUFFS (";

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

        public static string Delete(int id)
        {
            return $"DELETE FROM STUFFS WHERE ID = {id}";
        }

        public static string Edit(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "UPDATE STUFFS SET ";

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

        public static string CheckExsist(string[] parameters, int id)
        {
            string query = "";

            if (parameters != null && parameters.Length > 0)
            {
                query = "SELECT COUNT(*) FROM STUFFS WHERE ";

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

        public static string DeleteStuffsPlaceStuffs(int id)
        {
            return $"DELETE FROM STUFFSPLACESTUFFS WHERE IDSTUFFS = {id}";
        }

        public static string ListForExcel(string keyword, string sortColumn, string sortBy, string columnFilter,  object filterValue)
        {
            string where = "";

            if(!string.IsNullOrEmpty(keyword))
            {
                where = $"WHERE S.NAME LIKE N'%{keyword}%'";
            }

            string sort = "";

            if(!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortBy))
            {
                sort = $"ORDER BY S.{sortColumn} {sortBy}";

                switch (sortColumn)
                {
                    case "CATEGORY":
                        sort = $"ORDER BY C.NAME {sortBy}";
                        break;
                    case "PLACESTUFF":
                        sort = $"ORDER BY P.name {sortBy}";
                        break;
                }
            }

            string filter = "";

            if(filterValue != null && !string.IsNullOrEmpty(columnFilter))
            {
                if(!string.IsNullOrEmpty(keyword))
                {
                    filter = "AND ";
                }
                else
                {
                    filter = "WHERE ";
                }

                switch (columnFilter)
                {
                    case "CATEGORY":
                        filter = filter + $"C.NAME = N'{filterValue}'";
                        break;
                    case "PLACESTUFF":
                        filter = filter + $"P.NAME = N'{filterValue}'";
                        break;
                    default:
                        filter = filter + $"S.{columnFilter} = N'{filterValue}'";
                        break;
                }
            }

            return $"SELECT S.BQCODE, S.NAME, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, C.NAME AS 'CATEGORY', P.NAME AS 'PLACESTUFF' FROM dbo.STUFFS AS S JOIN dbo.CATEGORIES AS C ON C.ID = S.IDCATEGORIES JOIN dbo.STUFFSPLACESTUFFS AS SP ON SP.IDSTUFFS = S.ID JOIN dbo.PLACESTUFFS AS P ON P.ID = SP.IDPLACESTUFFS {where} {filter} {sort}";
        }

        public static string ListDataByColumn(string column)
        {
            string col = $"S.{column}";

            switch(column)
            {
                case "CATEGORY":
                    col = "C.NAME";

                    column = "CATEGORY";
                    break;
                case "PLACESTUFF":
                    col = "P.NAME";

                    column = "PLACESTUFF";
                    break;
            }

            return $"SELECT {col} AS '{column}' FROM dbo.STUFFS AS S JOIN dbo.CATEGORIES AS C ON C.ID = S.IDCATEGORIES JOIN dbo.STUFFSPLACESTUFFS AS SP ON SP.IDSTUFFS = S.ID JOIN dbo.PLACESTUFFS AS P ON P.ID = SP.IDPLACESTUFFS WHERE S.COLORSTUFFS IS NOT NULL GROUP BY {col}";
        }

        public static string ListStuffsNotHavePlace()
        {
            return $"SELECT S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, C.NAME AS CATEGORY FROM dbo.STUFFS AS S JOIN dbo.CATEGORIES AS C ON C.ID = S.IDCATEGORIES WHERE S.ID NOT IN (SELECT SP.IDSTUFFS FROM dbo.STUFFSPLACESTUFFS AS SP)";
        }

        public static string ListStuffsByPlaceStuff(int idPlaceStuff)
        {
            return $"SELECT S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, P.NAME AS PLACESTUFF, C.NAME AS CATEGORY FROM dbo.STUFFS AS S JOIN dbo.STUFFSPLACESTUFFS AS SP ON SP.IDSTUFFS = S.ID JOIN dbo.PLACESTUFFS AS P ON SP.IDPLACESTUFFS = P.ID JOIN dbo.CATEGORIES AS C ON C.ID = S.IDCATEGORIES WHERE P.ID = {idPlaceStuff}";
        }
    }
}
