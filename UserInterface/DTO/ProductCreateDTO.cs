using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public int UnitId { get; set; }
        public List<ProductUnitCreateDTO> ProductUnits { get; set; } = new List<ProductUnitCreateDTO>();


        public decimal CostPrice { get; set; }

       
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        [Required]
        public int CategoryId { get; set; }
       
    }
}
