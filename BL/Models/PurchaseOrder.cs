using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime PurchaseOrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
