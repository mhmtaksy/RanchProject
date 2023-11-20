using Microsoft.AspNetCore.Mvc;
using RanchProject.Models;

namespace RanchProject.Controllers
{
    public class ManagerController : Controller
    {
        public readonly RanchContext dbContext;
        public ManagerController(RanchContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.Managers.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Manager manager)
        {
            dbContext.Managers.Add(manager);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.Managers.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Manager manager)
        {
            dbContext.Update(manager);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.Managers.Find(id);
            dbContext.Managers.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
