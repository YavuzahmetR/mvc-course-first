using Demo_ProductUI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    [AllowAnonymous]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            userEditViewModel userEditViewModel = new userEditViewModel();
            userEditViewModel.Name = result.Name;
            userEditViewModel.SurName = result.Surname;
            userEditViewModel.Gender = result.Gender;
            userEditViewModel.Mail = result.Email;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(userEditViewModel uvm)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = uvm.Name;
            user.Surname = uvm.SurName;
            user.Email = uvm.Mail;
            user.Gender = uvm.Gender;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, uvm.Password);

            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index","Login");
            }
            else
            {
                //error codes...
            }
            return View();
        }











    }
}
