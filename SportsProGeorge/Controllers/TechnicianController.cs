using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsProGeorge.Models;

namespace SportsProGeorge.Controllers
{
	[Authorize(Roles = "Admin")]
	public class TechnicianController : Controller
    {
        private FinalProjectContext context { get; set; }

        public TechnicianController(FinalProjectContext ctx) => context = ctx;

        [Route("technicians/")]
        public IActionResult Index()
        {
            var technicians = context.Technicians.OrderBy(t => t.Name).Where(t => t.TechnicianID > 0).ToList();
            return View("List", technicians);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician modifiedTechnician)
        {
            if (ModelState.IsValid)
            {
                if (modifiedTechnician.TechnicianID == 0)
                {
                    context.Technicians.Add(modifiedTechnician);
                }
                else
                {
                    context.Technicians.Update(modifiedTechnician);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = modifiedTechnician.TechnicianID == 0 ? "Add" : "Edit";
                return View(modifiedTechnician);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
