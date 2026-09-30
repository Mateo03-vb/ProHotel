using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class TipoHabitacionesController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public TipoHabitacionesController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/TipoHabitacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetTipoHabitacion()
    {
        return await _context.TipoHabitacion.ToListAsync();
    }

    // GET: api/TipoHabitacion/5
    [HttpGet("{idtipohabitacion}")]
    public async Task<ActionResult<TipoHabitacion>> GetTipoHabitacion(int idtipohabitacion)
    {
        var tipohabitacion = await _context.TipoHabitacion.FindAsync(idtipohabitacion);

        if (tipohabitacion == null)
        {
            return NotFound();
        }

        return tipohabitacion;
    }

    // PUT: api/TipoHabitacion/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idtipohabitacion}")]
    public async Task<IActionResult> PutTipoHabitacion(int? idtipohabitacion, TipoHabitacion tipohabitacion)
    {
        if (idtipohabitacion != tipohabitacion.idTipoHabitacion)
        {
            return BadRequest();
        }

        _context.Entry(tipohabitacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TipoHabitacionExists(idtipohabitacion))
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

    // POST: api/TipoHabitacion
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TipoHabitacion>> PostTipoHabitacion(TipoHabitacion tipohabitacion)
    {
        _context.TipoHabitacion.Add(tipohabitacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTipoHabitacion", new { idtipohabitacion = tipohabitacion.idTipoHabitacion }, tipohabitacion);
    }

    // DELETE: api/TipoHabitacion/5
    [HttpDelete("{idtipohabitacion}")]
    public async Task<IActionResult> DeleteTipoHabitacion(int? idtipohabitacion)
    {
        var tipohabitacion = await _context.TipoHabitacion.FindAsync(idtipohabitacion);
        if (tipohabitacion == null)
        {
            return NotFound();
        }

        _context.TipoHabitacion.Remove(tipohabitacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TipoHabitacionExists(int? idtipohabitacion)
    {
        return _context.TipoHabitacion.Any(e => e.idTipoHabitacion == idtipohabitacion);
    }
}
