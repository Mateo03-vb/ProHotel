using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class ConsumosController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public ConsumosController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/Consumo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consumo>>> GetConsumo()
    {
        return await _context.Consumo
            .Include(c => c.DetalleReserva).ThenInclude(d => d.Habitacion)
            .Include(c => c.DetalleReserva).ThenInclude(d => d.Reserva).ThenInclude(r => r.Cliente)
            .Include(c => c.Servicio)
            .ToListAsync();
    }

    // GET: api/Consumo/5
    [HttpGet("{idconsumo}")]
    public async Task<ActionResult<Consumo>> GetConsumo(int idconsumo)
    {
        var consumo = await _context.Consumo
            .Include(c => c.DetalleReserva).ThenInclude(d => d.Habitacion)
            .Include(c => c.DetalleReserva).ThenInclude(d => d.Reserva).ThenInclude(r => r.Cliente)
            .Include(c => c.Servicio)
            .FirstOrDefaultAsync(c => c.idConsumo == idconsumo);

        if (consumo == null)
        {
            return NotFound();
        }

        return consumo;
    }

    // PUT: api/Consumo/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idconsumo}")]
    public async Task<IActionResult> PutConsumo(int? idconsumo, Consumo consumo)
    {
        if (idconsumo != consumo.idConsumo)
        {
            return BadRequest();
        }

        _context.Entry(consumo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumoExists(idconsumo))
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

    // POST: api/Consumo
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Consumo>> PostConsumo(Consumo consumo)
    {
        _context.Consumo.Add(consumo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumo", new { idconsumo = consumo.idConsumo }, consumo);
    }

    // DELETE: api/Consumo/5
    [HttpDelete("{idconsumo}")]
    public async Task<IActionResult> DeleteConsumo(int? idconsumo)
    {
        var consumo = await _context.Consumo.FindAsync(idconsumo);
        if (consumo == null)
        {
            return NotFound();
        }

        _context.Consumo.Remove(consumo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumoExists(int? idconsumo)
    {
        return _context.Consumo.Any(e => e.idConsumo == idconsumo);
    }
}
