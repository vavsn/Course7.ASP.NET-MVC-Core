using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoureProject.MVC.Models;
using CoureProject.Domain;
using CoureProject.Interfaces;

namespace CoureProject.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositoryAsync<Consolidated_Weather> _weathers;

    public HomeController(IRepositoryAsync<Consolidated_Weather> weathers, ILogger<HomeController> logger)
    {
        _weathers = weathers;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var weathers = await _weathers.GetAllAsync();
        return View(weathers);
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
