namespace ASIST_UMG_api.Models.DTOs.login
{
    public class cRegistroLoginDto
    {
        public string CorreoElectronico { get; set; } = null!;

        public bool? EstadoUsuario { get; set; }

        public string? Contrasena { get; set; }
    }
}
