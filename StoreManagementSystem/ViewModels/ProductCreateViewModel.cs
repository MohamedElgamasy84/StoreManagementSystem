using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }
        public int UnitId { get; set; }

        public List<ProductUnitCreateViewModel> Units { get; set; } = new List<ProductUnitCreateViewModel>();
        
        [Range(0.0, double.MaxValue, ErrorMessage = "السعر يجب ان يكون موجبا")]
        public decimal CostPrice { get; set; }
        
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        [Required(ErrorMessage = "التصنيف مطلوب")]
        
        public int CategoryId { get; set; }
    }
}
