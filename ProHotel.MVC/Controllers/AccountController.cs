using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProHotel.Consumer;
using ProHotel.Modelos; 
using System.Security.Claims;

namespace ProHotel.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        // Muestra el formulario vacío
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        
        // POST: /Account/Login
        // Recibe los datos del formulario
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string username, string password)
        {
            try
            {
                
                CRUD<Usuario>.Endpoint = "https://localhost:7161/api/Usuarios";

                
                var usuarios = CRUD<Usuario>.GetAll();

                /
                var usuario = usuarios.FirstOrDefault(u => u.username == username && u.activo == true);

                // Validar credenciales
                //con texto plano sin hashing
                if (usuario == null || usuario.passwordHash != password)
                {
                    ViewBag.Error = "Usuario o contraseña incorrectos.";
                    return View();
                }

                //  Crear los Claims 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.username),
                    new Claim(ClaimTypes.Role, usuario.rol),
                    new Claim("idUsuario", usuario.idUsuario.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //Iniciar Sesión (Crear cookie)
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                //  Redirigir al panel
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                
                ViewBag.Error = $"Error de conexión: {ex.Message}";
                return View();
            }
        }

       
        // GET: /Account/Logout
        
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
