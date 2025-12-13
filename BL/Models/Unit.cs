using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductUnit> ProductUnits { get; set; } = new List<ProductUnit>();

    }
}
