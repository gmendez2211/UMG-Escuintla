using ASIST_UMG_api.Models.DTOs.cursos;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ASIST_UMG_api.Models.DTOs.facultades;

namespace ASIST_UMG_api.Controllers.v1
{
    public class FacultadesController : Controller
    {
        private readonly iFacultades _ctFacultades;
        private readonly IMapper _mapper;

        public FacultadesController(iFacultades ctFacultades, IMapper mapper)
        {
            _ctFacultades = ctFacultades;
            _mapper = mapper;
        }

        //Crear Registro de cursos       
        [HttpPost("facultades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(cRegistroFacultadesDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Facultades([FromBody] cRegistroFacultadesDto registroFacultadesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registroFacultadesDto == null)
            {
                return BadRequest(ModelState);
            }
            var Registro = _mapper.Map<Facultad>(registroFacultadesDto);

            if (Registro == null)
            {
                return NotFound();
            }

            if (!_ctFacultades.RegistraFacultad(Registro))
            {
                ModelState.AddModelError("", $"Error al grabar registro de la facultad {registroFacultadesDto.NombreFacultad}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        //Devuelve listado de facultades
        [HttpGet("DetalleFacultades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<cDetalleCursosDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult listadoSedesCentros()
        {
            var lstFac = _ctFacultades.ListadoFacultades();
            var listaFacDto = new List<cDetalleFacultadesDto>();

            foreach (var item in lstFac)
            {
                listaFacDto.Add(_mapper.Map<cDetalleFacultadesDto>(item));
            }
            return Ok(listaFacDto);

        }
    }
}
 