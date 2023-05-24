using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Demo_ProductUI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var result = productManager.TGetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(product);
            if (results.IsValid)
            {
                productManager.TInsert(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var validation in results.Errors)
                {
                    ModelState.AddModelError(validation.PropertyName, validation.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult DeleteProduct(int id)
        {
            var result = productManager.TGetById(id);
            productManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var result = productManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {

            productManager.TUpdate(product);
            return RedirectToAction("Index");
        }
      
        
        
        
        
    }
}
