using Business.DTO;
using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }
        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
