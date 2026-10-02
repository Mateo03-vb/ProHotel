
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: EMPLEADOS
        public ActionResult Index()
        {
            var empleados = CRUD<Empleado>.GetAll();
            return View(empleados);
        }

        // GET: EMPLEADOS/Details/5
        public ActionResult Details(int id)
        {
            var empleado = CRUD<Empleado>.GetByID(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // GET: EMPLEADOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPLEADOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                CRUD<Empleado>.Create(empleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(empleado);
            }
        }

        // GET: EMPLEADOS/Edit/5
        public ActionResult Edit(int id)
        {
            var empleado = CRUD<Empleado>.GetByID(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: EMPLEADOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado empleado)
        {
            try
            {
                CRUD<Empleado>.Update(id, empleado);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message, etc.)
                ModelState.AddModelError("", ex.Message);
                return View(empleado);
            }
        }

        // GET: EMPLEADOS/Delete/5
        public ActionResult Delete(int id)
        {
            var empleado = CRUD<Empleado>.GetByID(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleado empleado)
        {
            try
            {
                CRUD<Empleado>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(empleado);
            }
        }
    }
}
