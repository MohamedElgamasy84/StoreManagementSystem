namespace StoreManagementSystem.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<ProductUnitDetailViewModel> Units { get; set; } = new();


        public decimal CostPrice { get; set; }

        
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
