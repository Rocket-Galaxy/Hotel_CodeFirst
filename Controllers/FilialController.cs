using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;

[Route("api/[controller]")]
[ApiController]
public class FilialController : ControllerBase
{
    private readonly Hotel _context;

    public FilialController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Filial>>> GetFiliais()
    {
        return await _context.Filiais.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Filial>> GetFilial(int id)
    {
        var filial = await _context.Filiais.FindAsync(id);

        if (filial == null)
        {
            return NotFound();
        }

        return filial;
    }

    [HttpPost]
    public async Task<ActionResult<Filial>> PostFilial(Filial filial)
    {
        _context.Filiais.Add(filial);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFilial", new { id = filial.Codigo_Filial }, filial);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFilial(int id, Filial filial)
    {
        if (id != filial.Codigo_Filial)
        {
            return BadRequest();
        }

        _context.Entry(filial).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FilialExists(id))
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
    public async Task<ActionResult<Filial>> DeleteFilial(int id)
    {
        var filial = await _context.Filiais.FindAsync(id);

        if (filial == null)
        {
            return NotFound();
        }

        _context.Filiais.Remove(filial);
        await _context.SaveChangesAsync();

        return filial;
    }


    private bool FilialExists(int id)
    {
        return _context.Filiais.Any(e => e.Codigo_Filial == id);
    }
}
