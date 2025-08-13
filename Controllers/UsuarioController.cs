using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Downloads.Models;

namespace Downloads.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult iniciarSesion(string estado){
        ViewBag.estado=estado;

        if (HttpContext.Session.GetString("usuario") != null)
        {
            return RedirectToAction("vistaUsuario");
            }

        return RedirectToAction("iniciarSesion","Home");
    }
    public IActionResult comprobarDatos(string nombreUsuarioNuevo, string password)
    {
       Usuario usu = BDUsu.obtenerUsuario(nombreUsuarioNuevo,encriptar.HashearPassword(password));
            if(usu != null){
                HttpContext.Session.SetString("usuario", Objeto.ObjectToString(usu));
                return RedirectToAction("vistaUsuario","Home");
            }else{
                return RedirectToAction("iniciarSesion",new{estado="error"});
            }
    }
    public IActionResult cerrarSesion()
    {
        HttpContext.Session.Remove("usuario");
        return RedirectToAction("iniciarSesion");
    }
    public IActionResult registrarse(string estado)
    {
        ViewBag.estado=estado;
        return View();
    }

    public IActionResult registrarNuevo(string nombreUsuarioNuevo,string password)
    {
            Usuario usu=new Usuario();
            string passwordHasheada = encriptar.HashearPassword(password);
            usu.crearUsuario(nombreUsuarioNuevo, passwordHasheada);
            bool funciono=BDUsu.agregarUsuario(usu);
            if(funciono){
                return RedirectToAction("registrarse","Home",new{estado="funciono"});
            }else{
                return RedirectToAction("registrarse","Home",new{estado="Nofunciono"});

            }
           
        }
    }

