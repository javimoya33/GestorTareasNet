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
            modelBuilder.Entity<EncargadosTareas>()
                .HasKey(x => new { x.EncargadoId, x.TareaId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<SubTareas> SubTareas { get; set; }
        public DbSet<Encargados> Encargados { get; set; }
        public DbSet<EncargadosTareas> EncargadosTareas { get; set; }
        public DbSet<Niveles> Niveles { get; set; }
        public DbSet<Estados> Estados { get; set; }
    }
}
