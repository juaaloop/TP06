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
    public IActionResult agregarTarea(string nombre,string contenido)
    {
        Usuario usu=Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        Tarea tarea = new Tarea();
        tarea.crearTarea(usu.idUsuario,nombre,contenido);
        BD.agregarTarea(tarea);
        //Form arriba del resto de las cosas 
        return RedirectToAction("vistaUsuario","Home");
    }

    public IActionResult modificarTarea(Tarea tarea,string contenido)
    {
        Usuario usu=Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        tarea.contenido=contenido;
        BD.modificarTarea(tarea,usu.idUsuario);
        return RedirectToAction("vistaUsuario","Home");
    }
    
    public IActionResult eliminarTarea(Tarea tarea)
    {
        Usuario usu=Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        BD.eliminarTarea(tarea.idTarea,usu.idUsuario);
        return RedirectToAction("vistaUsuario","Home");
    }
    public IActionResult terminarTarea(Tarea tarea)
    {
        BD.terminarTarea(tarea.idTarea);
        return RedirectToAction("vistaUsuario","Home");
    }
    public IActionResult compartirTarea(Usuario nuevo, Tarea tarea)
    {
        Usuario usu=Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        BD.compartirTarea(nuevo.idUsuario, usu.idUsuario, tarea.idTarea);
        return RedirectToAction("vistaUsuario","Home");
    }
    public IActionResult agregarALista(Tarea tarea, Lista lista)
    {
        BD.agregarALista(tarea.idTarea,lista.idLista);
       return RedirectToAction("vistaUsuario","home");

    }
}
