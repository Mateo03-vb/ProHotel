using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private void CargarListasDesplegables(object? clienteSeleccionado = null, object? empleadoSeleccionado = null)
        {
            var clientes = CRUD<Cliente>.GetAll() ?? new List<Cliente>();
            var empleados = CRUD<Empleado>.GetAll() ?? new List<Empleado>();

            ViewBag.Clientes = new SelectList(clientes.Select(c => new
            {
                c.idCliente,
                Descripcion = $"{c.nombre} {c.apellido} ({c.tipoDocumento}: {c.numeroDocumento})"
            }), "idCliente", "Descripcion", clienteSeleccionado);

            ViewBag.Empleados = new SelectList(empleados.Select(e => new
            {
                e.idEmpleado,
                Descripcion = $"{e.nombre} {e.apellido} ({e.cargo})"
            }), "idEmpleado", "Descripcion", empleadoSeleccionado);
        }

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
            CargarListasDesplegables();
            return View();
        }

        // POST: RESERVAS/Create
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
                CargarListasDesplegables(reserva.idCliente, reserva.idEmpleado);
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
            CargarListasDesplegables(reserva.idCliente, reserva.idEmpleado);
            return View(reserva);
        }

        // POST: RESERVAS/Edit/5
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
                CargarListasDesplegables(reserva.idCliente, reserva.idEmpleado);
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
