
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    public class ConsumosController : Controller
    {// GET: CONSUMOS
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
            return View();
        }

        // POST: CONSUMOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                // Handle the exception (e.g., log it, display an error message, etc.)
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
            return View(consumo);
        }

        // POST: CONSUMOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                // Handle the exception (e.g., log it, display an error message, etc.)
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
