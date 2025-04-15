using ASIST_UMG_api.Funciones;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;

namespace ASIST_UMG_api.Repository
{
    public class cFacultadesRepo : iFacultades
    {
        private readonly UmgContext _dbContext;

        public cFacultadesRepo(UmgContext _dbcontextumg)
        {
            _dbContext = _dbcontextumg;
        }
        public bool ActualizaFacultad(Facultad facultades)
        {
            throw new NotImplementedException();
        }

        public List<Facultad> ListadoFacultades()
        {
            return _dbContext.Facultads.OrderBy(s => s.NombreFacultad).ToList();
        }

        public bool RegistraFacultad(Facultad facultades)
        {
            try
            {

                facultades.IdFacultad = cGeneracionID.cGeneraID();
                _dbContext.Facultads.Add(facultades);
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
