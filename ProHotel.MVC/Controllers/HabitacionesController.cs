
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class HabitacionesController : Controller
    {
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
            return View();
        }

        // POST: HABITACIONES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                // Handle the exception (e.g., log it, display an error message, etc.)
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
            return View(habitacion);
        }

        // POST: HABITACIONES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                // Handle the exception (e.g., log it, display an error message, etc.)
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
