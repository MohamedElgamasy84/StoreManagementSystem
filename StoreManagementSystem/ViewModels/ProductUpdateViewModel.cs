using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class ProductUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }

        public List<ProductUnitUpdateViewModel> Units { get; set; } = new();

        [Range(0.0, double.MaxValue, ErrorMessage = "السعر يجب ان يكون موجبا")]

        public decimal CostPrice { get; set; }

        public string? ImageName { get; set; }
        public int CategoryId { get; set; }

    } 
}
