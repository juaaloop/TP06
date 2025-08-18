using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Downloads.Models;

namespace Downloads.Controllers;

public class TareasController : Controller
{
    private readonly ILogger<TareasController> _logger;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult agregarTarea(string nombre, string contenido)
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        BD.agregarTarea(nombre, contenido, usu.id_Usuario);
        //Form arriba del resto de las cosas 
        return RedirectToAction("vistaUsuario", "Home");
    }
    [HttpPost]
    public IActionResult modificarTarea(int idtarea, string contenido)
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        BD.modificarTarea(idtarea, contenido, usu.id_Usuario);
        return RedirectToAction("vistaUsuario", "Home");
    }

    [HttpPost]
    public IActionResult eliminarTarea(int id_tarea)
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        BD.eliminarTarea(id_tarea, usu.id_Usuario);
        return RedirectToAction("vistaUsuario", "Home");
    }
    [HttpPost]
    public IActionResult terminarTarea(int id_tarea)
    {
        BD.terminarTarea(id_tarea);
        return RedirectToAction("vistaUsuario", "Home");
    }
    [HttpPost]
    public IActionResult compartirTarea(List<int> nuevos, int id_tarea, int id_usuarioog)
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        Console.WriteLine(id_usuarioog);
        if (usu.id_Usuario == id_usuarioog)
        {
            foreach (int nuevo in nuevos)
            {
                Console.WriteLine(nuevo);
                BD.compartirTarea(nuevo, id_tarea);

            }
        }

        return RedirectToAction("vistaUsuario", "Home");
    }
    public IActionResult agregarALista(int id_tarea, int id_lista)
    {
        BDLista.agregarALista(id_tarea, id_lista);
        return RedirectToAction("vistaUsuario", "home");

    }
    public IActionResult crearLista(string nombre)
    {
        BDLista.agregarLista(nombre);
        return RedirectToAction("vistaUsuario", "home");
    }
    public IActionResult sacarLista(int id_tarea, int id_lista)
    {
        BDLista.sacarDeLista(id_tarea, id_lista);
        return RedirectToAction("vistaUsuario", "home");

    }
     public IActionResult eliminarLista(int id_lista)
    {
        BDLista.eliminarLista( id_lista);
        return RedirectToAction("vistaUsuario", "home");

    }
}
