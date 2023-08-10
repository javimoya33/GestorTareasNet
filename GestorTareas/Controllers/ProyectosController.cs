using AutoMapper;
using GestorTareas.DTOs;
using GestorTareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Controllers
{
    [ApiController]
    [Route("GestorTareas/Proyectos")]
    public class ProyectosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProyectosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet(Name = "Proyectos")]
        public async Task<ActionResult<ProyectosDTO>> Get()
        {
            var proyectos = await context.Proyectos.ToListAsync();
            var proyectoDtos = proyectos.Select(proyecto => mapper.Map<ProyectoDTO>(proyecto)).ToList();

            var proyectosDtos = new ProyectosDTO
            {
                Proyectos = proyectoDtos
            };

            return View("Proyectos", proyectosDtos);
        }

        [HttpGet("{id:int}", Name = "Proyecto")]
        public async Task<IActionResult> Proyecto(int id)
        {
            var proyectos = await context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);

            if (proyectos == null)
            {
                return NotFound();
            }

            var dtos = mapper.Map<ProyectoDTO>(proyectos);

            return View("Proyecto", dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProyectoCreacionDTO proyectoCreacionDTO)
        {
            var proyecto = mapper.Map<Proyecto>(proyectoCreacionDTO);

            if (proyecto == null)
            {
                return NotFound();
            }

            context.Add(proyecto);
            await context.SaveChangesAsync();

            var nuevaProyecto = mapper.Map<ProyectoDTO>(proyecto);

            return RedirectToAction(nameof(Proyecto), new { id = proyecto.Id });
        }
    } 
}
