using FirstMVC.Models;
using FirstMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOfficeDayInfo dayInfo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOfficeDayInfo DayInfo, ILogger<HomeController> logger)
        {
            dayInfo = DayInfo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var di = dayInfo.GetAll();
            return View(di);
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