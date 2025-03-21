using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public int IdSedeCentro { get; set; }

    public DateOnly? FechaFin { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public string? Descripcion { get; set; }

    public string? NombreCurso { get; set; }

    public virtual ICollection<AsignacionCurso> AsignacionCursos { get; set; } = new List<AsignacionCurso>();

    public virtual ICollection<HorarioCurso> HorarioCursos { get; set; } = new List<HorarioCurso>();

    public virtual SedeCentro IdSedeCentroNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();

    public virtual ICollection<Marcaje> Marcajes { get; set; } = new List<Marcaje>();

    public virtual ICollection<UbicacionCurso> UbicacionCursos { get; set; } = new List<UbicacionCurso>();
}
