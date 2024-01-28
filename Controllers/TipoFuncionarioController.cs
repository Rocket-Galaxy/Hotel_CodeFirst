using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TipoFuncionarioController : ControllerBase
{
    private readonly Hotel _context;

    public TipoFuncionarioController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoFuncionario>>> GetTipoFuncionarios()
    {
        return await _context.TipoFuncionarios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoFuncionario>> GetTipoFuncionario(int id)
    {
        var tipoFuncionario = await _context.TipoFuncionarios.FindAsync(id);

        if (tipoFuncionario == null)
        {
            return NotFound();
        }

        return tipoFuncionario;
    }

    [HttpPost]
    public async Task<ActionResult<TipoFuncionario>> PostTipoFuncionario(TipoFuncionario tipoFuncionario)
    {
        _context.TipoFuncionarios.Add(tipoFuncionario);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTipoFuncionario", new { id = tipoFuncionario.Codigo_TipoFuncionario }, tipoFuncionario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTipoFuncionario(int id, TipoFuncionario tipoFuncionario)
    {
        if (id != tipoFuncionario.Codigo_TipoFuncionario)
        {
            return BadRequest();
        }

        _context.Entry(tipoFuncionario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TipoFuncionarioExists(id))
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
    public async Task<IActionResult> DeleteTipoFuncionario(int id)
    {
        var tipoFuncionario = await _context.TipoFuncionarios.FindAsync(id);
        if (tipoFuncionario == null)
        {
            return NotFound();
        }

        _context.TipoFuncionarios.Remove(tipoFuncionario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TipoFuncionarioExists(int id)
    {
        return _context.TipoFuncionarios.Any(e => e.Codigo_TipoFuncionario == id);
    }
}
