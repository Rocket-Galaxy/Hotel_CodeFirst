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
    public class QuartoController : ControllerBase
    {
        private readonly Hotel _context;

        public QuartoController(Hotel context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuarto()
        {
            return await _context.Quartos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
        {
            _context.Quartos.Add(quarto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuarto), new { id = quarto.Numero_Quarto }, quarto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuarto(int id, Quarto quarto)
        {
            if (id != quarto.Numero_Quarto)
            {
                return BadRequest();
            }

            _context.Entry(quarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuartoExists(id))
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
        public async Task<IActionResult> DeleteQuarto(int id)
        {
            var Quarto = await _context.Quartos.FindAsync(id);
            if (Quarto == null)
            {
                return NotFound();
            }

            _context.Quartos.Remove(Quarto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuartoExists(int id)
        {
            return _context.Quartos.Any(e => e.Numero_Quarto == id);
        }

    }
}
