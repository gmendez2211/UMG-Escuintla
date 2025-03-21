using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Notificacione
{
    public int IdNotificaciones { get; set; }

    public int IdPersona { get; set; }

    public string? Estado { get; set; }

    public TimeOnly? Hora { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Mensaje { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
