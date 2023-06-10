using Microsoft.Build.Framework;

namespace WebApiFilmeDatabaseFirstExemplo.DTO
{
    public class FilmeDiretorDTO
    {
        [Required]
        public int FilmeId { get; set; }

        [Required]
        public int DiretorId { get; set; }
    }
}
