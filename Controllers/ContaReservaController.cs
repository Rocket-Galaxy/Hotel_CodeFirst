using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ContaReservaController : ControllerBase
{
    private readonly Hotel _context;

    public ContaReservaController(Hotel context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContaReserva>>> GetContasReserva()
    {
        return await _context.ContasReserva.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContaReserva>> GetContaReserva(int id)
    {
        var contaReserva = await _context.ContasReserva.FindAsync(id);

        if (contaReserva == null)
        {
            return NotFound();
        }

        return contaReserva;
    }

 
  [HttpGet("{id}/consumos")]
    public async Task<ActionResult<IEnumerable<object>>> GetConsumosContaTotal(int id)
    {
        // Buscar a conta reserva
        var contaReserva = await _context.ContasReserva
            .FirstOrDefaultAsync(c => c.Codigo_ContaReserva == id);

        if (contaReserva == null)
        {
            return NotFound();
        }

        // Consultar os consumos diretamente no contexto
        var consumosFrigobar = await _context.ConsumoFrigobares
            .Where(cf => cf.Codigo_ContaReserva == id)
            .Select(cf => new
            {
                Tipo = "Frigobar",
                Item = cf.Codigo_ConsumoFrigobar, 
                quantidade = cf.Quantidade
            })
            .ToListAsync();

        var consumosLavanderia = await _context.ConsumosLavanderia
            .Where(cl => cl.Codigo_ContaReserva == id)
            .Select(cl => new
            {
                Tipo = "Lavanderia",
                Item = cl.Codigo_ConsumoLavanderia, 
                quantidade = cl.Quantidade
            })
            .ToListAsync();

        var consumosRestaurante = await _context.ConsumoRestaurantes
            .Where(cr => cr.Codigo_ContaReserva == id)
            .Select(cr => new
            {
                Tipo = "Restaurante",
                Item = cr.Codigo_ConsumoRestaurante, 
                quantidade = cr.Quantidade

            })
            .ToListAsync();

    var consumosDetails = consumosFrigobar
        .AsEnumerable()
        .Concat(consumosLavanderia.AsEnumerable())
        .Concat(consumosRestaurante.AsEnumerable())
        .ToList();

        return Ok(consumosDetails);
    }

    [HttpPost]
    public async Task<ActionResult<ContaReserva>> PostContaReserva(ContaReserva contaReserva)
    {
        _context.ContasReserva.Add(contaReserva);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetContaReserva", new { id = contaReserva.Codigo_ContaReserva }, contaReserva);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutContaReserva(int id, ContaReserva contaReserva)
    {
        if (id != contaReserva.Codigo_ContaReserva)
        {
            return BadRequest();
        }

        _context.Entry(contaReserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContaReservaExists(id))
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
    public async Task<IActionResult> PutConsumosContaReserva(int id)
    {
        // Buscar a conta reserva
        var contaReserva = await _context.ContasReserva
            .FirstOrDefaultAsync(c => c.Codigo_ContaReserva == id);

        if (contaReserva == null)
        {
            return NotFound();
        }

        // Consultar os consumos diretamente no contexto
        var consumosFrigobar = await _context.ConsumoFrigobares
            .Where(cf => cf.Codigo_ContaReserva == id)
            .Select(cf => new
            {
                Tipo = "Frigobar",
                Item = cf.Codigo_Frigobar,
                Quantidade = cf.Quantidade
            })
            .ToListAsync();

        var consumosLavanderia = await _context.ConsumosLavanderia
            .Where(cl => cl.Codigo_ContaReserva == id)
            .Select(cl => new
            {
                Tipo = "Lavanderia",
                Item = cl.Codigo_ServicoLavanderia,
                Quantidade = cl.Quantidade
            })
            .ToListAsync();

        var consumosRestaurante = await _context.ConsumoRestaurantes
            .Where(cr => cr.Codigo_ContaReserva == id)
            .Select(cr => new
            {
                Tipo = "Restaurante",
                Item = cr.Codigo_Restaurante,
                Quantidade = cr.Quantidade
            })
            .ToListAsync();

        // Combine os resultados das consultas
        var consumosDetails = consumosFrigobar
            .AsEnumerable()
            .Concat(consumosLavanderia.AsEnumerable())
            .Concat(consumosRestaurante.AsEnumerable())
            .ToList();

        // Calcular o valor total dos consumos
        decimal valorTotal = 0;

        foreach (var consumo in consumosDetails)
        {
            decimal precoItem = 0;

            switch (consumo.Tipo)
            {
                case "Frigobar":
                    precoItem = await _context.Frigobares
                        .Where(f => f.Codigo_Frigobar == consumo.Item)
                        .Select(f => f.Preco_ItemFrigobar)
                        .FirstOrDefaultAsync();
                    break;

                case "Lavanderia":
                    precoItem = await _context.ServicosLavanderia
                        .Where(sl => sl.Codigo_ServicoLavanderia == consumo.Item)
                        .Select(sl => sl.Preco_ServicoLavanderia)
                        .FirstOrDefaultAsync();
                    break;

                case "Restaurante":
                    precoItem = await _context.Restaurantes
                        .Where(r => r.Codigo_Restaurante == consumo.Item)
                        .Select(r => r.Preco_ItemMenu)
                        .FirstOrDefaultAsync();
                    break;
            }

            valorTotal += precoItem * consumo.Quantidade;
        }

        var quarto = await _context.Reservas
            .Where(f => f.Codigo_ContaReserva == id)
            .Select(f => f.Numero_Quarto)
            .FirstOrDefaultAsync();


        var buscaValorQuarto = await _context.Quartos
            .Where(f => f.Numero_Quarto == quarto)
            .Select(f => f.Codigo_TipoQuarto)
            .FirstOrDefaultAsync();

        var ValorQuarto = await _context.TipoQuartos
            .Where(f => f.Codigo_TipoQuarto == buscaValorQuarto)
            .Select(f => f.Valor_TipoQuarto)
            .FirstOrDefaultAsync();


        valorTotal += ValorQuarto;
        // Atualizar o valor gasto na tabela ContaReserva
        contaReserva.ValorGasto_ContaReserva = valorTotal;
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContaReserva(int id)
    {
        var contaReserva = await _context.ContasReserva.FindAsync(id);
        if (contaReserva == null)
        {
            return NotFound();
        }

        _context.ContasReserva.Remove(contaReserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContaReservaExists(int id)
    {
        return _context.ContasReserva.Any(e => e.Codigo_ContaReserva == id);
    }
}
