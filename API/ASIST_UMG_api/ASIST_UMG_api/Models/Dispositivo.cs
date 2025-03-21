using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Dispositivo
{
    public int IdDispositivo { get; set; }

    public int IdMarcaje { get; set; }

    public int IdPersona { get; set; }

    public int IdSedeCentro { get; set; }

    public string? NombreDispositivo { get; set; }

    public virtual Marcaje IdMarcajeNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual SedeCentro IdSedeCentroNavigation { get; set; } = null!;
}
