using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var result = jobManager.TGetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {    
                jobManager.TInsert(job);
                return RedirectToAction("Index");           
        }
        public IActionResult DeleteJob(int id)
        {
            var result = jobManager.TGetById(id);
            jobManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var result = jobManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {

            jobManager.TUpdate(job);
            return RedirectToAction("Index");
        }
    }
}
