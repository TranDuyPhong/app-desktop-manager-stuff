using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Model.CategoriesModel
{
    public class CategoriesModel
    {
        [PropertyName(Name = "ID")]
        public int Id { get; set; }

        [PropertyName(Name = "NAME")]
        public string Name { get; set; }

        [PropertyName(Name = "STATUS")]
        public bool Status { get; set; }

        [PropertyName(Name = "CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [PropertyName(Name = "CREATEBY")]
        public string CreatedBy { get; set; }

        [PropertyName(Name = "MODIFIEDDATE")]
        public DateTime? ModifiedDate { get; set; }

        [PropertyName(Name = "MODIFIEDBY")]
        public string ModifiedBy { get; set; }

        [PropertyName(Name = "COUNTSTUFFS")]
        public int CountStuffs { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
