using Business.DTO;
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class PurchaseOrderCreateViewModel
    {
        [Required]
        public int SupplierId { get; set; }

        [Required]
        public DateTime PurchaseOrderDate { get; set; } = DateTime.Now;

        [MinLength(1,ErrorMessage ="يجب ادخال منتج واحد")]
        public List<PurchaseOrderDetailCreateViewModel> Details { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
