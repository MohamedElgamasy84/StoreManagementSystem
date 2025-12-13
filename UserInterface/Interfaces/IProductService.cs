using BL.Models;
using Business.DTO;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDetailDTO>GetByIdAsync(int id);
        Task<IEnumerable<UnitDTO>> GetAllUnitsAsync();
        Task<List<ProductUnitDetailDTO>> GetUnitsByProductIdAsync(int productId);

        Task AddAsync(ProductCreateDTO dto);
        Task UpdateAsync(int id, ProductUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
