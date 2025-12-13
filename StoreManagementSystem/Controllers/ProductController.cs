using Business.Interfaces;
using Business.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagementSystem.Helpers;
using StoreManagementSystem.Provider;
using StoreManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    //[Authorize(Roles = "Owner,Admin")]

    public class ProductController : Controller
    {
        private readonly ProductProvider _productProvider;
        private readonly CategoryProvider _categoryProvider;

        public ProductController(ProductProvider productProvider, CategoryProvider categoryProvider)
        {
            _productProvider = productProvider;
            _categoryProvider = categoryProvider;
        }
        public async Task<IActionResult> Index(string? Search)
        {
            var products = await _productProvider.GetAllAsync();
            if(!string.IsNullOrWhiteSpace(Search))
                products = await _productProvider.SearchAsync(Search);
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryProvider.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var units = await _productProvider.GetAllUnitsAsync();
            ViewBag.Units = new SelectList(units, "Id", "Name");
            var vm = new ProductCreateViewModel
            {
                Units = new List<ProductUnitCreateViewModel>()
            };

            return View(vm); 
        }
        [HttpPost]
        public async Task<IActionResult> Create (ProductCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.ImageName = DocumentSettings.UploadFile(vm.Image, "Images");
                await _productProvider.AddAsync(vm);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryProvider.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var units = await _productProvider.GetAllUnitsAsync();
            ViewBag.Units = new SelectList(units, "Id", "Name");
            return View(vm);

        }
        public async Task<IActionResult> Details (int id)
        {
            var product = await _productProvider.GetByIdAsync(id);
            if (product == null) 
                return NotFound();
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            var product = await _productProvider.GetByIdAsync (id);
            if(product == null) 
                return NotFound();
            var categories = await _categoryProvider.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var updateviewmodel = MappingHelper.ToUpdatePRViewModel(product);
            return View(updateviewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (int id, ProductUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _productProvider.UpdateAsync(id, vm);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryProvider.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            var product = await _productProvider.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            await _productProvider.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
