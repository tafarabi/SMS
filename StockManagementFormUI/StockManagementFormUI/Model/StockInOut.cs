using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementFormUI.Model
{
    class StockInOut
    {
        public int ItemId { get; set; }
        
        public int Quantity { get; set; }
        
        public int StockId { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }
    }
}
