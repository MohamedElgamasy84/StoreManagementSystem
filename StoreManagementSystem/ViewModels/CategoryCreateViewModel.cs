using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class CategoryCreateViewModel
    {

        [Required]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
