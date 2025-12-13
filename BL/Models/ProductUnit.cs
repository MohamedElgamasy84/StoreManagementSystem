using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductUnit
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int UnitId { get; set; }
        public decimal Factor { get; set; }
        public decimal SalePrice { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
        public Unit Unit { get; set; }

        public Product Product { get; set; }
    }
}
