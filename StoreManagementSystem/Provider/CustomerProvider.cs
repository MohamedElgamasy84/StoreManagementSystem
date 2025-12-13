using Business.DTO;
using Business.Interfaces;
using Business.Services;
using StoreManagementSystem.ViewModels;
using UserInterface.DTO;

namespace StoreManagementSystem.Provider
{
    public class CustomerProvider
    {
        private readonly ICustomerService _customerService;

        public CustomerProvider(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            var dtos = await _customerService.GetAllAsync();
            return dtos.Select(d => new CustomerViewModel
            {
                Id = d.Id,
                FullName = d.FullName,
                PhoneNumber = d.PhoneNumber
            }).ToList();
        }
        public async Task<CustomerViewModel> GetByIdAsync (int id)
        {
            var dtos = await _customerService.GetByIdAsync(id);
            if (dtos == null) return null;
            return new CustomerViewModel
            {
                Id = dtos.Id,
                FullName = dtos.FullName,
                PhoneNumber = dtos.PhoneNumber
            };
        }
        public async Task AddAsync (CustomerCreateViewModel vm)
        {
            var dtos = new CustomerCreateDTO
            {
                FullName = vm.FullName,
                PhoneNumber = vm.PhoneNumber
            };
            await _customerService.AddAsync(dtos);
        }
        public async Task UpdateAsync(int id, CustomerViewModel vm)
        {
            var existing = await _customerService.GetByIdAsync(id);
            if (existing == null) return;
            var dtos = new CustomerDTO
            {
                Id = vm.Id,
                FullName = vm.FullName,
                PhoneNumber = vm.PhoneNumber,
                
            };
            await _customerService.UpdateAsync(id, dtos);
        }
        public async Task DeleteAsync(int id)
        {
            await _customerService.DeleteAsync(id);
        }
    }
}
