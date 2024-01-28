using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly Hotel _context;

    public FuncionarioController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);

        if (funcionario == null)
        {
            return NotFound();
        }

        return funcionario;
    }

    [HttpPost]
    public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFuncionario", new { id = funcionario.Codigo_Funcionario }, funcionario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFuncionario(int id, Funcionario funcionario)
    {
        if (id != funcionario.Codigo_Funcionario)
        {
            return BadRequest();
        }

        _context.Entry(funcionario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FuncionarioExists(id))
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
    public async Task<IActionResult> DeleteFuncionario(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario == null)
        {
            return NotFound();
        }

        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FuncionarioExists(int id)
    {
        return _context.Funcionarios.Any(e => e.Codigo_Funcionario == id);
    }
}
