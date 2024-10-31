using ASP9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ComponentModel> list = new List<ComponentModel>
            {
                new ComponentModel {Id = 1, Name = "Name 1", Price = 14.5f },
                new ComponentModel {Id = 2, Name = "Name 2", Price = 15.5f },
                new ComponentModel {Id = 3, Name = "Name 3", Price = 16.5f }
            };

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
