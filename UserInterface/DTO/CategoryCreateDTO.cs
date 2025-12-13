using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class CategoryCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }
}
