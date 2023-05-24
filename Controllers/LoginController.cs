using Demo_ProductUI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel ulv)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(ulv.UserName, ulv.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Category");
                }
                else { ModelState.AddModelError("", "Hatalı Kullanıcı Adı veya Şifre"); }
            }
            return View();
        }
        
        
    
    
    
    
    
    
    
    
    }   
}
