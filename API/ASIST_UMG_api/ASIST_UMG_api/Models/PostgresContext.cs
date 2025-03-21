using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASIST_UMG_api.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
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
        => optionsBuilder.UseNpgsql("Host=127.0.01;Database=postgres;Port=5432;Username=postgres;Password=Des@rrollo2024;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Administrativo>(entity =>
        {
            entity.HasKey(e => e.IdAdministrativo).HasName("administrativo_pkey");

            entity.ToTable("administrativo");

            entity.Property(e => e.IdAdministrativo)
                .ValueGeneratedNever()
                .HasColumnName("id_administrativo");
            entity.Property(e => e.Codigo)
                .HasPrecision(1000)
                .HasColumnName("codigo");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Observacion)
                .HasMaxLength(200)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Administrativos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona243");
        });

        modelBuilder.Entity<AsignacionCurso>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("asignacion_curso_pkey");

            entity.ToTable("asignacion_curso");

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("id_asignacion");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_asignacion");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

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
            entity.HasKey(e => e.IdCurso).HasName("curso_pkey");

            entity.ToTable("curso");

            entity.Property(e => e.IdCurso)
                .ValueGeneratedNever()
                .HasColumnName("id_curso");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdSedeCentro).HasColumnName("id_sede_centro");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(20)
                .HasColumnName("nombre_curso");

            entity.HasOne(d => d.IdSedeCentroNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdSedeCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refsede_Centro524");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.IdDispositivo).HasName("dispositivo_pkey");

            entity.ToTable("dispositivo");

            entity.Property(e => e.IdDispositivo)
                .ValueGeneratedNever()
                .HasColumnName("id_dispositivo");
            entity.Property(e => e.IdMarcaje).HasColumnName("id_marcaje");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdSedeCentro).HasColumnName("id_sede_centro");
            entity.Property(e => e.NombreDispositivo)
                .HasMaxLength(100)
                .HasColumnName("nombre_dispositivo");

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
            entity.HasKey(e => e.IdEstudiante).HasName("estudiante_pkey");

            entity.ToTable("estudiante");

            entity.Property(e => e.IdEstudiante)
                .ValueGeneratedNever()
                .HasColumnName("id_estudiante");
            entity.Property(e => e.Carnet)
                .HasMaxLength(25)
                .HasColumnName("carnet");
            entity.Property(e => e.IdPadreHijo)
                .HasMaxLength(50)
                .HasColumnName("id_padre_hijo");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Observacion)
                .HasMaxLength(300)
                .HasColumnName("observacion");

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
            entity.HasKey(e => e.IdFacultad).HasName("facultad_pkey");

            entity.ToTable("facultad");

            entity.Property(e => e.IdFacultad)
                .ValueGeneratedNever()
                .HasColumnName("id_facultad");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.IdSedeCentro).HasColumnName("id_sede_centro");
            entity.Property(e => e.NombreFacultad)
                .HasMaxLength(100)
                .HasColumnName("nombre_facultad");

            entity.HasOne(d => d.IdSedeCentroNavigation).WithMany(p => p.Facultads)
                .HasForeignKey(d => d.IdSedeCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refsede_Centro1824");
        });

        modelBuilder.Entity<HorarioCurso>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("horario_curso_pkey");

            entity.ToTable("horario_curso");

            entity.Property(e => e.IdHorario)
                .ValueGeneratedNever()
                .HasColumnName("id_horario");
            entity.Property(e => e.DiaSemana).HasColumnName("dia_semana");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.HorarioCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso824");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("inscripcion_pkey");

            entity.ToTable("inscripcion");

            entity.Property(e => e.IdInscripcion)
                .ValueGeneratedNever()
                .HasColumnName("id_inscripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaInscripcion).HasColumnName("fecha_inscripcion");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

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
            entity.HasKey(e => e.IdLogin).HasName("login_pkey");

            entity.ToTable("login");

            entity.Property(e => e.IdLogin)
                .ValueGeneratedNever()
                .HasColumnName("id_login");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .HasColumnName("contrasena");
            entity.Property(e => e.EstadoUsuario).HasColumnName("estado_usuario");
        });

        modelBuilder.Entity<Marcaje>(entity =>
        {
            entity.HasKey(e => e.IdMarcaje).HasName("marcaje_pkey");

            entity.ToTable("marcaje");

            entity.Property(e => e.IdMarcaje)
                .ValueGeneratedNever()
                .HasColumnName("id_marcaje");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraFinal).HasColumnName("hora_final");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 8)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(11, 8)
                .HasColumnName("longitud");
            entity.Property(e => e.TipoMarcaje)
                .HasMaxLength(50)
                .HasColumnName("tipo_marcaje");

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
            entity.HasKey(e => e.IdNotificaciones).HasName("notificaciones_pkey");

            entity.ToTable("notificaciones");

            entity.Property(e => e.IdNotificaciones)
                .ValueGeneratedNever()
                .HasColumnName("id_notificaciones");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Mensaje).HasColumnName("mensaje");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona2324");
        });

        modelBuilder.Entity<PadreHijo>(entity =>
        {
            entity.HasKey(e => e.IdPadreHijo).HasName("padre_hijo_pkey");

            entity.ToTable("padre_hijo");

            entity.Property(e => e.IdPadreHijo)
                .HasMaxLength(50)
                .HasColumnName("id_padre_hijo");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.PadreHijos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona4224");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_persona");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.IdLogin).HasColumnName("id_login");
            entity.Property(e => e.IdSedeCentro).HasColumnName("id_sede_centro");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(20)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(20)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(20)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(20)
                .HasColumnName("segundo_nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo).HasColumnName("tipo");

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
            entity.HasKey(e => e.IdProfesor).HasName("profesor_pkey");

            entity.ToTable("profesor");

            entity.Property(e => e.IdProfesor)
                .ValueGeneratedNever()
                .HasColumnName("id_profesor");
            entity.Property(e => e.Codigo)
                .HasPrecision(1000)
                .HasColumnName("codigo");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Observacion)
                .HasMaxLength(200)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refpersona124");
        });

        modelBuilder.Entity<SedeCentro>(entity =>
        {
            entity.HasKey(e => e.IdSedeCentro).HasName("sede_Centro_pkey");

            entity.ToTable("sede_centro");

            entity.Property(e => e.IdSedeCentro)
                .ValueGeneratedNever()
                .HasColumnName("id_sede_centro");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(40)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreSede)
                .HasMaxLength(100)
                .HasColumnName("nombre_sede");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<UbicacionCurso>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("ubicacion_curso_pkey");

            entity.ToTable("ubicacion_curso");

            entity.Property(e => e.IdUbicacion)
                .ValueGeneratedNever()
                .HasColumnName("id_ubicacion");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 8)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(11, 8)
                .HasColumnName("longitud");
            entity.Property(e => e.NombreUbicacion)
                .HasMaxLength(100)
                .HasColumnName("nombre_ubicacion");
            entity.Property(e => e.Radio)
                .HasPrecision(5, 2)
                .HasColumnName("radio");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.UbicacionCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Refcurso3624");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
