using Business.DTO;

namespace StoreManagementSystem.ViewModels
{
    public class SalesOrderCreateViewModel
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<SalesOrderDetailCreateViewModel> Details { get; set; } 
        public decimal TotalAmount { get; set; }
    }
}
