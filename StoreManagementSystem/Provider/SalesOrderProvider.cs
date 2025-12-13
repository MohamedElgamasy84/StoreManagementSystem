using Business.DTO;
using Business.Interfaces;
using StoreManagementSystem.ViewModels;
using UserInterface.DTO;

namespace StoreManagementSystem.Provider
{
    public class SalesOrderProvider
    {
        private readonly ISalesOrderService _salesOrderService;

        public SalesOrderProvider(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }
        public async Task<IEnumerable<SalesOrderViewModel>> GetAllAsync()
        {
            var dtos = await _salesOrderService.GetAllAsync();
            return dtos.Select(s => new SalesOrderViewModel
            {
                Id = s.Id,
                OrderDate = s.OrderDate,
                TotalAmount = s.TotalAmount,
                CustomerFullName = s.CustomerFullName

            });
        }
        public async Task<SalesOrderViewModel> GetByIdAsync(int id)
        {
            var dtos = await _salesOrderService.GetByIdAsync(id);
            if (dtos == null) return null;
            return new SalesOrderViewModel
            {
                Id = dtos.Id,
                OrderDate = dtos.OrderDate,
                TotalAmount = dtos.TotalAmount,
                CustomerFullName = dtos.CustomerFullName,
                Details = dtos.Details.Select(detail => new SalesOrderDetailViewModel
                {
                    ProductName = detail.ProductName,
                    Quantity = detail.Quantity,
                    UnitPrice = detail.UnitPrice,
                    Discount = detail.Discount
                }).ToList()
            };  
        }
        public async Task AddAync (SalesOrderCreateViewModel vm)
        {
            var dtos = new SalesOrderCreateDTO
            {
                CustomerId = vm.CustomerId,
                OrderDate = vm.OrderDate,
                
                Details = vm.Details.Select(s => new SalesOrderDetailCreateDTO
                {
                    ProductId = s.ProductId,
                    ProductUnitId = s.ProductUnitId,
                    Quantity = s.Quantity,
                    Discount = s.Discount
                }).ToList(),
                TotalAmount = vm.TotalAmount
            };
            await _salesOrderService.AddAsync(dtos);
        }
       

    }
}
