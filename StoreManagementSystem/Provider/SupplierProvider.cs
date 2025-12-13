using Business.DTO;
using Business.Interfaces;
using StoreManagementSystem.ViewModels;
using UserInterface.DTO;

namespace StoreManagementSystem.Provider
{
    public class SupplierProvider
    {
        private readonly ISupplierService _supplierService;

        public SupplierProvider(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public async Task<List<SupplierViewModel>> GetAllAsync()
        {
            var dtos = await _supplierService.GetAllAsync();
            return dtos.Select(dtos=> new SupplierViewModel
            {
                Id = dtos.Id,
                FullName = dtos.FullName,
                PhoneNumber = dtos.PhoneNumber,
                Email = dtos.Email
            }).ToList();
        }
        public async Task<SupplierViewModel?> GetByIdAsync(int id)
        {
            var dtos = await _supplierService.GetByIdAsync(id);
            if (dtos == null) return null;
            return new SupplierViewModel
            {
                Id = dtos.Id,
                FullName = dtos.FullName,
                PhoneNumber = dtos.PhoneNumber,
                Email = dtos.Email
            };
        }
        public async Task AddAsync(SupplierCreateViewModel vm)
        {
            var dtos = new SupplierCreateDTO
            {
                FullName = vm.FullName,
                PhoneNumber = vm.PhoneNumber,
                Email = vm.Email
            };
            await _supplierService.AddAsync(dtos);
        }
        public async Task UpdateAsync(int id, SupplierViewModel vm)
        {
            var existing = await _supplierService.GetByIdAsync(id);
            if (existing == null) return;
            var dtos = new SupplierDTO
            {
                Id = vm.Id,
                FullName = vm.FullName,
                PhoneNumber = vm.PhoneNumber,
                Email = vm.Email
            };
            await _supplierService.UpdateAsync(id, dtos);
        }
        public async Task DeleteAsync(int id)
        {
            await _supplierService.DeleteAsync(id);
        }
    }
}
