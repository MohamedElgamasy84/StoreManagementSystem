using Business.DTO;
using Business.Interfaces;
using Business.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.ViewModels;
using UserInterface.DTO;

namespace StoreManagementSystem.Provider
{
    public class ProductProvider
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductProvider(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        private ProductViewModel MapDtoToViewModel(ProductDTO dto)
        {
            if (dto == null) return null;
            return new ProductViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Quantity = dto.Quantity,

                CostPrice = dto.CostPrice,
                ImageName = dto.ImageName,
                CategoryName = dto.CategoryName
            };
        }
        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var dtos = await _productService.GetAllAsync();
            return dtos.Select(MapDtoToViewModel).ToList();
        }
        public async Task<ProductDetailViewModel> GetByIdAsync(int id)
        {
            var dtos = await _productService.GetByIdAsync(id);
            if (dtos == null) return null;
            return new ProductDetailViewModel
            {
                Id = dtos.Id,
                Image = dtos.Image,
                Name = dtos.Name,
                Quantity = dtos.Quantity,
                CostPrice = dtos.CostPrice,

                CategoryName = dtos.CategoryName,
                Units = dtos.ProductUnits.Select(U => new ProductUnitDetailViewModel
                {
                    UnitId = U.UnitId,
                    UnitName = U.UnitName

                }).ToList()
            };
        }
        public async Task AddAsync(ProductCreateViewModel vm)
        {
            if (vm == null) throw new ArgumentNullException(nameof(vm));
            var dto = new ProductCreateDTO
            {
                Name = vm.Name,
                UnitId = vm.UnitId,
                CostPrice = vm.CostPrice,

                ImageName = vm.ImageName,
                CategoryId = vm.CategoryId,
                ProductUnits = vm.Units.Select(U => new ProductUnitCreateDTO
                {

                    UnitId = U.UnitId,
                    Factor = U.Factor,
                    SalePrice = U.SalePrice

                }).ToList()

            };
            await _productService.AddAsync(dto);
        }
        public async Task UpdateAsync(int id, ProductUpdateViewModel vm)
        {
            if (vm == null) throw new ArgumentNullException(nameof(vm));
            var found = await _productService.GetByIdAsync(id);
            if (found == null) throw new InvalidOperationException("Product Not Found");
            var dto = new ProductUpdateDTO
            {
                Id = vm.Id,
                Name = vm.Name,

                CostPrice = vm.CostPrice,

                CategoryId = vm.CategoryId
                
            };
            await _productService.UpdateAsync(id, dto);
        }
        public async Task DeleteAsync(int id)
        {
            await _productService.DeleteAsync(id);
        }
        public async Task<List<ProductViewModel>> SearchAsync(string keyword)
        {
            var all = await GetAllAsync();
            if (string.IsNullOrWhiteSpace(keyword)) return all;
            keyword = keyword.Trim().ToLowerInvariant();
            return all.Where(p => (p.Name ?? string.Empty).ToLowerInvariant().Contains(keyword) ||
                            (p.CategoryName ?? string.Empty).ToLowerInvariant().Contains(keyword))
                .ToList();


        }
        public async Task<List<UnitViewModel>> GetAllUnitsAsync()
        {
            var dtos = await _productService.GetAllUnitsAsync();

            return dtos.Select(u => new UnitViewModel
            {
                Id = u.Id,
                Name = u.Name
            }).ToList();
        }
        public async Task<List<ProductUnitDetailViewModel>> GetUnitsByProductIdAsync(int productId)
        {
            var dtos = await _productService.GetUnitsByProductIdAsync(productId);

            return dtos.Select(d => new ProductUnitDetailViewModel
            {
                UnitId = d.UnitId,
                UnitName = d.UnitName,
                SalePrice = d.SalePrice
            }).ToList();
        }
    }
}
