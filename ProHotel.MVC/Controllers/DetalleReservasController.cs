using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class DetalleReservasController : Controller
    {
        private void CargarListasDesplegables(object? reservaSeleccionada = null, object? habitacionSeleccionada = null)
        {
            var reservas = CRUD<Reserva>.GetAll() ?? new List<Reserva>();
            var habitaciones = CRUD<Habitacion>.GetAll() ?? new List<Habitacion>();

            ViewBag.Reservas = new SelectList(reservas.Select(r => new
            {
                r.idReserva,
                Descripcion = $"Reserva #{r.idReserva} - {(r.Cliente != null ? r.Cliente.nombre + " " + r.Cliente.apellido : "Cliente #" + r.idCliente)}"
            }), "idReserva", "Descripcion", reservaSeleccionada);

            ViewBag.Habitaciones = new SelectList(habitaciones.Select(h => new
            {
                h.idHabitacion,
                Descripcion = $"Habitación {h.numero} (Piso {h.piso} - {h.TipoHabitacion?.nombre ?? "Tipo #" + h.idTipoHabitacion}) [{h.estado}]"
            }), "idHabitacion", "Descripcion", habitacionSeleccionada);
        }

        // GET: DETALLERESERVAS
        public ActionResult Index()
        {
            var detalleReservas = CRUD<DetalleReserva>.GetAll();
            return View(detalleReservas);
        }

        // GET: DETALLERESERVAS/Details/5
        public ActionResult Details(int id)
        {
            var detalleReserva = CRUD<DetalleReserva>.GetByID(id);
            if (detalleReserva == null)
            {
                return NotFound();
            }
            return View(detalleReserva);
        }

        // GET: DETALLERESERVAS/Create
        public ActionResult Create()
        {
            CargarListasDesplegables();
            return View();
        }

        // POST: DETALLERESERVAS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleReserva detalleReserva)
        {
            try
            {
                CRUD<DetalleReserva>.Create(detalleReserva);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                CargarListasDesplegables(detalleReserva.idReserva, detalleReserva.idHabitacion);
                ModelState.AddModelError("", ex.Message);
                return View(detalleReserva);
            }
        }

        // GET: DETALLERESERVAS/Edit/5
        public ActionResult Edit(int id)
        {
            var detalleReserva = CRUD<DetalleReserva>.GetByID(id);
            if (detalleReserva == null)
            {
                return NotFound();
            }
            CargarListasDesplegables(detalleReserva.idReserva, detalleReserva.idHabitacion);
            return View(detalleReserva);
        }

        // POST: DETALLERESERVAS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DetalleReserva detalleReserva)
        {
            try
            {
                CRUD<DetalleReserva>.Update(id, detalleReserva);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                CargarListasDesplegables(detalleReserva.idReserva, detalleReserva.idHabitacion);
                ModelState.AddModelError("", ex.Message);
                return View(detalleReserva);
            }
        }

        // GET: DETALLERESERVAS/Delete/5
        public ActionResult Delete(int id)
        {
            var detalleReserva = CRUD<DetalleReserva>.GetByID(id);
            if (detalleReserva == null)
            {
                return NotFound();
            }

            return View(detalleReserva);
        }

        // POST: DETALLERESERVAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DetalleReserva detalleReserva)
        {
            try
            {
                CRUD<DetalleReserva>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(detalleReserva);
            }
        }
    }
}
