using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models;

public partial class Marcaje
{
    public int IdMarcaje { get; set; }

    public int IdPersona { get; set; }

    public int IdCurso { get; set; }

    public string? Estado { get; set; }

    public string? TipoMarcaje { get; set; }

    public decimal? Longitud { get; set; }

    public decimal? Latitud { get; set; }

    public TimeOnly? HoraFinal { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
