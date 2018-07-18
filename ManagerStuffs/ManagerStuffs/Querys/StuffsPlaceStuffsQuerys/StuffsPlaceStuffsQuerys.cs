using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Querys.StuffsPlaceStuffsQuerys
{
    public static class StuffsPlaceStuffsQuerys
    {
        public static string Insert(int idPlaceStuff, int idStuff)
        {
            return $"INSERT INTO STUFFSPLACESTUFFS(IDSTUFFS, IDPLACESTUFFS) VALUES({idStuff}, {idPlaceStuff})";
        }

        public static string Delete(int idPlaceStuff, int idStuff)
        {
            return $"DELETE FROM STUFFSPLACESTUFFS WHERE IDSTUFFS = {idStuff} AND IDPLACESTUFFS = {idPlaceStuff}";
        }
    }
}
