using Business.DTO;
using Business.Interfaces;
using Core.Models;
using DAL.Contexts;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;

        public CategoryService(IGenericRepository<Category> genericRepository)
        {
            _genericRepository = genericRepository;
        }
       

        public async Task DeleteAsync(int id)
        {
            var category = await _genericRepository.GetByIdAsync(id);
            if (category == null) return;
            _genericRepository.Delete(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var category = await _genericRepository.GetAllAsync();
            return category.Select(c => new CategoryDTO
            { 
                Id = c.Id,
                Name = c.Name,
                ImageName = c.ImageName

            });
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _genericRepository.GetByIdAsync(id);
            if (category == null) return null;
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                ImageName = category.ImageName

            };

        }

        public async Task UpdateAsync(int id, CategoryUpdateDTO dto)
        {
            var category = await _genericRepository.GetByIdAsync(id);
            if (category == null) return;
            category.Name = dto.Name;
            category.ImageName = dto.ImageName;

            await _genericRepository.UpdateAsync(category);

        }

        public async Task<int> AddAsync(CategoryCreateDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                ImageName = dto.ImageName
            };
            var addedCategory = await _genericRepository.AddAsync(category);

            return addedCategory.Id;
        }
    }
}
