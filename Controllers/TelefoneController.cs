using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_CodeFirst.Models;

namespace Hotel_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly Hotel _context;

        public TelefoneController(Hotel context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone()
        {
            return await _context.Telefones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);

            if (telefone == null)
            {
                return NotFound();
            }

            return telefone;
        }

        [HttpPost]
        public async Task<ActionResult<Telefone>> PostCliente(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTelefone), new { id = telefone.Codigo_Cliente }, telefone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefone(int id, Telefone telefone)
        {
            if (id != telefone.Codigo_Telefone)
            {
                return BadRequest();
            }

            _context.Entry(telefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }

            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefones.Any(e => e.Codigo_Telefone == id);
        }
    }
}
