using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class SupplierCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
