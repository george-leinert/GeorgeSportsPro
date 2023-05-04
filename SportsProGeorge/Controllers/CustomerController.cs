using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsProGeorge.Models;

namespace SportsProGeorge.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private FinalProjectContext context { get; set; }

        public CustomerController(FinalProjectContext ctx) => context = ctx;

        [Route("customers/")]
        public IActionResult Index()
        {
            var customers = context.Customers.OrderBy(c => c.Name).ToList();
            return View("List", customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var customer = context.Customers.Find(id);
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer modifiedCustomer)
        {
            if (ModelState.IsValid)
            {
                if (modifiedCustomer.CustomerID == 0)
                {
                    context.Customers.Add(modifiedCustomer);
                }
                else
                {
                    context.Customers.Update(modifiedCustomer);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
                ViewBag.Action = modifiedCustomer.CustomerID == 0 ? "Add" : "Edit";
                return View(modifiedCustomer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
