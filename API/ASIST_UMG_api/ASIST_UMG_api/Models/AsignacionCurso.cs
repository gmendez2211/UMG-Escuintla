using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class AsignacionCurso
{
    public int IdAsignacion { get; set; }

    public int IdCurso { get; set; }

    public int IdEstudiante { get; set; }

    public int IdProfesor { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    public virtual Profesor IdProfesorNavigation { get; set; } = null!;
}
