using FilmeFlix.Models;

namespace FilmeFlix.Models;

public class DetailsVM
{
    public Filme Anterior { get; set; }
    public Filme Atual { get; set; }
    public Filme Proximo { get; set; }
    public List<Genero> Generos { get; set; }
}