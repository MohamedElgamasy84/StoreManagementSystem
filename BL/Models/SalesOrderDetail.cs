using BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SalesOrderDetail
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int ProductUnitId { get; set; }
        public ProductUnit? ProductUnit { get; set; }
        public Product? Product { get; set; }

        public SalesOrder? SalesOrder { get; set; }
    }
}
