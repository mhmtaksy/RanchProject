using Microsoft.AspNetCore.Mvc;
using RanchProject.Models;

namespace RanchProject.Controllers
{
    public class ProductController : Controller
    {
        public readonly RanchContext dbContext;
        public ProductController(RanchContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.Products.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.Products.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            dbContext.Update(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.Products.Find(id);
            dbContext.Products.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
