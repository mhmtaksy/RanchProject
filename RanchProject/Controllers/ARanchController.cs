using Microsoft.AspNetCore.Mvc;
using RanchProject.Models;

namespace RanchProject.Controllers
{
    public class ARanchController : Controller
    {
        public readonly RanchContext dbContext;
        public ARanchController(RanchContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.Aranches.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Aranch aranch)
        {
            dbContext.Aranches.Add(aranch);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.Aranches.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Aranch aranch)
        {
            dbContext.Update(aranch);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.Aranches.Find(id);
            dbContext.Aranches.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
