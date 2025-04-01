using ASIST_UMG_api.Models;

namespace ASIST_UMG_api.Repository.Interfaces
{
    public interface iCurso
    {
        bool RegistraCursos(Curso cursos);
        bool ActualizaCursos(Curso cursos);
        List<Curso> ListadoCursos();
        List<Curso> ListadoCursoPorNombre(string NombreCurso);

    }
}
