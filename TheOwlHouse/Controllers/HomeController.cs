using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheOwlHouse.Models;
using TheOwlHouse.Services;

namespace TheOwlHouse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITohService _tohService;

    public HomeController(ILogger<HomeController> logger, ITohService tohService)
    {
        _logger = logger;
        _tohService = tohService;
    }
    public IActionResult Index(string tipo)
    {
        var persos = _tohService.GetTheOwlHouseDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(persos);
    }
    public IActionResult Details(int Numero)
    {
        var personagem = _tohService.GetDetailedPersonagem(Numero);
        return View(personagem);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id
        ?? HttpContext.TraceIdentifier
        });
    }
}

