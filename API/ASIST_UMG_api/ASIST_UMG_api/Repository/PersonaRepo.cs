using ASIST_UMG_api.Funciones;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;

namespace ASIST_UMG_api.Repository
{

    public class PersonaRepo:iPersonas
    {
        private readonly UmgContext _dbContext;

        public PersonaRepo(UmgContext dBContext)
        {
            _dbContext = dBContext;
        }

        public bool RegistraPersona(Persona persona, Login login)
        {
            try
            {
                //Graba login del usuario
                //using (var context = new UmgContext())
                //{
                //    context.Logins.Attach(login);
                //    context.Entry(login).Property(x => x.NombreCurso).IsModified = true; //Permite actualizar nombre de curso
                //    context.Entry(login).Property(x => x.Descripcion).IsModified = true; //Permite actualizar descripcion de curso
                //    return context.SaveChanges() >= 0 ? true : false;
                //}

                login.IdLogin = cGeneracionID.cGeneraID();
                login.CorreoElectronico = persona.CorreoElectronico;
                login.EstadoUsuario = true;
                login.Contrasena = "UMG2025@";
                _dbContext.Logins.Add(login);


                persona.IdPersona = cGeneracionID.cGeneraID();
                _dbContext.Personas.Add(persona);
                return Save();
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error al registrar persona", ex.ToString());
                return false;
            }
        }
        public List<Persona> ReportePersonas()
        {
            return _dbContext.Personas.OrderBy(s => s.IdPersona).ToList();

        }
        public List<Persona> ReportePersonasPorCentros(int idSedeCentro)
        {
            return _dbContext.Personas.OrderBy(s => s.IdPersona).Where(p=>p.IdSedeCentro == idSedeCentro).ToList();

        }
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
