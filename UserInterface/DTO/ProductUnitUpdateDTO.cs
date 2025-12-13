using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ProductUnitUpdateDTO
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal Factor { get; set; }
        public decimal SalePrice { get; set; }
    }
}
