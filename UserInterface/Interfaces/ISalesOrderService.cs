using Business.DTO;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Interfaces
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrderDTO>> GetAllAsync();
        Task<SalesOrderDTO> GetByIdAsync(int id);

        Task AddAsync(SalesOrderCreateDTO dto);
        Task DeleteAsync(int id);
    }
}
