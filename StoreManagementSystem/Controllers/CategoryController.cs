using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Helpers;
using StoreManagementSystem.Provider;
using StoreManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    //[Authorize(Roles = "Owner,Admin")]

    public class CategoryController : Controller
    {
        private readonly CategoryProvider _categoryProvider;

        public CategoryController(CategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryProvider.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (CategoryCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.ImageName = DocumentSettings.UploadFile(vm.Image, "Images");
                await _categoryProvider.AddAsync(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public async Task<IActionResult> Details (int id)
        {
            var category = await _categoryProvider.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            var category = await _categoryProvider.GetByIdAsync (id);
            if (category == null)
                return NotFound();
            var updatecategory = MappingHelper.ToUpdateCGViewModel(category);
            return View(updatecategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (int id, CategoryUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _categoryProvider.UpdateAsync(id, vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            var category = await _categoryProvider.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            await _categoryProvider.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
