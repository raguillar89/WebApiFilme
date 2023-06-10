using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFilmeDatabaseFirstExemplo.Context;
using WebApiFilmeDatabaseFirstExemplo.Models;

namespace WebApiFilmeDatabaseFirstExemplo.Controllers
{
    [Route("api/v{version:apiVersion}/diretores")]
    [ApiController]
    public class DiretoresController : ControllerBase
    {
        private readonly FilmeContext _diretorContext;

        public DiretoresController(FilmeContext context)
        {
            _diretorContext = context;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _diretorContext.Diretores.ToListAsync().ConfigureAwait(true));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var diretor = await _diretorContext.Diretores.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (diretor is null)
            {
                return NotFound();
            }
            return Ok(diretor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Diretores diretores)
        {
            _diretorContext.Diretores.Add(diretores);

            await _diretorContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = diretores.Id }, diretores);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Diretores diretores)
        {
            bool existeDiretor = await _diretorContext.Diretores.AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if (!existeDiretor)
            {
                return NotFound();
            }

            _diretorContext.Entry(diretores).State = EntityState.Modified;
            await _diretorContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var diretores = await _diretorContext.Diretores
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .ConfigureAwait(true);

            if (diretores is null)
            {
                return NotFound();
            }

            _diretorContext.Diretores.Remove(diretores);

            await _diretorContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
