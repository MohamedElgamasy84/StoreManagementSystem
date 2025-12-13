using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class PurchaseOrderDetailCreateDTO
    {
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}
