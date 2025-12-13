using BL.Models;
using Business.DTO;
using Business.Interfaces;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IGenericRepository<Supplier> _genericRepository;

        public SupplierService(IGenericRepository<Supplier> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task AddAsync(SupplierCreateDTO dto)
        {
            var supplier = new Supplier
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };
            await _genericRepository.AddAsync(supplier);
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _genericRepository.GetByIdAsync(id);
            if (supplier == null) return;
            _genericRepository.Delete(supplier);
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllAsync()
        {
            var supplier = await _genericRepository.GetAllAsync();
            return supplier.Select(s => new SupplierDTO
            {
                Id = s.Id,
                FullName = s.FullName,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email
            });
        }

        public async Task<SupplierDTO> GetByIdAsync(int id)
        {
            var supplier = await _genericRepository.GetByIdAsync(id);
            if (supplier == null) return null;
            return new SupplierDTO
            {
                Id = supplier.Id,
                FullName = supplier.FullName,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email
            };
        }

        public async Task UpdateAsync(int id, SupplierDTO dto)
        {
            var supplier = await _genericRepository.GetByIdAsync(id);
            if (supplier == null) return;
            supplier.Id = dto.Id;
            supplier.FullName = dto.FullName;
            supplier.PhoneNumber = dto.PhoneNumber;
            supplier.Email = dto.Email;
            await _genericRepository.UpdateAsync(supplier);
        }
    }
}
