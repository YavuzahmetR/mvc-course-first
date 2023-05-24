using Demo_ProductUI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller    
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.SurName,
                UserName = model.UserName,
                Email = model.Mail
            };
            if(model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
//Password ---> least 6 char , 1 upper - 1 lower, 1 symbol - IdentityLib default password construct.