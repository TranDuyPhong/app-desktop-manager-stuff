using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants.Languages
{
    public class LanguageModel
    {
        public string Name { get; set; }

        public string StandFor { get; set; }

        public bool Chosen { get; set; }

        public override string ToString()
        {
            return StandFor;
        }
    }
}
