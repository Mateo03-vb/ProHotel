using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class ServiciosController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public ServiciosController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/Servicio
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servicio>>> GetServicio()
    {
        return await _context.Servicio.ToListAsync();
    }

    // GET: api/Servicio/5
    [HttpGet("{idservicio}")]
    public async Task<ActionResult<Servicio>> GetServicio(int idservicio)
    {
        var servicio = await _context.Servicio.FindAsync(idservicio);

        if (servicio == null)
        {
            return NotFound();
        }

        return servicio;
    }

    // PUT: api/Servicio/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idservicio}")]
    public async Task<IActionResult> PutServicio(int? idservicio, Servicio servicio)
    {
        if (idservicio != servicio.idServicio)
        {
            return BadRequest();
        }

        _context.Entry(servicio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServicioExists(idservicio))
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

    // POST: api/Servicio
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
    {
        _context.Servicio.Add(servicio);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetServicio", new { idservicio = servicio.idServicio }, servicio);
    }

    // DELETE: api/Servicio/5
    [HttpDelete("{idservicio}")]
    public async Task<IActionResult> DeleteServicio(int? idservicio)
    {
        var servicio = await _context.Servicio.FindAsync(idservicio);
        if (servicio == null)
        {
            return NotFound();
        }

        _context.Servicio.Remove(servicio);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServicioExists(int? idservicio)
    {
        return _context.Servicio.Any(e => e.idServicio == idservicio);
    }
}
