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
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task <CustomerDTO> GetByIdAsync(int id);
        Task AddAsync(CustomerCreateDTO dto);
        Task UpdateAsync(int id, CustomerDTO dto);
        Task DeleteAsync(int id);
    }
}
