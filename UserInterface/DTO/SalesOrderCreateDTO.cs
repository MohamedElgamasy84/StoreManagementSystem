using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class SalesOrderCreateDTO
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<SalesOrderDetailCreateDTO> Details { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
