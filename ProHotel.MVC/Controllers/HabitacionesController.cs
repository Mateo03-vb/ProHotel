using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class HabitacionesController : Controller
    {
        private void CargarTiposHabitacion(object? tipoSeleccionado = null)
        {
            var tipos = CRUD<TipoHabitacion>.GetAll() ?? new List<TipoHabitacion>();
            ViewBag.TiposHabitacion = new SelectList(tipos.Select(t => new
            {
                t.idTipoHabitacion,
                Descripcion = $"{t.nombre} - ${t.precioBaseNoche:0.00} (Capacidad: {t.capacidadPersonas} personas)"
            }), "idTipoHabitacion", "Descripcion", tipoSeleccionado);
        }

        // GET: HABITACIONES
        public ActionResult Index()
        {
            var habitaciones = CRUD<Habitacion>.GetAll();
            return View(habitaciones);
        }

        // GET: HABITACIONES/Details/5
        public ActionResult Details(int id)
        {
            var habitacion = CRUD<Habitacion>.GetByID(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return View(habitacion);
        }

        // GET: HABITACIONES/Create
        public ActionResult Create()
        {
            CargarTiposHabitacion();
            return View();
        }

        // POST: HABITACIONES/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Habitacion habitacion)
        {
            try
            {
                CRUD<Habitacion>.Create(habitacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                CargarTiposHabitacion(habitacion.idTipoHabitacion);
                ModelState.AddModelError("", ex.Message);
                return View(habitacion);
            }
        }

        // GET: HABITACIONES/Edit/5
        public ActionResult Edit(int id)
        {
            var habitacion = CRUD<Habitacion>.GetByID(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            CargarTiposHabitacion(habitacion.idTipoHabitacion);
            return View(habitacion);
        }

        // POST: HABITACIONES/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Habitacion habitacion)
        {
            try
            {
                CRUD<Habitacion>.Update(id, habitacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                CargarTiposHabitacion(habitacion.idTipoHabitacion);
                ModelState.AddModelError("", ex.Message);
                return View(habitacion);
            }
        }

        // GET: HABITACIONES/Delete/5
        public ActionResult Delete(int id)
        {
            var habitacion = CRUD<Habitacion>.GetByID(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: HABITACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Habitacion habitacion)
        {
            try
            {
                CRUD<Habitacion>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(habitacion);
            }
        }
    }
}
