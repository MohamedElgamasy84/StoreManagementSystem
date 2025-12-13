using UserInterface.DTO;

namespace StoreManagementSystem.ViewModels
{
    public class SalesOrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string CustomerFullName { get; set; }
        public List<SalesOrderDetailViewModel> Details { get; set; }
    }
}
