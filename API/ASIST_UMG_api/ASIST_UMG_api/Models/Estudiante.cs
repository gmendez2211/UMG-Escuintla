using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public int IdPersona { get; set; }

    public string? Observacion { get; set; }

    public string? Carnet { get; set; }

    public string IdPadreHijo { get; set; } = null!;

    public virtual ICollection<AsignacionCurso> AsignacionCursos { get; set; } = new List<AsignacionCurso>();

    public virtual PadreHijo IdPadreHijoNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
