using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ProductUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<ProductUnitUpdateDTO> Units { get; set; } = new();
        
        [Required]

        public decimal CostPrice { get; set; }

        
        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
      
    }
}
