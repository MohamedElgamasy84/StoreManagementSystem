using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "الايميل مطلوب")]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]

        public string Email { get; set; }

        [Required(ErrorMessage = "كلمة السر مطلوبة")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]

        public string Password { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [Display(Name = "الاسم بالكامل")]

        public string FullName { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "الدور مطلوب")]
        [Display(Name = "الدور  ")]

        public string Role { get; set; }

        public List<string>? AvailableRoles { get; set; } 
    }
}
