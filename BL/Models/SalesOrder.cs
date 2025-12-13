using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        //public decimal Discount { get; set; }

        //public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }
    }
}
