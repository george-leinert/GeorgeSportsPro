using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsProGeorge.Models;

namespace SportsProGeorge.Controllers
{
	[Authorize(Roles = "Admin")]
	public class IncidentController : Controller
    {
        private FinalProjectContext context { get; set; }

        public IncidentController(FinalProjectContext ctx) => context = ctx;

        [Route("incidents/")]
        public IActionResult Index(string filter)
        {
            IQueryable<Incident> query = context.Incidents.OrderBy(i => i.Title);

            if (filter == "unassigned")
            {
                query = query.Where(i => i.TechnicianID == -1);
            }
            else if (filter == "open")
            {
                query = query.Where(i => i.DateClosed == null);
            }

            var incidents = query.ToList();

            foreach (var i in incidents)
            {
                i.Product = context.Products.Find(i.ProductID);
                i.Customer = context.Customers.Find(i.CustomerID);
            }

            IncidentViewModel vm = new IncidentViewModel
            {
                Incidents = incidents,
                FilterSpecify = filter ?? "",
            };

            return View("List", vm);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.TechnicianID).ToList();
            var products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();


            IncidentViewModel vm = new IncidentViewModel
            {
                Incidents = context.Incidents.OrderBy(i => i.Title).ToList(),
                Customers = ViewBag.Customers,
                Technicians = ViewBag.Technicians,
                Products = products,
                AddOrEdit = "Add",

            };

            return View("Edit", vm);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var incident = context.Incidents.Find(id);
            ViewBag.Customers = context.Customers.OrderBy(c => c.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.TechnicianID).ToList();
            var products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();


            IncidentViewModel vm = new IncidentViewModel
            {
                Incidents = context.Incidents.OrderBy(i => i.Title).ToList(),
                Incident = incident,
                Customers = ViewBag.Customers,
                Technicians = ViewBag.Technicians,
                Products = products,
                AddOrEdit = "Edit",
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var incident = vm.Incident;


                if (incident.IncidentID == 0)
                {
                    //incident.TechnicianID = -1;
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }
                context.SaveChanges();
                vm.Incidents = context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).OrderBy(i => i.Title).ToList();


                return View("List", vm);
            }
            else
            {
                ViewBag.Action = vm.AddOrEdit;
                ViewBag.Customers = context.Customers.OrderBy(c => c.Name).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
                ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
                vm.Products = context.Products.OrderBy(p => p.Name).ToList();
                return View("Edit", vm);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
