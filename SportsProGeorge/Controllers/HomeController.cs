using Microsoft.AspNetCore.Mvc;
using SportsProGeorge.Models;
using System.Diagnostics;

namespace SportsProGeorge.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("about/")]
        public IActionResult About()
        {
            return View("About");
        }

    }
}