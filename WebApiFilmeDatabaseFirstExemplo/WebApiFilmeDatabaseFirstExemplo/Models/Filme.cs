using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFilmeDatabaseFirstExemplo.Models;

public partial class Filme
{
    public int FilmeId { get; set; }

    public string FilmeName { get; set; }

    public string Diretor { get; set; }

    public string Genero { get; set; }

    public int Duracao { get; set; }
}
