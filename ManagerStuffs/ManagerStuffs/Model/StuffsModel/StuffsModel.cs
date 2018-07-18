using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Model
{
    public class StuffsModel : InheritModel
    {
        [PropertyName(Name = "ID")]
        public int Id { get; set; }

        [PropertyName(Name = "BQCODE")]
        public string BQCode { get; set; }

        [PropertyName(Name = "NAME")]
        public string Name { get; set; }

        [PropertyName(Name = "CATEGORY")]
        public string Category { get; set; }

        [PropertyName(Name = "PLACESTUFF")]
        public string PlaceStuff { get; set; } 

        [PropertyName(Name = "PRODUCER")]
        public string Producer { get; set; }

        [PropertyName(Name = "DATEBUY")]
        public DateTime DateBuy { get; set; }

        [PropertyName(Name = "DATEUSE")]
        public DateTime DateUse { get; set; }

        [PropertyName(Name = "YEARRELEASE")]
        public DateTime YearRelease { get; set; }

        [PropertyName(Name = "COLORSTUFFS")]
        public string ColorStuffs { get; set; }

        [PropertyName(Name = "STATE")]
        public string State { get; set; }

        [PropertyName(Name = "PRICEBUY")]
        public decimal PriceBuy { get; set; }

        [PropertyName(Name = "WARRANTY")]
        public string Warranty { get; set; }

        [PropertyName(Name = "PARENTID")]
        public int ParentId { get; set; }

        [PropertyName(Name = "STATUS")]
        public bool Status { get; set; }

        [PropertyName(Name = "CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [PropertyName(Name = "CREATEBY")]
        public string CreatedBy { get; set; }

        [PropertyName(Name = "MODIFIEDDATE")]
        public DateTime ModifiedDate { get; set; }

        [PropertyName(Name = "MODIFIEDBY")]
        public string ModifiedBy { get; set; }

        [PropertyName(Name = "IDCATEGORIES")]
        public int IdCategories { get; set; }
    }
}
