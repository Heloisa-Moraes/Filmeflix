
namespace FilmeFlix.Models;

public class Filme
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Duracao { get; set; }
    public string ClassificacaoIndicativa { get; set; }
    public List<string> Generos { get; set; }
}
