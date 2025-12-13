using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class InventoryTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityChanged { get; set; }
        public string Type { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Product Product { get; set; }
    }
}
