
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        // GET: RESERVAS
        public ActionResult Index()
        {
            var reservas = CRUD<Reserva>.GetAll();
            return View(reservas);
        }

        // GET: RESERVAS/Details/5
        public ActionResult Details(int id)
        {
            var reserva = CRUD<Reserva>.GetByID(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // GET: RESERVAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RESERVAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva reserva)
        {
            try
            {
                CRUD<Reserva>.Create(reserva);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(reserva);
            }
        }

        // GET: RESERVAS/Edit/5
        public ActionResult Edit(int id)
        {
            var reserva = CRUD<Reserva>.GetByID(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: RESERVAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reserva reserva)
        {
            try
            {
                CRUD<Reserva>.Update(id, reserva);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(reserva);
            }
        }

        // GET: RESERVAS/Delete/5
        public ActionResult Delete(int id)
        {
            var reserva = CRUD<Reserva>.GetByID(id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: RESERVAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Reserva reserva)
        {
            try
            {
                CRUD<Reserva>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(reserva);
            }
        }
    }
}
