using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class HorarioCurso
{
    public int IdHorario { get; set; }

    public int IdCurso { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public int? DiaSemana { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;
}
