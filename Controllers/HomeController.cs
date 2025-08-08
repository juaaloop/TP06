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
    public IActionResult vistaUsuario(){

        Usuario usu=Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        ViewBag.nombre=usu.username;
        ViewBag.tareas=BD.levantarTarea(usu);
    }
}
