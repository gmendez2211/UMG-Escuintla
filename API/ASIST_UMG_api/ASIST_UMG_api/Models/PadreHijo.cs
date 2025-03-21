using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class PadreHijo
{
    public string IdPadreHijo { get; set; } = null!;

    public string? Observacion { get; set; }

    public int IdPersona { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
