using ManagerStuffs.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants
{
    public class LogEvent
    {
        private static string log;

        public static string Log
        {
            get
            {
                return log;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    log = value;

                    EventHandler<CustomLogEventArg> temp = (EventHandler<CustomLogEventArg>)events["AddLog"];

                    if (temp != null)
                    {
                        temp(log, new CustomLogEventArg(log));
                    }
                }
            }
        }

        private static EventHandlerList events = new EventHandlerList();

        public static event EventHandler<CustomLogEventArg> AddLog
        {
            add
            {
                events.AddHandler("AddLog", value);
            }
            remove
            {
                events.RemoveHandler("AddLog", value);
            }
        }
    }
}
