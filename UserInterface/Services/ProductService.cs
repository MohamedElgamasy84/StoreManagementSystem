using BL.Models;
using Business.DTO;
using Business.Interfaces;
using Core.Models;
using DAL.Contexts;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.DTO;
using UserInterface.Repositories;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly StoreDbContext _dbContext;

        public ProductService(IGenericRepository<Product> genericRepository, StoreDbContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductCreateDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                CostPrice = dto.CostPrice,

                ImageName = dto.ImageName,
                CategoryId = dto.CategoryId,
                ProductUnits = new List<ProductUnit>()

            };
            if (dto.ProductUnits != null && dto.ProductUnits.Any())
            {
                foreach (var u in dto.ProductUnits)
                {
                    product.ProductUnits.Add(new ProductUnit
                    {
                        UnitId = u.UnitId,
                        Factor = u.Factor,
                        SalePrice = u.SalePrice
                    });
                }
            }
            await _genericRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            if (product == null) return;
            _genericRepository.Delete(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var product = await _dbContext.Products
                  .Include(o => o.Category)
                  .ToListAsync();
            return product.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                CostPrice = p.CostPrice,
                ImageName = p.ImageName,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.Name : string.Empty
                
            });
        }

        public async Task<IEnumerable<UnitDTO>> GetAllUnitsAsync()
        {
            var units = await _dbContext.Units.ToListAsync();
            return units.Select(u => new UnitDTO
            {
                Id = u.Id,
                Name = u.Name
            });
        }

        public async Task<ProductDetailDTO> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products
                 .Include(p => p.Category)
                 .Include(p => p.ProductUnits)
                 .ThenInclude(pu => pu.Unit)
                 .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;
            return new ProductDetailDTO
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                CostPrice = product.CostPrice,

                ImageName = product.ImageName,
                CategoryId = product.CategoryId,

                CategoryName = product.Category != null ? product.Category.Name : string.Empty,               
                ProductUnits = product.ProductUnits.Select(U => new ProductUnitDetailDTO
                {
                    UnitId = U.UnitId,
                    UnitName = U.Unit?.Name ?? string.Empty,
                    Factor = U.Factor,
                    SalePrice = U.SalePrice
                }).ToList(),
            };
        }

        public async Task<List<ProductUnitDetailDTO>> GetUnitsByProductIdAsync(int productId)
        {
            return await _dbContext.ProductUnits
                       .Include(pu => pu.Unit)
                       .Where(pu => pu.ProductId == productId)
                       .Select(pu => new ProductUnitDetailDTO
                       {
                           UnitId = pu.UnitId,
                           UnitName = pu.Unit.Name,
                           SalePrice = pu.SalePrice
                       })
                       .ToListAsync();
        }

        public async Task UpdateAsync(int id, ProductUpdateDTO dto)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            if (product == null) return;
            product.Name = dto.Name;
            product.CostPrice = dto.CostPrice;
           
            product.CategoryId = dto.CategoryId;
            
            await _genericRepository.UpdateAsync(product);



        }
    }
}
