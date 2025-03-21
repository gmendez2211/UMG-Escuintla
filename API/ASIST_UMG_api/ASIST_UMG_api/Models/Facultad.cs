using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Facultad
{
    public int IdFacultad { get; set; }

    public int IdSedeCentro { get; set; }

    public string? Descripcion { get; set; }

    public string? NombreFacultad { get; set; }

    public virtual SedeCentro IdSedeCentroNavigation { get; set; } = null!;
}
