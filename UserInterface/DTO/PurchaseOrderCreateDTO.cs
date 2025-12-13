using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class PurchaseOrderCreateDTO
    {
        public int SupplierId { get; set; }
        public DateTime PurchaseOrderDate { get; set; } = DateTime.Now;
        public List<PurchaseOrderDetailCreateDTO> Details { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
