using UserInterface.DTO;

namespace StoreManagementSystem.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public int Id { get; set; }
        public DateTime PurchaseOrderDate { get; set; } = DateTime.Now;
        public string SupplierFullName { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderDetailViewModel> Details { get; set; }
    }
}
