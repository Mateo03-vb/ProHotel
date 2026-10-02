
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class TipoHabitacionesController : Controller
    {
        // GET: TIPOHABITACIONES
        public ActionResult Index()
        {
            var tipoHabitaciones = CRUD<TipoHabitacion>.GetAll();
            return View(tipoHabitaciones);
        }

        // GET: TIPOHABITACIONES/Details/5
        public ActionResult Details(int id)
        {
            var tipoHabitacion = CRUD<TipoHabitacion>.GetByID(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }
            return View(tipoHabitacion);
        }

        // GET: TIPOHABITACIONES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOHABITACIONES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoHabitacion tipoHabitacion)
        {
            try
            {
                CRUD<TipoHabitacion>.Create(tipoHabitacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(tipoHabitacion);
            }
        }

        // GET: TIPOHABITACIONES/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoHabitacion = CRUD<TipoHabitacion>.GetByID(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }
            return View(tipoHabitacion);
        }

        // POST: TIPOHABITACIONES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoHabitacion tipoHabitacion)
        {
            try
            {
                CRUD<TipoHabitacion>.Update(id, tipoHabitacion);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(tipoHabitacion);
            }
        }

        // GET: TIPOHABITACIONES/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoHabitacion = CRUD<TipoHabitacion>.GetByID(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
        }

        // POST: TIPOHABITACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoHabitacion tipoHabitacion)
        {
            try
            {
                CRUD<TipoHabitacion>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(tipoHabitacion);
            }
        }
    }
}
