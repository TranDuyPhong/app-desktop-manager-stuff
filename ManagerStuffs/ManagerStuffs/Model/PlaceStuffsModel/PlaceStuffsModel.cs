using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Model.PlaceStuffsModel
{
    public class PlaceStuffsModel
    {
        [PropertyName(Name = "ID")]
        public int Id { get; set; }

        [PropertyName(Name = "NAME")]
        public string Name { get; set; }

        [PropertyName(Name = "COUNTSTUFFS")]
        public int CountStuffs { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
