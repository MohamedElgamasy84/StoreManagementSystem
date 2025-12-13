using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.ViewModels
{
    public class PurchaseOrderDetailCreateViewModel
    {
        [Required]
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="الكميه يجب ان تكون موجبه")]
        public int Quantity { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage ="السعر يجب ان يكون موجبا")]
        public decimal UnitCost { get; set; }
    }
}
