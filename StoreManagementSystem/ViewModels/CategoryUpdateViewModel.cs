using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
