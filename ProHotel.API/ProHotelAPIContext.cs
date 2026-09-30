using Microsoft.EntityFrameworkCore;

public class ProHotelAPIContext(DbContextOptions<ProHotelAPIContext> options) : DbContext(options)
{
    public DbSet<ProHotel.Modelos.Cliente> Cliente { get; set; } = default!;
    public DbSet<ProHotel.Modelos.Consumo> Consumo { get; set; } = default!;
    public DbSet<ProHotel.Modelos.DetalleReserva> DetalleReserva { get; set; } = default!;    
    public DbSet<ProHotel.Modelos.Empleado> Empleado { get; set; } = default!;
    public DbSet<ProHotel.Modelos.Habitacion> Habitacion { get; set; } = default!;
    public DbSet<ProHotel.Modelos.Pago> Pago { get; set; } = default!;
    public DbSet<ProHotel.Modelos.Reserva> Reserva { get; set; } = default!;
    public DbSet<ProHotel.Modelos.Servicio> Servicio { get; set; } = default!;
    public DbSet<ProHotel.Modelos.TipoHabitacion> TipoHabitacion { get; set; } = default!;
    public DbSet<ProHotel.Modelos.Usuario> Usuario { get; set; } = default!;



}
