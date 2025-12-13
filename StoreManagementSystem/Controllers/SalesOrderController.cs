using DAL.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Provider;
using StoreManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    //[Authorize(Roles = "Owner,Admin,Cashier")]

    public class SalesOrderController : Controller
    {
        private readonly SalesOrderProvider _salesOrderProvider;
        private readonly CustomerProvider _customerProvider;
        private readonly ProductProvider _productProvider;
        private readonly StoreDbContext _dbContext;

        public SalesOrderController(SalesOrderProvider salesOrderProvider, CustomerProvider customerProvider, ProductProvider productProvider, StoreDbContext dbContext)
        {
            _salesOrderProvider = salesOrderProvider;
            _customerProvider = customerProvider;
            _productProvider = productProvider;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _salesOrderProvider.GetAllAsync();
            return View(orders);
        }
        public async Task<IActionResult> Create()
        {
            var customers = await _customerProvider.GetAllAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");
            var products = await _productProvider.GetAllAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");
          
            return View(new SalesOrderCreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SalesOrderCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _salesOrderProvider.AddAync(vm);
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerProvider.GetAllAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");
            var products = await _productProvider.GetAllAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");
            
            return View(vm);
        }

        public async Task<IActionResult> Details (int id)
        {
            var order = await _salesOrderProvider.GetByIdAsync(id);
            if (order == null)
                return NotFound();
            return View(order);
        }
        public async Task<JsonResult> GetUnitsByProduct(int productId)
        {
            var units = await _productProvider.GetUnitsByProductIdAsync(productId);
            return Json(units);
        }
    }
}
