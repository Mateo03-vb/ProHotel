using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class PagosController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public PagosController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/Pago
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pago>>> GetPago()
    {
        return await _context.Pago
            .Include(p => p.Reserva).ThenInclude(r => r.Cliente)
            .ToListAsync();
    }

    // GET: api/Pago/5
    [HttpGet("{idpago}")]
    public async Task<ActionResult<Pago>> GetPago(int idpago)
    {
        var pago = await _context.Pago
            .Include(p => p.Reserva).ThenInclude(r => r.Cliente)
            .FirstOrDefaultAsync(p => p.idPago == idpago);

        if (pago == null)
        {
            return NotFound();
        }

        return pago;
    }

    // PUT: api/Pago/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idpago}")]
    public async Task<IActionResult> PutPago(int? idpago, Pago pago)
    {
        if (idpago != pago.idPago)
        {
            return BadRequest();
        }

        _context.Entry(pago).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PagoExists(idpago))
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

    // POST: api/Pago
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Pago>> PostPago(Pago pago)
    {
        _context.Pago.Add(pago);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPago", new { idpago = pago.idPago }, pago);
    }

    // DELETE: api/Pago/5
    [HttpDelete("{idpago}")]
    public async Task<IActionResult> DeletePago(int? idpago)
    {
        var pago = await _context.Pago.FindAsync(idpago);
        if (pago == null)
        {
            return NotFound();
        }

        _context.Pago.Remove(pago);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PagoExists(int? idpago)
    {
        return _context.Pago.Any(e => e.idPago == idpago);
    }
}
