using GestorTareas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestorTareas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CrearCategoria()
        {
            return View();
        }

        public IActionResult CrearProyecto()
        {
            return View();
        }

        public IActionResult CrearTarea()
        {
            return View();
        }

        public IActionResult CrearSubTarea()
        {
            return View();
        }
    }
}