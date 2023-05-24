using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;

namespace Demo_ProductUI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jobManager = new JobManager(new EfJobDal()); // Solid Crush
        public IActionResult Index()
        {
            var result = customerManager.GetCustomersListWithJob();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddCustomer() 
        {           
            List<SelectListItem> results = (from values in jobManager.TGetAll()
                                          select new SelectListItem
                                          {
                                              Text = values.JobName,
                                              Value = values.JobID.ToString(),
                                          }).ToList();
            ViewBag.v = results;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(customer);
            if (results.IsValid)
            {
                customerManager.TInsert(customer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var error  in results.Errors) { ModelState.AddModelError(error.PropertyName, error.ErrorMessage); }
            }
            return View();
        }
    
        public IActionResult DeleteCustomer(int id)
        {
            var result = customerManager.TGetById(id);
            customerManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id) 
        {
            List<SelectListItem> results = (from values in jobManager.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = values.JobName,
                                               Value = values.JobID.ToString(),
                                           }).ToList();
            ViewBag.v = results;
            var result = customerManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {

            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(customer);
            if (results.IsValid) {
                customerManager.TUpdate(customer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
            
    
    }
}
