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

namespace Business.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IGenericRepository<PurchaseOrder> _PurchaseOrderRepo;
        private readonly IGenericRepository<Supplier> _supplierRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly StoreDbContext _dbContext;

        public PurchaseOrderService(IGenericRepository<PurchaseOrder> PurchaseOrderRepo,
            IGenericRepository<Supplier> SupplierRepo, IGenericRepository<Product> ProductRepo, StoreDbContext dbContext)
        {
            _PurchaseOrderRepo = PurchaseOrderRepo;
            _supplierRepo = SupplierRepo;
            _productRepo = ProductRepo;
            _dbContext = dbContext;
        }
        public async Task AddAsync(PurchaseOrderCreateDTO dto)
        {
            var supplier = await _supplierRepo.GetByIdAsync(dto.SupplierId);
            if (supplier == null) return;
            var order = new PurchaseOrder
            {
                SupplierId = dto.SupplierId,
                PurchaseOrderDate = dto.PurchaseOrderDate,
                PurchaseOrderDetails = new List<PurchaseOrderDetail>(),
                TotalAmount = dto.TotalAmount
            };
            decimal total = 0;
            foreach (var item in dto.Details)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null) continue;
                product.Quantity += item.Quantity;
                await _productRepo.UpdateAsync(product);
                var detail = new PurchaseOrderDetail
                {
                    ProductId = item.ProductId,
                    ProductUnitId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitCost = item.UnitCost,
                    
                };
                order.PurchaseOrderDetails.Add(detail);
                total += item.UnitCost * item.Quantity;
            }
            order.TotalAmount = total;
            await _PurchaseOrderRepo.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _PurchaseOrderRepo.GetByIdAsync(id);
            if (order == null) return;
            _PurchaseOrderRepo.Delete(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PurchaseOrderDTO>> GetAllAsync()
        {
            var order = await _dbContext.PurchaseOrders
                  .Include(o => o.Supplier)
                  .ToListAsync();
            return order.Select(o => new PurchaseOrderDTO
            {
                Id = o.Id,
                PurchaseOrderDate = o.PurchaseOrderDate,
                TotalAmount = o.TotalAmount,
                SupplierId = o.SupplierId,
                SupplierFullName = o.Supplier != null ? o.Supplier.FullName : string.Empty
            });
        }

        public async Task<PurchaseOrderDTO> GetByIdAsync(int id)
        {
            var order = await _dbContext.PurchaseOrders
        .Include(o => o.Supplier)
        .Include(o => o.PurchaseOrderDetails)
            .ThenInclude(d => d.Product)
        .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return null;
            return new PurchaseOrderDTO
            {
                Id = order.Id,
                PurchaseOrderDate = order.PurchaseOrderDate,
                TotalAmount = order.TotalAmount,
                SupplierFullName = order.Supplier != null ? order.Supplier.FullName : string.Empty,
                Details = order.PurchaseOrderDetails.Select(d => new PurchaseOrderDetailDTO
                {
                    ProductName = d.Product.Name,
                    Quantity = d.Quantity,
                    UnitCost = d.UnitCost
                }).ToList()
            };
        }
    }
}
