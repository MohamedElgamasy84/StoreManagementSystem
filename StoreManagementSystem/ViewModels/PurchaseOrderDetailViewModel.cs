namespace StoreManagementSystem.ViewModels
{
    public class PurchaseOrderDetailViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}
