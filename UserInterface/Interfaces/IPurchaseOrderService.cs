using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrderDTO>> GetAllAsync();
        Task<PurchaseOrderDTO> GetByIdAsync(int id);
        Task AddAsync(PurchaseOrderCreateDTO dto);
        Task DeleteAsync(int id);
    }
}
