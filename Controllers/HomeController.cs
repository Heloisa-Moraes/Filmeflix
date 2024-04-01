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

        List<Genero> generos = [];             //modificamos aqui 01/04 //
        using (StreamReader leitor = new("Data\\generos.json"))
        {
            string dados = leitor.ReadToEnd();
            generos = JsonSerializer.Deserialize<List<Genero>>(dados);
        }      
         ViewData["Generos"] = generos;                                   // até aq 01/04//
        return View(filmes);
    }
    public IActionResult Details(int id)
    {
        List<Filme> filmes = [];
        using (StreamReader leitor = new("Data\\filmes.json"))
        {
            string dados = leitor.ReadToEnd();
            filmes = JsonSerializer.Deserialize<List<Filme>>(dados);
        }
        List<Genero> generos = [];
        using (StreamReader leitor = new("Data\\generos.json"))
        {
            string dados = leitor.ReadToEnd();
            generos = JsonSerializer.Deserialize<List<Genero>>(dados);
        }
        ViewData["Generos"] = generos;
        var filme = filmes
            .Where(p => p.Id == id)
            .FirstOrDefault();
        return View(filme);
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
