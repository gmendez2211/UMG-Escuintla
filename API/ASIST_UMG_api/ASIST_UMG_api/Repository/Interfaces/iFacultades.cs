using ASIST_UMG_api.Models;

namespace ASIST_UMG_api.Repository.Interfaces
{
    public interface iFacultades
    {
        bool RegistraFacultad(Facultad facultades);
        bool ActualizaFacultad(Facultad facultades);
        List<Facultad> ListadoFacultades();
        
    }
}
