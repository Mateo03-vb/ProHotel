using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class HabitacionesController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public HabitacionesController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/Habitacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitacion()
    {
        return await _context.Habitacion.ToListAsync();
    }

    // GET: api/Habitacion/5
    [HttpGet("{idhabitacion}")]
    public async Task<ActionResult<Habitacion>> GetHabitacion(int idhabitacion)
    {
        var habitacion = await _context.Habitacion.FindAsync(idhabitacion);

        if (habitacion == null)
        {
            return NotFound();
        }

        return habitacion;
    }

    // PUT: api/Habitacion/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idhabitacion}")]
    public async Task<IActionResult> PutHabitacion(int? idhabitacion, Habitacion habitacion)
    {
        if (idhabitacion != habitacion.idHabitacion)
        {
            return BadRequest();
        }

        _context.Entry(habitacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HabitacionExists(idhabitacion))
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

    // POST: api/Habitacion
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Habitacion>> PostHabitacion(Habitacion habitacion)
    {
        _context.Habitacion.Add(habitacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHabitacion", new { idhabitacion = habitacion.idHabitacion }, habitacion);
    }

    // DELETE: api/Habitacion/5
    [HttpDelete("{idhabitacion}")]
    public async Task<IActionResult> DeleteHabitacion(int? idhabitacion)
    {
        var habitacion = await _context.Habitacion.FindAsync(idhabitacion);
        if (habitacion == null)
        {
            return NotFound();
        }

        _context.Habitacion.Remove(habitacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HabitacionExists(int? idhabitacion)
    {
        return _context.Habitacion.Any(e => e.idHabitacion == idhabitacion);
    }
}
