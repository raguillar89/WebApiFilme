using Microsoft.EntityFrameworkCore;
using WebApiFilmeDatabaseFirstExemplo.Models;

namespace WebApiFilmeDatabaseFirstExemplo.Context
{
    public class FilmeContext : DbContext
    {
        public FilmeContext() { }

        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) { }

        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Diretores> Diretores { get; set; }
        public virtual DbSet<FilmeDiretores> FilmeDiretores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
    }
}