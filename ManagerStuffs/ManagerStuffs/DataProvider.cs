using DevExpress.XtraEditors;
using ManagerStuffs.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs
{
    public class DataProvider
    {
        private static volatile DataProvider instance;

        private static object key = new object();

        public static DataProvider Instance
        {
            get
            {
                lock(key)
                {
                    if (instance == null)
                    {
                        instance = new DataProvider();
                    }

                    return instance;
                }
            } 
        }

        private DataProvider() { }

        // Method Query Database
        public DataTable Query(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = null;

            using (SqlConnection con = new SqlConnection(GlobalConstants.ConfigConnect.ConnectString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = query;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> para in parameters)
                    {
                        cmd.Parameters.AddWithValue(para.Key, para.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                dt = new DataTable();

                adapter.Fill(dt);

                con.Close();

                return dt;
            }   
        }

        // Method Execute Database
        public int Execute(string query, Dictionary<string, object> parameters = null)
        {
            int execute = 0;

            using (SqlConnection con = new SqlConnection(GlobalConstants.ConfigConnect.ConnectString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = query;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> para in parameters)
                    {
                        cmd.Parameters.AddWithValue(para.Key, para.Value);
                    }
                }

                execute = cmd.ExecuteNonQuery();

                con.Close();

                return execute;
            }
        }

        // Method Count Database
        public int Count(string query, Dictionary<string, object> parameters = null)
        {
            int count = 0;

            using (SqlConnection con = new SqlConnection(GlobalConstants.ConfigConnect.ConnectString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = query;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> para in parameters)
                    {
                        cmd.Parameters.AddWithValue(para.Key, para.Value);
                    }
                }

                count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return count;
            }
        }

        // Method GetLastId Database
        public object GetLastId(string table)
        {
            object id = null;

            using (SqlConnection con = new SqlConnection(GlobalConstants.ConfigConnect.ConnectString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = $"EXEC dbo.SP_GETLASTID @TABLE = '{table}'";

                id = cmd.ExecuteNonQuery();

                con.Close();

                return id;
            }
        }
    }
}
