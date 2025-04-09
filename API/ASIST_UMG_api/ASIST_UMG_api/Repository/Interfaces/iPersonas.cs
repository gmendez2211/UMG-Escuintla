using ASIST_UMG_api.Models;

namespace ASIST_UMG_api.Repository.Interfaces
{
    public interface iPersonas
    {
        bool RegistraPersona(Persona persona, Login login);
        List<Persona> ReportePersonas();
        List<Persona> ReportePersonasPorCentros(int idSedeCentro);
    }
}
