using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsProGeorge.Models;

namespace SportsProGeorge.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ProductController : Controller
    {
        private FinalProjectContext context { get; set; }

        public ProductController(FinalProjectContext ctx) => context = ctx;


        [Route("products/")]
        public ViewResult Index()
        {
            var products = context.Products.OrderBy(p => p.Name).ToList();
            return View("List", products);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product modifiedProduct)
        {
            if (ModelState.IsValid)
            {
                if (modifiedProduct.ProductID == 0)
                {
                    context.Products.Add(modifiedProduct);
                    TempData["message"] = $"{modifiedProduct.Name} was added.";
                }
                else
                {
                    context.Products.Update(modifiedProduct);
                    TempData["message"] = $"{modifiedProduct.Name} was updated.";

                }
                context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Action = modifiedProduct.ProductID == 0 ? "Add" : "Edit";
                return View(modifiedProduct);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            var productName = product.Name;
            TempData["message"] = $"{productName} was deleted";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

    }
}
