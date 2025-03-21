using System;
using System.Collections.Generic;

namespace ASIST_UMG_api.Models.DTOs.personas;

public class cRegistroPersonaDto
{
    public int IdPersona { get; set; }

    public int IdSedeCentro { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public int? Tipo { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? SegundoApellido { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerNombre { get; set; }

    public int IdLogin { get; set; }

    

   
}
