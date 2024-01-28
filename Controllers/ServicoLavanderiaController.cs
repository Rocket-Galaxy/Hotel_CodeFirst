using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ServicoLavanderiaController : ControllerBase
{
    private readonly Hotel _context;

    public ServicoLavanderiaController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServicoLavanderia>>> GetServicosLavanderia()
    {
        return await _context.ServicosLavanderia.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServicoLavanderia>> GetServicoLavanderia(int id)
    {
        var servicoLavanderia = await _context.ServicosLavanderia.FindAsync(id);

        if (servicoLavanderia == null)
        {
            return NotFound();
        }

        return servicoLavanderia;
    }

    [HttpPost]
    public async Task<ActionResult<ServicoLavanderia>> PostServicoLavanderia(ServicoLavanderia servicoLavanderia)
    {
        _context.ServicosLavanderia.Add(servicoLavanderia);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetServicoLavanderia", new { id = servicoLavanderia.Codigo_ServicoLavanderia }, servicoLavanderia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutServicoLavanderia(int id, ServicoLavanderia servicoLavanderia)
    {
        if (id != servicoLavanderia.Codigo_ServicoLavanderia)
        {
            return BadRequest();
        }

        _context.Entry(servicoLavanderia).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServicoLavanderiaExists(id))
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
    public async Task<IActionResult> DeleteServicoLavanderia(int id)
    {
        var servicoLavanderia = await _context.ServicosLavanderia.FindAsync(id);
        if (servicoLavanderia == null)
        {
            return NotFound();
        }

        _context.ServicosLavanderia.Remove(servicoLavanderia);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServicoLavanderiaExists(int id)
    {
        return _context.ServicosLavanderia.Any(e => e.Codigo_ServicoLavanderia == id);
    }
}
