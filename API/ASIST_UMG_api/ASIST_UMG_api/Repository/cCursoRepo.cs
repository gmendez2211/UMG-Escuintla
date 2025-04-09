using ASIST_UMG_api.Funciones;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;

namespace ASIST_UMG_api.Repository
{

    public class cCursoRepo : iCurso
    {
        private readonly UmgContext _dbContext;

        public cCursoRepo(UmgContext _dbcontextumg)
        {
            _dbContext = _dbcontextumg;
        }
        public bool ActualizaCursos(Curso cursos)
        {
            using (var context = new UmgContext())
            {
                context.Cursos.Attach(cursos);
                context.Entry(cursos).Property(x => x.NombreCurso).IsModified = true; //Permite actualizar nombre de curso
                context.Entry(cursos).Property(x => x.Descripcion).IsModified = true; //Permite actualizar descripcion de curso
                return context.SaveChanges() >= 0 ? true : false;
            }
        }

        public List<Curso> ListadoCursoPorNombre(string NombreCurso)
        {
            throw new NotImplementedException();
        }

        public List<Curso> ListadoCursos()
        {
            return _dbContext.Cursos.OrderBy(s => s.NombreCurso).ToList();
        }

        public bool RegistraCursos(Curso cursos)
        {
            try
            {
                
                cursos.IdCurso = cGeneracionID.cGeneraID();
                _dbContext.Cursos.Add(cursos);
                return Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al grabar el registro", ex.ToString());
                return false;
            }
        }
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
