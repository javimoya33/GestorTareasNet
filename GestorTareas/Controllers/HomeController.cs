using AutoMapper;
using GestorTareas.DTOs;
using GestorTareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GestorTareas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult CrearCategoria()
        {
            return View();
        }

        public async Task<IActionResult> CrearProyecto()
        {
            var categorias = await context.Categorias.ToListAsync();
            var dtoCategorias = categorias.Select(categoria => mapper.Map<CategoriaDTO>(categoria)).ToList();

            return View(dtoCategorias);
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