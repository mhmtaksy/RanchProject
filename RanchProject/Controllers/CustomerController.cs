using Microsoft.AspNetCore.Mvc;
using RanchProject.Models;

namespace RanchProject.Controllers
{
    public class CustomerController : Controller
    {
        public readonly RanchContext dbContext;
        public CustomerController(RanchContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.Customers.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.Customers.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            dbContext.Update(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.Customers.Find(id);
            dbContext.Customers.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
