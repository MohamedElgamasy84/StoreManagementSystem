using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.DTO
{
    public class PurchaseOrderDTO
    {
        public int Id { get; set; }
        public DateTime PurchaseOrderDate { get; set; } = DateTime.Now;
        public int SupplierId { get; set; }
        public string SupplierFullName { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderDetailDTO> Details { get; set; }
    }
}
