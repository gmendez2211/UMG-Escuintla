using ASIST_UMG_api.Models.DTOs;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ASIST_UMG_api.Models.DTOs.personas;
using ASIST_UMG_api.Models.DTOs.sedesCentros;
using ASIST_UMG_api.Models.DTOs.login;

namespace ASIST_UMG_api.Controllers.v1
{
    //[Route("api/[controller]")]  
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PersonaController : Controller
    {
        private readonly iPersonas _cPersonas;
        private readonly IMapper _mapper;

        public PersonaController(iPersonas cPersonas, IMapper mapper)
        {
            _cPersonas = cPersonas;
            _mapper = mapper;

        }
        //Crear Registro de personas       
        [HttpPost("personas")]
        [ProducesResponseType(StatusCodes.Status201Created,Type = typeof(IEnumerable<cRegistroPersonaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Persona([FromBody] cRegistroPersonaDto registroPersonaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registroPersonaDto == null)
            {
                return BadRequest(ModelState);
            }
            cRegistroLoginDto registroLoginDto = new cRegistroLoginDto();
            
      
                // Asignación de valores
                registroLoginDto.CorreoElectronico = "";
                registroLoginDto.EstadoUsuario = true;
                registroLoginDto.Contrasena = "UMG2025@";

            
            var Registro = _mapper.Map<Persona>(registroPersonaDto);
            var RegistroLogin = _mapper.Map<Login>(registroLoginDto);

            if (Registro == null)
            {
                return NotFound();
            }

            if (!_cPersonas.RegistraPersona(Registro, RegistroLogin))
            {
                ModelState.AddModelError("", $"Error al grabar registro de la persona {registroPersonaDto.PrimerNombre}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        //Devuelve reporte de peresonas
        [HttpGet("ReportePersonas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<cReportePersonasDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ReportePeresonas()
        {
            var rptPersonas = _cPersonas.ReportePersonas();
            var rptPersonasDto = new List<cRegistroPersonaDto>();

            foreach (var item in rptPersonas)
            {
                rptPersonasDto.Add(_mapper.Map<cRegistroPersonaDto>(item));
            }
            return Ok(rptPersonasDto);

        }
        //Devuelve reporte de persons por Sedes
        [HttpGet("{idCentro:int}", Name = "ReportePersonasPorSede")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<cReportePersonasDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ReportePeresonasPorSedeCentros(int idCentro)
        {
            var rptPersonas = _cPersonas.ReportePersonasPorCentros(idCentro);
            var rptPersonasDto = new List<cRegistroPersonaDto>();

            foreach (var item in rptPersonas)
            {
                rptPersonasDto.Add(_mapper.Map<cRegistroPersonaDto>(item));
            }
            return Ok(rptPersonasDto);

        }
    }
}
