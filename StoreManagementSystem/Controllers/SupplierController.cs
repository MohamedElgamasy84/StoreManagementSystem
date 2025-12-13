using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Helpers;
using StoreManagementSystem.Provider;
using StoreManagementSystem.ViewModels;

namespace StoreManagementSystem.Controllers
{
    //[Authorize(Roles = "Owner,Admin")]

    public class SupplierController : Controller
    {
        private readonly SupplierProvider _supplierProvider;

        public SupplierController(SupplierProvider supplierProvider)
        {
            _supplierProvider = supplierProvider;
        }
        public async Task<IActionResult> Index()
        {
            var supplier = await _supplierProvider.GetAllAsync();
            return View(supplier);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (SupplierCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _supplierProvider.AddAsync(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public async Task<IActionResult> Details (int id)
        {
            var supplier = await _supplierProvider.GetByIdAsync(id);
            if (supplier == null)
                return NotFound();
            return View(supplier);
        }
        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            var supplier = await _supplierProvider.GetByIdAsync(id);
            if (supplier == null)
                return NotFound();
            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (int id, SupplierViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _supplierProvider.UpdateAsync(id, vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            var supplier = await _supplierProvider.GetByIdAsync(id);
            if (supplier == null)
                return NotFound();
            return View(supplier);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            await _supplierProvider.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
