using Microsoft.AspNetCore.Mvc;
using RanchProject.Models;

namespace RanchProject.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly RanchContext dbContext;
        public EmployeeController(RanchContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.Employees.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.Employees.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            dbContext.Update(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.Employees.Find(id);
            dbContext.Employees.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
