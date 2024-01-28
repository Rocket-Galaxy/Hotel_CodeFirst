using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ConsumoRestauranteController : ControllerBase
{
    private readonly Hotel _context;

    public ConsumoRestauranteController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsumoRestaurante>>> GetConsumoRestaurantes()
    {
        return await _context.ConsumoRestaurantes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConsumoRestaurante>> GetConsumoRestaurante(int id)
    {
        var consumoRestaurante = await _context.ConsumoRestaurantes.FindAsync(id);

        if (consumoRestaurante == null)
        {
            return NotFound();
        }

        return consumoRestaurante;
    }

    [HttpPost]
    public async Task<ActionResult<ConsumoRestaurante>> PostConsumoRestaurante(ConsumoRestaurante consumoRestaurante)
    {
        _context.ConsumoRestaurantes.Add(consumoRestaurante);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumoRestaurante", new { id = consumoRestaurante.Codigo_ConsumoRestaurante }, consumoRestaurante);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsumoRestaurante(int id, ConsumoRestaurante consumoRestaurante)
    {
        if (id != consumoRestaurante.Codigo_ConsumoRestaurante)
        {
            return BadRequest();
        }

        _context.Entry(consumoRestaurante).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumoRestauranteExists(id))
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
    public async Task<IActionResult> DeleteConsumoRestaurante(int id)
    {
        var consumoRestaurante = await _context.ConsumoRestaurantes.FindAsync(id);
        if (consumoRestaurante == null)
        {
            return NotFound();
        }

        _context.ConsumoRestaurantes.Remove(consumoRestaurante);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumoRestauranteExists(int id)
    {
        return _context.ConsumoRestaurantes.Any(e => e.Codigo_ConsumoRestaurante == id);
    }
}
