using BL.Models;
using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDTO>> GetAllAsync();
        Task<SupplierDTO> GetByIdAsync(int id);
        Task AddAsync(SupplierCreateDTO dto);
        Task UpdateAsync(int id, SupplierDTO dto);
        Task DeleteAsync(int id);
    }
}
