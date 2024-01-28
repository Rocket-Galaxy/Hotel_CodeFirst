using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ConsumoLavanderiaController : ControllerBase
{
    private readonly Hotel _context;

    public ConsumoLavanderiaController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsumoLavanderia>>> GetConsumosLavanderia()
    {
        return await _context.ConsumosLavanderia.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConsumoLavanderia>> GetConsumoLavanderia(int id)
    {
        var consumoLavanderia = await _context.ConsumosLavanderia.FindAsync(id);

        if (consumoLavanderia == null)
        {
            return NotFound();
        }

        return consumoLavanderia;
    }

    [HttpPost]
    public async Task<ActionResult<ConsumoLavanderia>> PostConsumoLavanderia(ConsumoLavanderia consumoLavanderia)
    {
        _context.ConsumosLavanderia.Add(consumoLavanderia);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumoLavanderia", new { id = consumoLavanderia.Codigo_ConsumoLavanderia }, consumoLavanderia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsumoLavanderia(int id, ConsumoLavanderia consumoLavanderia)
    {
        if (id != consumoLavanderia.Codigo_ConsumoLavanderia)
        {
            return BadRequest();
        }

        _context.Entry(consumoLavanderia).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumoLavanderiaExists(id))
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
    public async Task<IActionResult> DeleteConsumoLavanderia(int id)
    {
        var consumoLavanderia = await _context.ConsumosLavanderia.FindAsync(id);
        if (consumoLavanderia == null)
        {
            return NotFound();
        }

        _context.ConsumosLavanderia.Remove(consumoLavanderia);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumoLavanderiaExists(int id)
    {
        return _context.ConsumosLavanderia.Any(e => e.Codigo_ConsumoLavanderia == id);
    }
}
