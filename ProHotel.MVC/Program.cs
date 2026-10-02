using ProHotel.Consumer;
using ProHotel.Modelos;
namespace ProHotel.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CRUD<Cliente>.Endpoint = "https://localhost:7161/api/Clientes";
            CRUD<Consumo>.Endpoint = "https://localhost:7161/api/Consumos";
            CRUD<DetalleReserva>.Endpoint = "https://localhost:7161/api/DetalleReservas";
            CRUD<Empleado>.Endpoint = "https://localhost:7161/api/Empleados";
            CRUD<Pago>.Endpoint = "https://localhost:7161/api/Pagos";
            CRUD<Habitacion>.Endpoint = "https://localhost:7161/api/Habitaciones";
            CRUD<Reserva>.Endpoint = "https://localhost:7161/api/Reservas";
            CRUD<Servicio>.Endpoint = "https://localhost:7161/api/Servicios";
            CRUD<TipoHabitacion>.Endpoint = "https://localhost:7161/api/TipoHabitaciones";
            CRUD<Usuario>.Endpoint = "https://localhost:7161/api/Usuarios";

            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
