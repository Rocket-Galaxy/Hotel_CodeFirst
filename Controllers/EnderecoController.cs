using Hotel_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly Hotel _context;

    public EnderecoController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
    {
        return await _context.Enderecos.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Endereco>> GetEndereco(int id)
    {
        var Endereco = await _context.Enderecos.FindAsync(id);

        if (Endereco == null)
        {
            return NotFound();
        }

        return Endereco;
    }


    [HttpPost]
    public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Codigo_Endereco }, endereco);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
    {
        if (id != endereco.Codigo_Endereco)
        {
            return BadRequest();
        }

        _context.Entry(endereco).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EnderecoExists(id))
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
    public async Task<IActionResult> DeleteEndereco(int id)
    {
        var endereco = await _context.Enderecos.FindAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }

        _context.Enderecos.Remove(endereco);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EnderecoExists(int id)
    {
        return _context.Enderecos.Any(e => e.Codigo_Endereco == id);
    }
}
