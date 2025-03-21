using ASIST_UMG_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ASIST_UMG_api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("public");
            
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Marcaje>(tabla => {
            //   tabla.ToTable("marcaje");
            //    tabla.Property(columna => columna.idmarcaje);
            //}
            //);

            


                //modelBuilder.Entity<Marcaje>().Ignore(t => t.IdPersona);
                //base.OnModelCreating(modelBuilder);
                //modelBuilder.Entity<Persona>().Ignore(t => t.IdPersona);
                //base.OnModelCreating(modelBuilder);
                //modelBuilder.Entity<Administrativo>().Ignore(t => t.IdPersona);
                //base.OnModelCreating(modelBuilder);
                //modelBuilder.Entity<AsignacionCurso>().Ignore(t => t.IdEstudiante);
                //base.OnModelCreating(modelBuilder);
                //modelBuilder.Entity<Estudiante>().Ignore(t => t.IdEstudiante);
                //base.OnModelCreating(modelBuilder);


            }
        //Modelos a utilizar
        public DbSet<Marcaje> Marcajes { get; set; }
       
        //public DbSet<Administrativo> Administrativo { get; set; }
        //public DbSet<Persona> Persona { get; set; }
        //public DbSet<AsignacionCurso> AsignacionCurso { get; set; }
        //public DbSet<Estudiante> Estudiante { get; set; }
    }
}
