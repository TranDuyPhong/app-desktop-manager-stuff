using DevExpress.XtraEditors;
using ManagerStuffs.Constants;
using ManagerStuffs.Model;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs.Constants
{
    public static class GlobalConstants
    {
        public enum EnumResponse
        {
            LoginSuccess,
            LoginFail,
            BlockUser,
            InsertSuccess,
            InsertFail,
            Unique,
            DeleteSuccess,
            DeleteFail,
            ForeignKey,
            EditSuccess,
            EditFail,
            NotExsist,
            NotMatch,
            NotExsistPath,
            ExportSuccess,
            ExportFail,
            ImportSuccess,
            ImportFail,
            NotMatchTable
        }

        public class ResponseResult
        {
            public EnumResponse TypeResponse { get; set; }

            public object Result { get; set; }
        }

        public static string Username { get; set;}

        public static string RoleName { get; set; }

        public static ConfigModel Config { get; private set; }

        public static ConfigConnectModel ConfigConnect { get; private set; }

        public static List<LogModel> Logs { get; set; } = new List<LogModel>();

        public static string PathFolderConfig { get; set; }
            
        // Method GetConnectString
        public static void GetConnectString()
        {
            string originalPath = Application.StartupPath;

            string fileConfigConnect = originalPath.Substring(0, originalPath.LastIndexOf("bin")) + "Config\\ConfigConnect.json";

            if(!File.Exists(fileConfigConnect))
            {
                XtraMessageBox.Show("Bạn thiếu file ConfigConnect.json, vì vậy việc kết nối đến cơ sở dữ liệu sẽ không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            using(StreamReader reader = new StreamReader(fileConfigConnect))
            {
                string json = reader.ReadToEnd();

                try
                {
                    ConfigConnect = JsonConvert.DeserializeObject<ConfigConnectModel>(json);

                    if(string.IsNullOrEmpty(ConfigConnect.Server) || string.IsNullOrEmpty(ConfigConnect.Database))
                    {
                        XtraMessageBox.Show("File ConfigConnect.json không tồn tại hoặc không có dữ liệu của 2 trường Server và Database !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                    
                    string authenticationDb = (ConfigConnect.User.Trim() == "" && ConfigConnect.Password.Trim() == "") ? "Integrated Security=True" : $"User id={ConfigConnect.User.Trim()};Password={ConfigConnect.Password.Trim()};";

                    ConfigConnect.ConnectString = $"Data Source={ConfigConnect.Server.Trim()};Initial Catalog={ConfigConnect.Database.Trim()};{authenticationDb}";
                }
                catch
                {
                    XtraMessageBox.Show("File ConfigConnect.json không đúng định dạng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader.Close();
                }
            };
        }

        // Method GetConfig
        public static void GetConfig()
        {
            string originalPath = Application.StartupPath;

            PathFolderConfig = originalPath.Substring(0, originalPath.LastIndexOf("bin")) + "Config\\";

            string fileConfigConnect = PathFolderConfig + "Config.json";

            if (!File.Exists(fileConfigConnect))
            {
                XtraMessageBox.Show("Bạn thiếu file Config.json !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            using (StreamReader reader = new StreamReader(fileConfigConnect))
            {
                string json = reader.ReadToEnd();

                try
                {
                    Config = JsonConvert.DeserializeObject<ConfigModel>(json);
                }
                catch
                {
                    XtraMessageBox.Show("File Config.json không đúng định dạng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader.Close();
                }
            };
        }

        // Method ReadLogs
        public static List<LogModel> ReadLogs()
        {
            string originalPath = Application.StartupPath;

            string fileConfigConnect = originalPath.Substring(0, originalPath.LastIndexOf("bin")) + "Logs.txt";

            if (!File.Exists(fileConfigConnect))
            {
                return null;
            }

            using (StreamReader reader = new StreamReader(fileConfigConnect))
            {
                List<LogModel> logs = null;

                try
                {
                    logs = new List<LogModel>();

                    string line = "";

                    int i = 0;

                    while((line = reader.ReadLine()) != null)
                    {
                        logs.Add(new LogModel
                        {
                            Number = ++i,
                            ContentLog = line
                        });
                    }

                    Logs.Clear();

                    Logs.AddRange(logs);

                    return logs;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    reader.Close();
                }
            };
        }

        // Method WriteLog
        public static List<LogModel> WriteLog(string contentLog)
        {
            string originalPath = Application.StartupPath;

            string fileConfig = originalPath.Substring(0, originalPath.LastIndexOf("bin")) + "Logs.txt";

            FileStream stream = null;

            if (!File.Exists(fileConfig))
            {
                stream =  File.Create(fileConfig);
            }

            List<LogModel> logs = null;

            try
            {
                logs = new List<LogModel>();

                if (stream != null)
                {
                    using (StreamWriter writer = new StreamWriter(fileConfig))
                    {
                        try
                        {
                            writer.WriteLine(contentLog);
                        }
                        catch { }
                        finally
                        {
                            writer.Close();
                        }

                        logs.Add(new LogModel
                        {
                            Number = 1,
                            ContentLog = contentLog
                        });
                    }
                }
                else
                {
                    logs = ReadLogs();
                    
                    logs.Add(new LogModel
                    {
                        Number = logs.Count + 1,
                        ContentLog = contentLog
                    });

                    using(StreamWriter writer = new StreamWriter(fileConfig))
                    {
                        try
                        {
                            logs.ForEach(p =>
                            {
                                writer.WriteLine(p.ContentLog);
                            });
                        }
                        catch { }
                        finally
                        {
                            writer.Close();
                        }
                    }
                }

                Logs.Clear();

                Logs.AddRange(logs);

                return logs;
            }
            catch { return null; }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }
        }

        // Method SeachLog
        public static List<LogModel> SearchLog(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            if(string.IsNullOrEmpty(keyword))
            {
                return Logs;
            }

            List<LogModel> logsSearch = (from p in Logs
                                         let ctl = p.ContentLog.Trim().ToLower()
                                         where ctl.Equals(keyword)
                                         || ctl.Contains(keyword)
                                         || ctl.StartsWith(keyword)
                                         || ctl.EndsWith(keyword)
                                         select p).ToList();

            return logsSearch;
        }

        // Method HashObjectToArray
        public static dynamic HashObjectToDic(this object obj)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj.GetType());

            Dictionary<string, string> dics = new Dictionary<string, string>();

            dynamic dys = new ExpandoObject();

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyNameAttribute prop = (PropertyNameAttribute)properties[i].Attributes[typeof(PropertyNameAttribute)];

                if(prop != null)
                {
                    dics.Add(prop.Name, properties[i].GetValue(obj) == null ? null : properties[i].GetValue(obj).ToString());
                }
            }

            return dys = dics;
        }
    }
}
