using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace GestorTareas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EncargadoTarea>()
                .HasKey(x => new { x.EncargadoId, x.TareaId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<SubTarea> SubTareas { get; set; }
        public DbSet<Encargado> Encargados { get; set; }
        public DbSet<EncargadoTarea> EncargadosTareas { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
