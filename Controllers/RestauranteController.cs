using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase
{
    private readonly Hotel _context;

    public RestauranteController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurantes()
    {
        return await _context.Restaurantes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
    {
        var restaurante = await _context.Restaurantes.FindAsync(id);

        if (restaurante == null)
        {
            return NotFound();
        }

        return restaurante;
    }

    [HttpPost]
    public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
    {
        _context.Restaurantes.Add(restaurante);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRestaurante", new { id = restaurante.Codigo_Restaurante }, restaurante);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRestaurante(int id, Restaurante restaurante)
    {
        if (id != restaurante.Codigo_Restaurante)
        {
            return BadRequest();
        }

        _context.Entry(restaurante).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RestauranteExists(id))
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
    public async Task<IActionResult> DeleteRestaurante(int id)
    {
        var restaurante = await _context.Restaurantes.FindAsync(id);
        if (restaurante == null)
        {
            return NotFound();
        }

        _context.Restaurantes.Remove(restaurante);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RestauranteExists(int id)
    {
        return _context.Restaurantes.Any(e => e.Codigo_Restaurante == id);
    }
}
