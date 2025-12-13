using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Helpers;
using StoreManagementSystem.Provider;
using StoreManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    //[Authorize(Roles = "Owner,Admin,Cashier")]

    public class CustomerController : Controller
    {
        private readonly CustomerProvider _customerProvider;

        public CustomerController(CustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        public async Task<IActionResult> Index()
        {
            var customer = await _customerProvider.GetAllAsync();
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _customerProvider.AddAsync(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public async Task<IActionResult> Details (int id)
        {
            var customer = await _customerProvider.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerProvider.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _customerProvider.UpdateAsync(id, vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            var customer = await _customerProvider.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerProvider.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
