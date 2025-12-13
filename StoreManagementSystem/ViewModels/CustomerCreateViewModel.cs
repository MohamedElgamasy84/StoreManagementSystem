using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class CustomerCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
