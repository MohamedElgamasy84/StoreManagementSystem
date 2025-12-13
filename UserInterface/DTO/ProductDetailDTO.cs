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
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<ProductUnitDetailDTO> ProductUnits { get; set; }

        public decimal CostPrice { get; set; }

       
        public IFormFile? Image {  get; set; }
        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
    }
}
