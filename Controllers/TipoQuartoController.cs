using Hotel_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TipoQuartoController : ControllerBase
{
    private readonly Hotel _context;

    public TipoQuartoController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoQuarto>>> GetTipoQuartos()
    {
        return await _context.TipoQuartos.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<TipoQuarto>> GetTipoQuarto(int id)
    {
        var tipoQuarto = await _context.TipoQuartos.FindAsync(id);

        if (tipoQuarto == null)
        {
            return NotFound();
        }

        return tipoQuarto;
    }


    [HttpPost]
    public async Task<ActionResult<TipoQuarto>> PostTipoQuarto(TipoQuarto tipoQuarto)
    {
        _context.TipoQuartos.Add(tipoQuarto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTipoQuarto), new { id = tipoQuarto.Codigo_TipoQuarto }, tipoQuarto);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutTipoQuarto(int id, TipoQuarto tipoQuarto)
    {
        if (id != tipoQuarto.Codigo_TipoQuarto)
        {
            return BadRequest();
        }

        _context.Entry(tipoQuarto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TipoQuartoExists(id))
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
    public async Task<IActionResult> DeleteTipoQuarto(int id)
    {
        var tipoQuarto = await _context.TipoQuartos.FindAsync(id);
        if (tipoQuarto == null)
        {
            return NotFound();
        }

        _context.TipoQuartos.Remove(tipoQuarto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TipoQuartoExists(int id)
    {
        return _context.TipoQuartos.Any(e => e.Codigo_TipoQuarto == id);
    }
}
