using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.DTO
{
    public class SalesOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public List<SalesOrderDetailDTO> Details { get; set; }
    }
}
