using ASIST_UMG_api.Data;
using ASIST_UMG_api.Funciones;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs;
using ASIST_UMG_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASIST_UMG_api.Repository
{
    public class MarcajeRepo : iMarcajes
    {
        private readonly UmgContext _dbContext;

        public MarcajeRepo(UmgContext dBContext)
        {
            _dbContext = dBContext;
        }
        public ICollection<Marcaje> GetMarcajePorPersona(int id_persona)
        {
            throw new NotImplementedException();
        }

        public List<Marcaje> MarcajesPorFecha(Marcaje marcaje)
        {
            var cMarcajesPorFecha = new List<Marcaje>();
            try
            {

                cMarcajesPorFecha = (List<Marcaje>)(from marcajes in _dbContext.Set<Marcaje>()
                                                    join cursos in _dbContext.Set<Curso>()
                                                        on marcajes.IdCurso equals cursos.IdCurso
                                                    where marcajes.Fecha == marcaje.Fecha
                                                    select new
                                                    {
                                                        IdPersona = marcajes.IdPersona,
                                                        Curso = cursos.Descripcion,
                                                        Fecha = marcajes.Fecha,
                                                        HoraEntrada = marcajes.HoraInicio,
                                                        HoraSalida = marcajes.HoraFinal
                                                    });

                
            }catch(Exception ex)
            {
                Console.WriteLine("No se encontró registro ", ex.ToString());
            }

            return cMarcajesPorFecha.ToList();

        }

        public bool RegistraMarcarje(Marcaje Regmarcaje)
        {
            try
            {
                Regmarcaje.IdMarcaje = cGeneracionID.cGeneraID();
                _dbContext.Marcajes.Add(Regmarcaje);
                return Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar registro", ex.ToString());
                return false;
            }


        }
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

    }
}
