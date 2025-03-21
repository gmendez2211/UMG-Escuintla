using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs;

namespace ASIST_UMG_api.Repository.Interfaces
{
    public interface iMarcajes
    {
        bool RegistraMarcarje(Marcaje marcaje);
        List<Marcaje> MarcajesPorFecha(Marcaje marcaje);
        //ICollection<marcaje> GetMarcajePorPersona(int id_persona);
    }
}
