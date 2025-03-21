using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Administrativo
{
    public int IdAdministrativo { get; set; }

    public int IdPersona { get; set; }

    public string? Observacion { get; set; }

    public decimal? Codigo { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
