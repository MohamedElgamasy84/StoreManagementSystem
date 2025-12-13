using BL.Models;
using Business.DTO;
using Business.Interfaces;
using Core.Models;
using DAL.Contexts;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly StoreDbContext _dbContext;

        public CustomerService(IGenericRepository<Customer> genericRepository,StoreDbContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }
        public async Task AddAsync(CustomerCreateDTO dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber
            };
            await _genericRepository.AddAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _genericRepository.GetByIdAsync(id);
            if(customer == null) return;
            _genericRepository.Delete(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customer = await _genericRepository.GetAllAsync();
            return customer.Select(c => new CustomerDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber
            });
        }

        public async Task<CustomerDTO> GetByIdAsync(int id)
        {
            var customer = await _genericRepository.GetByIdAsync(id);
            if(customer == null) return null;
            return new CustomerDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task UpdateAsync(int id, CustomerDTO dto)
        {
            var customer = await _genericRepository.GetByIdAsync(id);
            if(customer == null) return;
            customer.Id = dto.Id;
            customer.FullName = dto.FullName;
            customer.PhoneNumber = dto.PhoneNumber;
            await _genericRepository.UpdateAsync(customer);
            await _dbContext.SaveChangesAsync();

        }
    }
}
