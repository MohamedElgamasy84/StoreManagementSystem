using Business.DTO;
using Business.Interfaces;
using DAL.Contexts;
using StoreManagementSystem.ViewModels;
using UserInterface.DTO;

namespace StoreManagementSystem.Provider
{
    public class CategoryProvider
    {
        private readonly ICategoryService _categoryService;
       
        public CategoryProvider(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }
        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var dtos = await _categoryService.GetAllAsync();
            return dtos.Select(dtos => new CategoryViewModel
            {
                Id = dtos.Id,
                Name = dtos.Name,
                ImageName = dtos.ImageName
            }).ToList();
        }
        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var dtos = await _categoryService.GetByIdAsync(id);
            if (dtos == null) return null;
            return new CategoryViewModel
            {
                Id = dtos.Id,
                Image = dtos.Image,
                Name = dtos.Name,
                ImageName = dtos.ImageName
            };
        }
        public async Task<int> AddAsync(CategoryCreateViewModel vm)
        {
            var dtos = new CategoryCreateDTO
            {
                Name = vm.Name,
                ImageName = vm.ImageName
            };
           var newid = await _categoryService.AddAsync(dtos);
            return newid;
        }
        public async Task UpdateAsync (int id, CategoryUpdateViewModel vm)
        {
            var existing = await _categoryService.GetByIdAsync(id);
            if (existing == null) return;
            var dtos = new CategoryUpdateDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                ImageName = vm.ImageName,
                Image = vm.Image

            };
            await _categoryService.UpdateAsync(id,dtos);
        }
        public async Task DeleteAsync (int id)
        {
            await _categoryService.DeleteAsync(id);
        }
    }
}
