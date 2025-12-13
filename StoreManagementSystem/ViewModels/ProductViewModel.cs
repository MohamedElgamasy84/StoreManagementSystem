using Business.DTO;
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public string? CategoryName { get; set; }
    }
}
