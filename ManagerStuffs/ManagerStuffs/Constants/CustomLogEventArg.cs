using ManagerStuffs.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants
{
    public class CustomLogEventArg : EventArgs
    {
        private List<LogModel> logs = new List<LogModel>();

        public List<LogModel> Logs
        {
            get
            {
                return logs;
            }
            set
            {
                logs = value;
            }
        }

        public CustomLogEventArg(string log)
        {
            List<LogModel> returnLogs = GlobalConstants.WriteLog(log);

            logs.Clear();

            logs.AddRange(returnLogs);
        }
    }
}
