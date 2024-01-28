using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FrigobarController : ControllerBase
{
    private readonly Hotel _context;

    public FrigobarController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Frigobar>>> GetFrigobares()
    {
        return await _context.Frigobares.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Frigobar>> GetFrigobar(int id)
    {
        var frigobar = await _context.Frigobares.FindAsync(id);

        if (frigobar == null)
        {
            return NotFound();
        }

        return frigobar;
    }

    [HttpPost]
    public async Task<ActionResult<Frigobar>> PostFrigobar(Frigobar frigobar)
    {
        _context.Frigobares.Add(frigobar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFrigobar", new { id = frigobar.Codigo_Frigobar }, frigobar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFrigobar(int id, Frigobar frigobar)
    {
        if (id != frigobar.Codigo_Frigobar)
        {
            return BadRequest();
        }

        _context.Entry(frigobar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FrigobarExists(id))
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
    public async Task<IActionResult> DeleteFrigobar(int id)
    {
        var frigobar = await _context.Frigobares.FindAsync(id);
        if (frigobar == null)
        {
            return NotFound();
        }

        _context.Frigobares.Remove(frigobar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FrigobarExists(int id)
    {
        return _context.Frigobares.Any(e => e.Codigo_Frigobar == id);
    }
}
