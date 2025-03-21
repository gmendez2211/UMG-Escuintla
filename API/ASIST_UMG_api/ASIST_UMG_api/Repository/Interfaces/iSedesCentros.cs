using ASIST_UMG_api.Models;

namespace ASIST_UMG_api.Repository.Interfaces
{
    public interface iSedesCentros
    {
        bool RegistraSedeCentros(SedeCentro sedes);
        List<SedeCentro> ListadoSedesCentros();
    }
}
