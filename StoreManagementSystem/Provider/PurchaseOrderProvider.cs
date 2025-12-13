using Business.DTO;
using Business.Interfaces;
using StoreManagementSystem.ViewModels;
using UserInterface.DTO;

namespace StoreManagementSystem.Provider
{
    public class PurchaseOrderProvider
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderProvider(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }
        public async Task<IEnumerable<PurchaseOrderViewModel>> GetAllAsync()
        {
            var dtos = await _purchaseOrderService.GetAllAsync();
            return dtos.Select(d => new PurchaseOrderViewModel
            {
                Id = d.Id,
                PurchaseOrderDate = d.PurchaseOrderDate,
                TotalAmount = d.TotalAmount,
                SupplierFullName = d.SupplierFullName
               
            });
        }
        public async Task<PurchaseOrderViewModel> GetByIdAsync(int id)
        {
            var dtos = await _purchaseOrderService.GetByIdAsync(id);
            if (dtos == null) return null;
            return new PurchaseOrderViewModel
            {
                Id = dtos.Id,
                PurchaseOrderDate = dtos.PurchaseOrderDate,
                TotalAmount = dtos.TotalAmount,
                SupplierFullName = dtos.SupplierFullName,
                Details = dtos.Details.Select(dtos => new PurchaseOrderDetailViewModel
                {
                    ProductName = dtos.ProductName,
                    Quantity = dtos.Quantity,
                    UnitCost = dtos.UnitCost
                }).ToList()

            };
        }
        public async Task AddAsync(PurchaseOrderCreateViewModel vm)
        {
            var dto = new PurchaseOrderCreateDTO
            {
                SupplierId = vm.SupplierId,

                PurchaseOrderDate = vm.PurchaseOrderDate,
                Details = vm.Details.Select(d=> new PurchaseOrderDetailCreateDTO
                {
                    ProductId = d.ProductId,
                    ProductUnitId = d.ProductUnitId,
                    Quantity =  d.Quantity,
                    UnitCost = d.UnitCost
                }).ToList(),
                TotalAmount = vm.TotalAmount
            };
            await _purchaseOrderService.AddAsync(dto);
        }

    }
}
