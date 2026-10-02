using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class DetalleReservasController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public DetalleReservasController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/DetalleReserva
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetalleReserva>>> GetDetalleReserva()
    {
        return await _context.DetalleReserva
            .Include(d => d.Reserva).ThenInclude(r => r.Cliente)
            .Include(d => d.Habitacion).ThenInclude(h => h.TipoHabitacion)
            .ToListAsync();
    }

    // GET: api/DetalleReserva/5
    [HttpGet("{iddetallereserva}")]
    public async Task<ActionResult<DetalleReserva>> GetDetalleReserva(int iddetallereserva)
    {
        var detallereserva = await _context.DetalleReserva
            .Include(d => d.Reserva).ThenInclude(r => r.Cliente)
            .Include(d => d.Habitacion).ThenInclude(h => h.TipoHabitacion)
            .FirstOrDefaultAsync(d => d.IdDetalleReserva == iddetallereserva);

        if (detallereserva == null)
        {
            return NotFound();
        }

        return detallereserva;
    }

    // PUT: api/DetalleReserva/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{iddetallereserva}")]
    public async Task<IActionResult> PutDetalleReserva(int? iddetallereserva, DetalleReserva detallereserva)
    {
        if (iddetallereserva != detallereserva.IdDetalleReserva)
        {
            return BadRequest();
        }

        _context.Entry(detallereserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DetalleReservaExists(iddetallereserva))
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

    // POST: api/DetalleReserva
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DetalleReserva>> PostDetalleReserva(DetalleReserva detallereserva)
    {
        _context.DetalleReserva.Add(detallereserva);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDetalleReserva", new { iddetallereserva = detallereserva.IdDetalleReserva }, detallereserva);
    }

    // DELETE: api/DetalleReserva/5
    [HttpDelete("{iddetallereserva}")]
    public async Task<IActionResult> DeleteDetalleReserva(int? iddetallereserva)
    {
        var detallereserva = await _context.DetalleReserva.FindAsync(iddetallereserva);
        if (detallereserva == null)
        {
            return NotFound();
        }

        _context.DetalleReserva.Remove(detallereserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DetalleReservaExists(int? iddetallereserva)
    {
        return _context.DetalleReserva.Any(e => e.IdDetalleReserva == iddetallereserva);
    }
}
