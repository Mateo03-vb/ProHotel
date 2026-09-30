using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Modelos;

[Route("api/[controller]")]
[ApiController]
public class EmpleadosController : ControllerBase
{
    private readonly ProHotelAPIContext _context;
    public EmpleadosController(ProHotelAPIContext context)
    {
        _context = context;
    }

    // GET: api/Empleado
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
    {
        return await _context.Empleado.ToListAsync();
    }

    // GET: api/Empleado/5
    [HttpGet("{idempleado}")]
    public async Task<ActionResult<Empleado>> GetEmpleado(int idempleado)
    {
        var empleado = await _context.Empleado.FindAsync(idempleado);

        if (empleado == null)
        {
            return NotFound();
        }

        return empleado;
    }

    // PUT: api/Empleado/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idempleado}")]
    public async Task<IActionResult> PutEmpleado(int? idempleado, Empleado empleado)
    {
        if (idempleado != empleado.idEmpleado)
        {
            return BadRequest();
        }

        _context.Entry(empleado).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmpleadoExists(idempleado))
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

    // POST: api/Empleado
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
    {
        _context.Empleado.Add(empleado);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmpleado", new { idempleado = empleado.idEmpleado }, empleado);
    }

    // DELETE: api/Empleado/5
    [HttpDelete("{idempleado}")]
    public async Task<IActionResult> DeleteEmpleado(int? idempleado)
    {
        var empleado = await _context.Empleado.FindAsync(idempleado);
        if (empleado == null)
        {
            return NotFound();
        }

        _context.Empleado.Remove(empleado);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmpleadoExists(int? idempleado)
    {
        return _context.Empleado.Any(e => e.idEmpleado == idempleado);
    }
}
