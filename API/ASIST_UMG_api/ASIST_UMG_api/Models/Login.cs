using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Login
{
    public int? IdLogin { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public bool? EstadoUsuario { get; set; }

    public string? Contrasena { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
