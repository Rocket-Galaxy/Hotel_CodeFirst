using Hotel_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TipoPagamentoController : ControllerBase
{
    private readonly Hotel _context;

    public TipoPagamentoController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoPagamento>>> GetTipoPagamento()
    {
        return await _context.TipoPagementos.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<TipoPagamento>> GetTipoPagamento(int id)
    {
        var tipoPagamento = await _context.TipoPagementos.FindAsync(id);

        if (tipoPagamento == null)
        {
            return NotFound();
        }

        return tipoPagamento;
    }


    [HttpPost]
    public async Task<ActionResult<TipoPagamento>> PostTipoPagamento(TipoPagamento tipoPagamento)
    {
        _context.TipoPagementos.Add(tipoPagamento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTipoPagamento), new { id = tipoPagamento.Codigo_TipoPagamento }, tipoPagamento);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutTipoPagamento(int id, TipoPagamento tipoPagamento)
    {
        if (id != tipoPagamento.Codigo_TipoPagamento)
        {
            return BadRequest();
        }

        _context.Entry(tipoPagamento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TipoPagamentoExists(id))
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
        var tipoPagamento = await _context.TipoPagementos.FindAsync(id);
        if (tipoPagamento == null)
        {
            return NotFound();
        }

        _context.TipoPagementos.Remove(tipoPagamento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TipoPagamentoExists(int id)
    {
        return _context.TipoPagementos.Any(e => e.Codigo_TipoPagamento == id);
    }
}
