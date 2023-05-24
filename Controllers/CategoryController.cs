using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
