
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class PagosController : Controller
    {
        // GET: PAGOS
        public ActionResult Index()
        {
            var pagos = CRUD<Pago>.GetAll();
            return View(pagos);
        }

        // GET: PAGOS/Details/5
        public ActionResult Details(int id)
        {
            var pago = CRUD<Pago>.GetByID(id);
            if (pago == null)
            {
                return NotFound();
            }
            return View(pago);
        }

        // GET: PAGOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PAGOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago pago)
        {
            try
            {
                CRUD<Pago>.Create(pago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(pago);
            }
        }

        // GET: PAGOS/Edit/5
        public ActionResult Edit(int id)
        {
            var pago = CRUD<Pago>.GetByID(id);
            if (pago == null)
            {
                return NotFound();
            }
            return View(pago);
        }

        // POST: PAGOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pago pago)
        {
            try
            {
                CRUD<Pago>.Update(id, pago);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(pago);
            }
        }

        // GET: PAGOS/Delete/5
        public ActionResult Delete(int id)
        {
            var pago = CRUD<Pago>.GetByID(id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: PAGOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pago pago)
        {
            try
            {
                CRUD<Pago>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pago);
            }
        }
    }
}
