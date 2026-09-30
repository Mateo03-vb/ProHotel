using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class ReservasController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public ReservasController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/Reserva
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
    {
        return await _context.Reserva.ToListAsync();
    }

    // GET: api/Reserva/5
    [HttpGet("{idreserva}")]
    public async Task<ActionResult<Reserva>> GetReserva(int idreserva)
    {
        var reserva = await _context.Reserva.FindAsync(idreserva);

        if (reserva == null)
        {
            return NotFound();
        }

        return reserva;
    }

    // PUT: api/Reserva/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idreserva}")]
    public async Task<IActionResult> PutReserva(int? idreserva, Reserva reserva)
    {
        if (idreserva != reserva.idReserva)
        {
            return BadRequest();
        }

        _context.Entry(reserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReservaExists(idreserva))
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

    // POST: api/Reserva
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
    {
        _context.Reserva.Add(reserva);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReserva", new { idreserva = reserva.idReserva }, reserva);
    }

    // DELETE: api/Reserva/5
    [HttpDelete("{idreserva}")]
    public async Task<IActionResult> DeleteReserva(int? idreserva)
    {
        var reserva = await _context.Reserva.FindAsync(idreserva);
        if (reserva == null)
        {
            return NotFound();
        }

        _context.Reserva.Remove(reserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReservaExists(int? idreserva)
    {
        return _context.Reserva.Any(e => e.idReserva == idreserva);
    }
}
