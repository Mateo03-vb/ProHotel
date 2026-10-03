using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProHotel.Consumer;
using ProHotel.Modelos;

namespace ProHotel.MVC.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private void CargarEmpleados(object? empleadoSeleccionado = null)
        {
            var empleados = CRUD<Empleado>.GetAll() ?? new List<Empleado>();
            ViewBag.Empleados = new SelectList(empleados.Select(e => new
            {
                e.idEmpleado,
                Descripcion = $"{e.nombre} {e.apellido} ({e.cargo} - CI: {e.cedula})"
            }), "idEmpleado", "Descripcion", empleadoSeleccionado);
        }

        // GET: USUARIOS
        public ActionResult Index()
        {
            var usuarios = CRUD<Usuario>.GetAll();
            return View(usuarios);
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(int id)
        {
            var usuario = CRUD<Usuario>.GetByID(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            CargarEmpleados();
            return View();
        }

        // POST: USUARIOS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // Encriptar la contraseña usando BCrypt antes de enviar a la API
                if (!string.IsNullOrEmpty(usuario.passwordHash))
                {
                    usuario.passwordHash = BCrypt.Net.BCrypt.HashPassword(usuario.passwordHash);
                }

                CRUD<Usuario>.Create(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                CargarEmpleados(usuario.idEmpleado);
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = CRUD<Usuario>.GetByID(id);
            if (usuario == null)
            {
                return NotFound();
            }
            CargarEmpleados(usuario.idEmpleado);
            return View(usuario);
        }

        // POST: USUARIOS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                var usuarioExistente = CRUD<Usuario>.GetByID(id);
                if (usuarioExistente != null)
                {
                    // Si no se proporcionó una nueva contraseña o está vacía, mantenemos la anterior
                    if (string.IsNullOrWhiteSpace(usuario.passwordHash) || usuario.passwordHash == usuarioExistente.passwordHash)
                    {
                        usuario.passwordHash = usuarioExistente.passwordHash;
                    }
                    else
                    {
                        // Si se cambió la contraseña, la encriptamos con BCrypt
                        usuario.passwordHash = BCrypt.Net.BCrypt.HashPassword(usuario.passwordHash);
                    }
                }

                CRUD<Usuario>.Update(id, usuario);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                CargarEmpleados(usuario.idEmpleado);
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = CRUD<Usuario>.GetByID(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario usuario)
        {
            try
            {
                CRUD<Usuario>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }
    }
}
