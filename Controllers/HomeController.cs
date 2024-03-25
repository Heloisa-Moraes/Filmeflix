using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FilmeFlix.Models;
using System.Text.Json;

namespace FilmeFlix.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Filme> filmes = [];
        using (StreamReader leitor = new("Data\\filmes.json"))
        {
            string dados = leitor.ReadToEnd();
            filmes = JsonSerializer.Deserialize<List<Filme>>(dados);
        }
        return View(filmes);
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
