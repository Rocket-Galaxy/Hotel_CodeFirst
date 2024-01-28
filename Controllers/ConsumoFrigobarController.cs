using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ConsumoFrigobarController : ControllerBase
{
    private readonly Hotel _context;

    public ConsumoFrigobarController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsumoFrigobar>>> GetConsumoFrigobares()
    {
        return await _context.ConsumoFrigobares.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConsumoFrigobar>> GetConsumoFrigobar(int id)
    {
        var consumoFrigobar = await _context.ConsumoFrigobares.FindAsync(id);

        if (consumoFrigobar == null)
        {
            return NotFound();
        }

        return consumoFrigobar;
    }

    [HttpPost]
    public async Task<ActionResult<ConsumoFrigobar>> PostConsumoFrigobar(ConsumoFrigobar consumoFrigobar)
    {
        _context.ConsumoFrigobares.Add(consumoFrigobar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumoFrigobar", new { id = consumoFrigobar.Codigo_ConsumoFrigobar }, consumoFrigobar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsumoFrigobar(int id, ConsumoFrigobar consumoFrigobar)
    {
        if (id != consumoFrigobar.Codigo_ConsumoFrigobar)
        {
            return BadRequest();
        }

        _context.Entry(consumoFrigobar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumoFrigobarExists(id))
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
    public async Task<IActionResult> DeleteConsumoFrigobar(int id)
    {
        var consumoFrigobar = await _context.ConsumoFrigobares.FindAsync(id);
        if (consumoFrigobar == null)
        {
            return NotFound();
        }

        _context.ConsumoFrigobares.Remove(consumoFrigobar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumoFrigobarExists(int id)
    {
        return _context.ConsumoFrigobares.Any(e => e.Codigo_ConsumoFrigobar == id);
    }
}
