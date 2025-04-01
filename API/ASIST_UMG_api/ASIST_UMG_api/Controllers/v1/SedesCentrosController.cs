using ASIST_UMG_api.Models.DTOs.personas;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ASIST_UMG_api.Models.DTOs.sedesCentros;

namespace ASIST_UMG_api.Controllers.v1
{
    //[Route("api/[controller]")]  
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SedesCentrosController : Controller
    {
        private readonly iSedesCentros _ctSedes;
        private readonly IMapper _mapper;

        public SedesCentrosController(iSedesCentros sedesCentros, IMapper mapper)
        {
            _ctSedes = sedesCentros;
            _mapper = mapper;
        }

        //Crear Registro de personas       
        [HttpPost("sedes")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SedesCentros([FromBody] cRegistroSedeCentroDto registroSedesCentrosDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registroSedesCentrosDto == null)
            {
                return BadRequest(ModelState);
            }
            var Registro = _mapper.Map<SedeCentro>(registroSedesCentrosDto);

            if (Registro == null)
            {
                return NotFound();
            }

            if (!_ctSedes.RegistraSedeCentros(Registro))
            {
                ModelState.AddModelError("", $"Error al grabar registro del centro {registroSedesCentrosDto.NombreSede}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        //Devuelve listado de sedes y centros
        [HttpGet("DetalleSedes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<cDetalleSedesCentrosDto>))]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult listadoSedesCentros()
        {
            var listSedes = _ctSedes.ListadoSedesCentros();
            var listaSedesDto = new List<cDetalleSedesCentrosDto>();

            foreach (var item in listSedes)
            {
                listaSedesDto.Add(_mapper.Map<cDetalleSedesCentrosDto>(item));
            }
            return Ok(listaSedesDto);

        }
    }
}
