using GestorTareas.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestorTareas.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System;

namespace GestorTareas.Controllers
{
    [ApiController]
    [Route("GestorTareas/Categorias")]
    public class CategoriasController: Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoriasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet (Name = "Categorias")]
        public async Task<ActionResult<CategoriasDTO>> Get()
        {
            var categorias = await context.Categorias.ToListAsync();
            var categoriaDtos = categorias.Select(categoria => mapper.Map<CategoriaDTO>(categoria)).ToList();

            var categoriasDto = new CategoriasDTO
            {
                Categorias = categoriaDtos
            };

            return View("Categorias", categoriasDto);
        }

        [HttpGet("{id:int}", Name = "Categoria")]
        public async Task<IActionResult> Categoria(int id)
        {
            var categorias = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categorias == null)
            {
                return NotFound();
            }

            var dtos = mapper.Map<CategoriaDTO>(categorias);

            return View("Categoria", dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoriaCreacionDTO categoriaCreacionDTO)
    {
        var categoria = mapper.Map<Categoria>(categoriaCreacionDTO);

            if (categoria == null)
            {
                return NotFound();
            }

            context.Add(categoria);
            await context.SaveChangesAsync();

            var nuevaCategoria = mapper.Map<CategoriaDTO>(categoria);

            return RedirectToAction(nameof(Categoria), new { id = categoria.Id });
        }
    }
}
