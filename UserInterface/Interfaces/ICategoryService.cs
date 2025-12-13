using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO>GetByIdAsync(int id);
        Task <int> AddAsync(CategoryCreateDTO dto);
        Task UpdateAsync(int id, CategoryUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
