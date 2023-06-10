using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFilmeDatabaseFirstExemplo.Context;
using WebApiFilmeDatabaseFirstExemplo.DTO;
using WebApiFilmeDatabaseFirstExemplo.DTO.Response;
using WebApiFilmeDatabaseFirstExemplo.Models;

namespace WebApiFilmeDatabaseFirstExemplo.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FilmesDiretorController : ControllerBase
    {
        private readonly FilmeContext _context;

        public FilmesDiretorController(FilmeContext context)
        {
            _context = context;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.FilmeDiretores
                            .Include(x => x.Diretores)
                            .Include(x => x.Filme)
                            .ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Get(int id)
        {
            var filmesDiretor = await _context.FilmeDiretores
                            .Include(x => x.Diretores)
                            .Include(x => x.Filme)
                            .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (filmesDiretor is null)
            {
                return NotFound();
            }
            return Ok(filmesDiretor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FilmeDiretores>> PostFilmeDiretor([FromBody] FilmeDiretorDTO filmeDiretorDTO)
        {
            var configuration = new MapperConfiguration(
                cfg => cfg.CreateMap<FilmeDiretorDTO, FilmeDiretores>());

            var mapper = configuration.CreateMapper();

            FilmeDiretores filmeDiretores = mapper.Map<FilmeDiretores>(filmeDiretorDTO);

            _context.FilmeDiretores.Add(filmeDiretores);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = filmeDiretores.Id }, filmeDiretores);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] FilmeDiretores filmeDiretores)
        {
            bool existeFilmeDiretores = await _context.FilmeDiretores
                                                    .AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if (!existeFilmeDiretores)
            {
                return NotFound();
            }

            _context.Entry(filmeDiretores).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var filmeDiretores = await _context.FilmeDiretores
                                .Include(x => x.Filme)
                                .Include(x => x.Diretores)
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .ConfigureAwait(true);

            if (filmeDiretores is null)
            {
                return NotFound();
            }

            _context.FilmeDiretores.Remove(filmeDiretores);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
