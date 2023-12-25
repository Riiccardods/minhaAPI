using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minhaAPI.Data;
using minhaAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace minhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Nomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nome>>> GetNomes()
        {
            return await _context.Nomes.ToListAsync();
        }

        // GET: api/Nomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nome>> GetNome(int id)
        {
            var nome = await _context.Nomes.FindAsync(id);

            if (nome == null)
            {
                return NotFound();
            }

            return nome;
        }

        // POST: api/Nomes
        [HttpPost]
        public async Task<ActionResult<Nome>> PostNome(Nome nome)
        {
            _context.Nomes.Add(nome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNome", new { id = nome.Id }, nome);
        }

        // PUT: api/Nomes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNome(int id, Nome nome)
        {
            if (id != nome.Id)
            {
                return BadRequest();
            }

            _context.Entry(nome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Nomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNome(int id)
        {
            var nome = await _context.Nomes.FindAsync(id);
            if (nome == null)
            {
                return NotFound();
            }

            _context.Nomes.Remove(nome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NomeExists(int id)
        {
            return _context.Nomes.Any(e => e.Id == id);
        }
    }
}
