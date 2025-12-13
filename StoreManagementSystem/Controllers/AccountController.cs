using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var user = await _userManager.FindByNameAsync(vm.Username);
            if(user == null)
            {
                ModelState.AddModelError("", "اسم المستخدم غير صحيح");
                return View(vm);
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "كلمة السر غير صحيحة");
            return View(vm);
        }

        [Authorize(Roles = "Owner,Admin")]

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel
            {
                AvailableRoles = new List<string> { "Admin", "Cashier" }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableRoles = new List<string> { "Admin", "Cashier" };
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                PasswordHash = model.Password,
                EmploymentDate = model.EmploymentDate,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (await _roleManager.RoleExistsAsync(model.Role))
                    await _userManager.AddToRoleAsync(user, model.Role);

                TempData["Success"] = "تم انشاء مستخدم";
                return RedirectToAction("Register");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            model.AvailableRoles = new List<string> { "Admin", "Cashier" };
            return View(model);
        }
        [Authorize(Roles = "Owner,Admin")]

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userList = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    EmploymentDate = user.EmploymentDate,
                    Email = user.Email,
                    Role = roles.FirstOrDefault() ?? "No Role"
                });
            }

            return View(userList);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                TempData["Success"] = "تم حذف المستخدم";
            else
                TempData["Error"] = "يوجد خطأ في عملية المسح";

            return RedirectToAction("Index");
        }
    }


}

