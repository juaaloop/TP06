using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Downloads.Models;

namespace Downloads.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }



    public IActionResult iniciarSesion()
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        if (usu != null)
        {
            return RedirectToAction("vistaUsuario");
        }
        return View();
    }

    public IActionResult registrarse()
    {

        return View();
    }
    public IActionResult vistaUsuario()
    {
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        if (usu != null)
        {
            ViewBag.nombre = usu.username;
            ViewBag.id = usu.id_Usuario;
            ViewBag.otrosUsuarios = BDUsu.levantarUsuarios(usu);
            ViewBag.tareas = BD.levantarTarea(usu.id_Usuario);
            ViewBag.listas = BDLista.obtenerListas();
        }
        else
        {
            ViewBag.id = 0;
        }

            return View();

    }
    public IActionResult listas()
    
    {
                Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        if (usu != null)
        {
            ViewBag.usu = usu.id_Usuario;

            ViewBag.listas = BDLista.obtenerListas();
        }
        else
        {
            ViewBag.usu = 0;
        }
        return View();
    }
    public IActionResult reciclaje(){
        Usuario usu = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        if (usu != null)
        {
            ViewBag.tareasBorradas = BD.levantarTareasBorradas(usu.id_Usuario);
            ViewBag.usu = usu.id_Usuario;
        }
        else
        {
            ViewBag.usu = 0;
        }

                
        return View();
    }
}
