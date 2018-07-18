using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Model
{
    public class StuffsModelCustomUI
    {
        public int Id { get; set; }

        public string BQCode { get; set; }

        public string Producer { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string Category { get; set; }

        public string PlaceStuff { get; set; }

        public DateTime Release { get; set; }

        public DateTime DateBuy { get; set; }

        public DateTime DateUse { get; set; }

        public string ColorStuffs { get; set; }

        public string PriceBuy { get; set; }

        public string Warranty { get; set; }
    }
}
