using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class ConsumosController : Controller
    {
        private void CargarListasDesplegables(object? servicioSeleccionado = null, object? detalleReservaSeleccionado = null)
        {
            var servicios = CRUD<Servicio>.GetAll() ?? new List<Servicio>();
            var detalles = CRUD<DetalleReserva>.GetAll() ?? new List<DetalleReserva>();

            ViewBag.Servicios = new SelectList(servicios.Select(s => new
            {
                s.idServicio,
                Descripcion = $"{s.nombre} (${s.precio:0.00})"
            }), "idServicio", "Descripcion", servicioSeleccionado);

            ViewBag.DetallesReserva = new SelectList(detalles.Select(d => new
            {
                d.IdDetalleReserva,
                Descripcion = $"Detalle #{d.IdDetalleReserva} (Reserva #{d.idReserva} - {(d.Habitacion != null ? "Hab. " + d.Habitacion.numero : "Hab. #" + d.idHabitacion)})"
            }), "IdDetalleReserva", "Descripcion", detalleReservaSeleccionado);
        }

        // GET: CONSUMOS
        public ActionResult Index()
        {
            var consumos = CRUD<Consumo>.GetAll();
            return View(consumos);
        }

        // GET: CONSUMOS/Details/5
        public ActionResult Details(int id)
        {
            var consumo = CRUD<Consumo>.GetByID(id);
            if (consumo == null)
            {
                return NotFound();
            }
            return View(consumo);
        }

        // GET: CONSUMOS/Create
        public ActionResult Create()
        {
            CargarListasDesplegables();
            return View();
        }

        // POST: CONSUMOS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consumo consumo)
        {
            try
            {
                CRUD<Consumo>.Create(consumo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                CargarListasDesplegables(consumo.idServicio, consumo.idDetalleReserva);
                ModelState.AddModelError("", ex.Message);
                return View(consumo);
            }
        }

        // GET: CONSUMOS/Edit/5
        public ActionResult Edit(int id)
        {
            var consumo = CRUD<Consumo>.GetByID(id);
            if (consumo == null)
            {
                return NotFound();
            }
            CargarListasDesplegables(consumo.idServicio, consumo.idDetalleReserva);
            return View(consumo);
        }

        // POST: CONSUMOS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Consumo consumo)
        {
            try
            {
                CRUD<Consumo>.Update(id, consumo);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                CargarListasDesplegables(consumo.idServicio, consumo.idDetalleReserva);
                ModelState.AddModelError("", ex.Message);
                return View(consumo);
            }
        }

        // GET: CONSUMOS/Delete/5
        public ActionResult Delete(int id)
        {
            var consumo = CRUD<Consumo>.GetByID(id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: CONSUMOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Consumo consumo)
        {
            try
            {
                CRUD<Consumo>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(consumo);
            }
        }
    }
}
