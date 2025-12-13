using BL.Models;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class StoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail>PurchaseOrderDetails { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail>SalesOrderDetails { get; set; }   
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
       .HasOne(p => p.Category)
       .WithMany(c => c.Products)
       .HasForeignKey(p => p.CategoryId)
       .OnDelete(DeleteBehavior.Restrict);

            // Unit → ProductUnit (1 : Many)
            modelBuilder.Entity<ProductUnit>()
                .HasOne(pu => pu.Unit)
                .WithMany(u => u.ProductUnits)
                .HasForeignKey(pu => pu.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product → ProductUnit (1 : Many)
            modelBuilder.Entity<ProductUnit>()
                .HasOne(pu => pu.Product)
                .WithMany(p => p.ProductUnits)
                .HasForeignKey(pu => pu.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Supplier → PurchaseOrder (1 : Many)
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(po => po.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrder → PurchaseOrderDetail (1 : Many)
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.PurchaseOrder)
                .WithMany(po => po.PurchaseOrderDetails)
                .HasForeignKey(pod => pod.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product → PurchaseOrderDetail (1 : Many)
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.Product)
                .WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(pod => pod.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductUnit → PurchaseOrderDetail (1 : Many)
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(pod => pod.ProductUnit)
                .WithMany()
                .HasForeignKey(pod => pod.ProductUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer → SalesOrder (1 : Many)
            modelBuilder.Entity<SalesOrder>()
                .HasOne(so => so.Customer)
                .WithMany(c => c.SalesOrders)
                .HasForeignKey(so => so.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SalesOrder → SalesOrderDetail (1 : Many)
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.SalesOrder)
                .WithMany(so => so.SalesOrderDetails)
                .HasForeignKey(sod => sod.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product → SalesOrderDetail (1 : Many)
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.Product)
                .WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(sod => sod.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductUnit → SalesOrderDetail (1 : Many)
            modelBuilder.Entity<SalesOrderDetail>()
                .HasOne(sod => sod.ProductUnit)
                .WithMany()
                .HasForeignKey(sod => sod.ProductUnitId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "قطعة" },
                new Unit { Id = 2, Name = "علبة" },
                new Unit { Id = 3, Name = "كرتونة" },
                new Unit { Id = 4, Name = "كيلو" },
                new Unit { Id = 5, Name = "لتر" },
                new Unit { Id = 7, Name = "زجاجة" }
            );
            
        }

    }

}

