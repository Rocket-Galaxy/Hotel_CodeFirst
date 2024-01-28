using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NotaFiscalController : ControllerBase
{
    private readonly Hotel _context;

    public NotaFiscalController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotaFiscal>>> GetNotaFiscais()
    {
        return await _context.NotaFiscais.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NotaFiscal>> GetNotaFiscal(int id)
    {
        var notaFiscal = await _context.NotaFiscais.FindAsync(id);

        if (notaFiscal == null)
        {
            return NotFound();
        }

        return notaFiscal;
    }

    [HttpPost]
    public async Task<ActionResult<NotaFiscal>> PostNotaFiscal(NotaFiscal notaFiscal)
    {
        _context.NotaFiscais.Add(notaFiscal);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetNotaFiscal", new { id = notaFiscal.Codigo_NotaFiscal }, notaFiscal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutNotaFiscal(int id, NotaFiscal notaFiscal)
    {
        if (id != notaFiscal.Codigo_NotaFiscal)
        {
            return BadRequest();
        }

        _context.Entry(notaFiscal).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NotaFiscalExists(id))
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

    [HttpPut("{id}/consumos")]
    public async Task<IActionResult> PutConsumos(int id)
    {
        // Buscar a conta reserva
        var notaFiscal = await _context.NotaFiscais
            .FirstOrDefaultAsync(c => c.Codigo_NotaFiscal == id);

        if (notaFiscal == null)
        {
            return NotFound();
        }

        // Consultar os consumos diretamente no contexto
        var valorNotaFiscal = await _context.ContasReserva
            .Where(cf => cf.Codigo_ContaReserva == id)
            .Select(cf => new
            {
                valor = cf.ValorGasto_ContaReserva
            })
            .FirstOrDefaultAsync();

        decimal valorTotal = 0;
        valorTotal = valorNotaFiscal.valor;

        notaFiscal.ValorTotal_NotaFiscal = valorTotal;
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotaFiscal(int id)
    {
        var notaFiscal = await _context.NotaFiscais.FindAsync(id);
        if (notaFiscal == null)
        {
            return NotFound();
        }

        _context.NotaFiscais.Remove(notaFiscal);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NotaFiscalExists(int id)
    {
        return _context.NotaFiscais.Any(e => e.Codigo_NotaFiscal == id);
    }
}
