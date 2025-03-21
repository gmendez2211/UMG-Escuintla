using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class UbicacionCurso
{
    public int IdUbicacion { get; set; }

    public int IdCurso { get; set; }

    public bool? Activo { get; set; }

    public decimal? Radio { get; set; }

    public decimal? Longitud { get; set; }

    public decimal? Latitud { get; set; }

    public string? NombreUbicacion { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;
}
