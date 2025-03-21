using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public int IdSedeCentro { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public int? Tipo { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? SegundoApellido { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerNombre { get; set; }

    public int IdLogin { get; set; }

    public virtual ICollection<Administrativo> Administrativos { get; set; } = new List<Administrativo>();

    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual Login IdLoginNavigation { get; set; } = null!;

    public virtual SedeCentro IdSedeCentroNavigation { get; set; } = null!;

    public virtual ICollection<Marcaje> Marcajes { get; set; } = new List<Marcaje>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<PadreHijo> PadreHijos { get; set; } = new List<PadreHijo>();

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
}
