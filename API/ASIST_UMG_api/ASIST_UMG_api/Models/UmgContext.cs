using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASIST_UMG_api.Models;

public partial class UmgContext : DbContext
{
    public UmgContext()
    {
    }

    public UmgContext(DbContextOptions<UmgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrativo> Administrativos { get; set; }

    public virtual DbSet<AsignacionCurso> AsignacionCursos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Facultad> Facultads { get; set; }

    public virtual DbSet<HorarioCurso> HorarioCursos { get; set; }

    public virtual DbSet<Inscripcion> Inscripcions { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Marcaje> Marcajes { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<PadreHijo> PadreHijos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<SedeCentro> SedeCentros { get; set; }

    public virtual DbSet<UbicacionCurso> UbicacionCursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.01;Database=umg;Port=5432;Username=postgres;Password=Des@rrollo2024;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrativo>(entity =>
        {
            entity.HasKey(e => e.IdAdministrativo).HasName("Administrativo_pkey");

            entity.ToTable("Administrativo");

            entity.Property(e => e.IdAdministrativo).ValueGeneratedNever();
            entity.Property(e => e.Codigo).HasPrecision(1000);
            entity.Property(e => e.Observacion).HasMaxLength(200);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Administrativos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona243");
        });

        modelBuilder.Entity<AsignacionCurso>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("Asignacion_Curso_pkey");

            entity.ToTable("Asignacion_Curso");

            entity.Property(e => e.IdAsignacion).ValueGeneratedNever();
            entity.Property(e => e.FechaAsignacion).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AsignacionCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso3724");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.AsignacionCursos)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refestudiante2724");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.AsignacionCursos)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refprofesor2624");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("Curso_pkey");

            entity.ToTable("Curso");

            entity.Property(e => e.IdCurso).ValueGeneratedNever();
            entity.Property(e => e.NombreCurso).HasMaxLength(20);

            entity.HasOne(d => d.IdSedeCentroNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdSedeCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refsede_Centro524");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.IdDispositivo).HasName("Dispositivo_pkey");

            entity.ToTable("Dispositivo");

            entity.Property(e => e.IdDispositivo).ValueGeneratedNever();
            entity.Property(e => e.NombreDispositivo).HasMaxLength(100);

            entity.HasOne(d => d.IdMarcajeNavigation).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.IdMarcaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refmarcaje2224");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona2125");

            entity.HasOne(d => d.IdSedeCentroNavigation).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.IdSedeCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refsede_Centro1924");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("Estudiante_pkey");

            entity.ToTable("Estudiante");

            entity.Property(e => e.IdEstudiante).ValueGeneratedNever();
            entity.Property(e => e.Carnet).HasMaxLength(25);
            entity.Property(e => e.IdPadreHijo).HasMaxLength(50);
            entity.Property(e => e.Observacion).HasMaxLength(300);

            entity.HasOne(d => d.IdPadreHijoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdPadreHijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpadre_hijo4324");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona324");
        });

        modelBuilder.Entity<Facultad>(entity =>
        {
            entity.HasKey(e => e.IdFacultad).HasName("Facultad_pkey");

            entity.ToTable("Facultad");

            entity.Property(e => e.IdFacultad).ValueGeneratedNever();
            entity.Property(e => e.NombreFacultad).HasMaxLength(100);

            entity.HasOne(d => d.IdSedeCentroNavigation).WithMany(p => p.Facultads)
                .HasForeignKey(d => d.IdSedeCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refsede_Centro1824");
        });

        modelBuilder.Entity<HorarioCurso>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("Horario_Curso_pkey");

            entity.ToTable("Horario_Curso");

            entity.Property(e => e.IdHorario).ValueGeneratedNever();

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.HorarioCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso824");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("Inscripcion_pkey");

            entity.ToTable("Inscripcion");

            entity.Property(e => e.IdInscripcion).ValueGeneratedNever();

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso1724");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refestudiante1624");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refprofesor1524");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("Login_pkey");

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).ValueGeneratedNever();
            entity.Property(e => e.Contrasena).HasMaxLength(100);
        });

        modelBuilder.Entity<Marcaje>(entity =>
        {
            entity.HasKey(e => e.IdMarcaje).HasName("Marcaje_pkey");

            entity.ToTable("Marcaje");

            entity.Property(e => e.IdMarcaje).ValueGeneratedNever();
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Latitud).HasPrecision(10, 8);
            entity.Property(e => e.Longitud).HasPrecision(11, 8);
            entity.Property(e => e.TipoMarcaje).HasMaxLength(50);

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Marcajes)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso3824");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Marcajes)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona2024");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.IdNotificaciones).HasName("Notificaciones_pkey");

            entity.Property(e => e.IdNotificaciones).ValueGeneratedNever();
            entity.Property(e => e.Estado).HasMaxLength(50);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona2324");
        });

        modelBuilder.Entity<PadreHijo>(entity =>
        {
            entity.HasKey(e => e.IdPadreHijo).HasName("Padre_Hijo_pkey");

            entity.ToTable("Padre_Hijo");

            entity.Property(e => e.IdPadreHijo).HasMaxLength(50);
            entity.Property(e => e.Observacion).HasMaxLength(100);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.PadreHijos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona4224");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("Persona_pkey");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).ValueGeneratedNever();
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.PrimerApellido).HasMaxLength(20);
            entity.Property(e => e.PrimerNombre).HasMaxLength(20);
            entity.Property(e => e.SegundoApellido).HasMaxLength(20);
            entity.Property(e => e.SegundoNombre).HasMaxLength(20);
            entity.Property(e => e.Telefono).HasMaxLength(15);

            entity.HasOne(d => d.IdLoginNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reflogin4424");

            entity.HasOne(d => d.IdSedeCentroNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdSedeCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refsede_Centro424");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("Profesor_pkey");

            entity.ToTable("Profesor");

            entity.Property(e => e.IdProfesor).ValueGeneratedNever();
            entity.Property(e => e.Codigo).HasPrecision(1000);
            entity.Property(e => e.Observacion).HasMaxLength(200);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona124");
        });

        modelBuilder.Entity<SedeCentro>(entity =>
        {
            entity.HasKey(e => e.IdSedeCentro).HasName("SedeCentro_pkey");

            entity.ToTable("SedeCentro");

            entity.Property(e => e.IdSedeCentro).ValueGeneratedNever();
            entity.Property(e => e.CorreoElectronico).HasMaxLength(40);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.NombreSede).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<UbicacionCurso>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("Ubicacion_Curso_pkey");

            entity.ToTable("Ubicacion_Curso");

            entity.Property(e => e.IdUbicacion).ValueGeneratedNever();
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 8)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasPrecision(11, 8);
            entity.Property(e => e.NombreUbicacion).HasMaxLength(100);
            entity.Property(e => e.Radio).HasPrecision(5, 2);

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.UbicacionCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso3624");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
