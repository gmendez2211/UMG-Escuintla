using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public int IdPersona { get; set; }

    public string? Observacion { get; set; }

    public decimal? Codigo { get; set; }

    public virtual ICollection<AsignacionCurso> AsignacionCursos { get; set; } = new List<AsignacionCurso>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
