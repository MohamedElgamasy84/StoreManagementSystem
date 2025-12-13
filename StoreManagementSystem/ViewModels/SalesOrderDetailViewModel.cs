namespace StoreManagementSystem.ViewModels
{
    public class SalesOrderDetailViewModel
    {
        public int ProductId { get; set; }
        public int SalesOrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        
    }
}
