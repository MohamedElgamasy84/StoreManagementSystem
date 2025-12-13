using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal CostPrice { get; set; }

        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
        public ICollection<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
        public ICollection<ProductUnit>? ProductUnits { get; set; } = new List<ProductUnit>();

    }
}
