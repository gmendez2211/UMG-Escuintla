using ASIST_UMG_api.Funciones;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASIST_UMG_api.Repository
{
    public class cSedesCentrosRepo : iSedesCentros
    {
        private readonly UmgContext _dbContext;

        public cSedesCentrosRepo(UmgContext umgContext)
        {
            _dbContext = umgContext;
        }
        public bool RegistraSedeCentros(SedeCentro sedes)
        {
            try
            {
                sedes.IdSedeCentro = cGeneracionID.cGeneraID();
                _dbContext.SedeCentros.Add(sedes);
                return Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al grabar el registro", ex.ToString());
                return false;
            }


        }
       public List<SedeCentro> ListadoSedesCentros()
        {
            return _dbContext.SedeCentros.OrderBy(s=>s.IdSedeCentro).ToList();

        }
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

    }
}
