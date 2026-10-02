
using Microsoft.AspNetCore.Mvc;
using ProHotel.Modelos;
using ProHotel.Consumer;
using Microsoft.AspNetCore.Authorization;

namespace ProHotel.MVC.Controllers
{
    [Authorize]
public class ClientesController : Controller
{


    // GET: CLIENTES
    public ActionResult Index()
    {
        var clientes = CRUD<Cliente>.GetAll();
        return View(clientes);
    }

    // GET: CLIENTES/Details/5
    public ActionResult Details(int id)
    {
        var cliente = CRUD<Cliente>.GetByID(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    // GET: CLIENTES/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CLIENTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Cliente cliente)
    {
        try
        {
            CRUD<Cliente>.Create(cliente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(cliente);
        }
    }

    // GET: CLIENTES/Edit/5
    public ActionResult Edit(int id)
    {
        var cliente = CRUD<Cliente>.GetByID(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    // POST: CLIENTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Cliente cliente)
    {
        try
        {
            CRUD<Cliente>.Update(id, cliente);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(cliente);
        }
    }

    // GET: CLIENTES/Delete/5
    public ActionResult Delete(int id)
    {
        var cliente = CRUD<Cliente>.GetByID(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // POST: CLIENTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Cliente cliente)
    {
        try
        {
            CRUD<Cliente>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(cliente);
        }
    }
}
}
