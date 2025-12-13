using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.DTO
{
    public class SalesOrderDetailDTO
    {
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }
        public int SalesOrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
    }
}
