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
    public IActionResult modificarTarea(int idtarea,string contenido)
    {
        Usuario usu=Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        BD.modificarTarea(idtarea, contenido, usu.id_Usuario);
        return RedirectToAction("vistaUsuario","Home");
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
    public IActionResult compartirTarea(List<int> nuevos, int idTarea)
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        foreach (int nuevo in nuevos)
        {
            BD.compartirTarea(nuevo, usu.id_Usuario, idTarea);

        }
        return RedirectToAction("vistaUsuario", "Home");
    }
    public IActionResult agregarALista(Tarea tarea, Lista lista)
    {
        BD.agregarALista(tarea.id_tarea,lista.idLista);
       return RedirectToAction("vistaUsuario","home");

    }
}
