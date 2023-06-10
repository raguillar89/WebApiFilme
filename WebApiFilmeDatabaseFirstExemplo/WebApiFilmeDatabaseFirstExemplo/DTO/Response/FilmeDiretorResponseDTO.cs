using System.ComponentModel.DataAnnotations.Schema;
using WebApiFilmeDatabaseFirstExemplo.Models;

namespace WebApiFilmeDatabaseFirstExemplo.DTO.Response
{
    public class FilmeDiretorResponseDTO
    {
        [ForeignKey("Filme")]
        public int IdFilme { get; set; }

        [ForeignKey("Diretores")]
        public int IdDiretor { get; set; }

        public virtual Diretores? Diretores { get; set; }
        public virtual Filme? Filme { get; set; }
    }
}
