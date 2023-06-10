using System.ComponentModel.DataAnnotations;

namespace WebApiFilmeDatabaseFirstExemplo.Models;

public class Diretores
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
    [MaxLength(200, ErrorMessage = "O campo Nome não pode exceder 200 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Telefone é de preenchimento obrigatório")]
    [MaxLength(30, ErrorMessage = "O campo Telefone não pode exceder 30 caracteres")]
    public string Telefone { get; set; }

}
