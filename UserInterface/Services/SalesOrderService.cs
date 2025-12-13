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
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IGenericRepository<SalesOrder> _salesOrderRepo;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly StoreDbContext _dbContext;

        public SalesOrderService(IGenericRepository<SalesOrder> SalesOrderRepo, IGenericRepository<Customer> CustomerRepo,IGenericRepository<Product> ProductRepo, StoreDbContext dbContext)
        {
            _salesOrderRepo = SalesOrderRepo;
            _customerRepo = CustomerRepo;
            _productRepo = ProductRepo;
            _dbContext = dbContext;
        }
        public async Task AddAsync(SalesOrderCreateDTO dto)
        {
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerId);
            if (customer == null) return;
            var order = new SalesOrder
            {
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                SalesOrderDetails = new List<SalesOrderDetail>(),
                TotalAmount = dto.TotalAmount
            };
            decimal total = 0;
            foreach(var item in dto.Details)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (item == null) continue;
                if (product.Quantity < item.Quantity)
                    throw new Exception($"الكمية المطلوبة من المنتج {product.Name} غير متوفرة");
                product.Quantity -= item.Quantity;
                await _productRepo.UpdateAsync(product);
                var detail = new SalesOrderDetail
                {
                    ProductId = item.ProductId,
                    ProductUnitId = item.ProductUnitId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount
                };
                order.SalesOrderDetails.Add(detail);
                total += (item.UnitPrice * item.Quantity) - (item.Discount ?? 0);
            }
            order.TotalAmount = total;
            await _salesOrderRepo.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _salesOrderRepo.GetByIdAsync(id);
            if (order == null) return;
            _salesOrderRepo.Delete(order);
            await _dbContext.SaveChangesAsync();
        }

        public  async Task<IEnumerable<SalesOrderDTO>> GetAllAsync()
        {
            var order = await _dbContext.SalesOrders
                  .Include(o => o.Customer)
                  .ToListAsync();
            return order.Select(o => new SalesOrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                CustomerId = o.CustomerId,
                CustomerFullName = o.Customer != null ? o.Customer.FullName : string.Empty,
            });
        }

        public async Task<SalesOrderDTO> GetByIdAsync(int id)
        {
            var order = await _dbContext.SalesOrders
        .Include(o => o.Customer)
        .Include(o => o.SalesOrderDetails)
            .ThenInclude(d => d.Product)
        .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return null;
            return new SalesOrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                CustomerFullName = order.Customer != null ? order.Customer.FullName : string.Empty,
                Details = order.SalesOrderDetails.Select(d => new SalesOrderDetailDTO
                {
                    ProductName = d.Product.Name,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    Discount = d.Discount

                }).ToList()
            };
           
        }

       
    }
}
