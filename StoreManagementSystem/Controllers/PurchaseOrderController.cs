using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagementSystem.Provider;
using StoreManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    //[Authorize(Roles = "Owner,Admin")]

    public class PurchaseOrderController : Controller
    {
        private readonly PurchaseOrderProvider _purchaseOrderProvider;
        private readonly SupplierProvider _supplierProvider;
        private readonly ProductProvider _productProvider;

        public PurchaseOrderController(PurchaseOrderProvider purchaseOrderProvider, SupplierProvider supplierProvider, ProductProvider productProvider)
        {
            _purchaseOrderProvider = purchaseOrderProvider;
            _supplierProvider = supplierProvider;
            _productProvider = productProvider;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _purchaseOrderProvider.GetAllAsync();
            return View(orders);
        }
        public async Task<IActionResult> Create()
        {
            var suppliers = await _supplierProvider.GetAllAsync(); 
            ViewBag.Suppliers = new SelectList(suppliers, "Id", "FullName");
            var products = await _productProvider.GetAllAsync();   
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View(new PurchaseOrderCreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _purchaseOrderProvider.AddAsync(vm);
                return RedirectToAction(nameof(Index));
            }
            var suppliers = await _supplierProvider.GetAllAsync();
            ViewBag.Suppliers = new SelectList(suppliers, "Id", "FullName");
            var products = await _productProvider.GetAllAsync();   
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View(vm);
        }
        public async Task<IActionResult> Details(int id)
        {
            var order = await _purchaseOrderProvider.GetByIdAsync(id);
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
