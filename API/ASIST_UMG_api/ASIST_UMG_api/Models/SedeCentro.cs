using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class SedeCentro
{
    public int IdSedeCentro { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? NombreSede { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();

    public virtual ICollection<Facultad> Facultads { get; set; } = new List<Facultad>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
