using DotNetTrainingMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetTrainingMVC.Controllers
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
            HomeResponseModel model = new HomeResponseModel();
            model.message = "Hello from MVC!";
            return View(model);
        }

        public IActionResult Privacy()
        {
            ViewBag.Message = "hoooohoooo";
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
