using ASIST_UMG_api.Models.DTOs.sedesCentros;
using ASIST_UMG_api.Models;
using Microsoft.AspNetCore.Mvc;
using ASIST_UMG_api.Models.DTOs.cursos;
using ASIST_UMG_api.Repository.Interfaces;
using AutoMapper;

namespace ASIST_UMG_api.Controllers.v1
{
    //[Route("api/[controller]")]  
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CursosController : Controller
    {

        private readonly iCurso _ctCursos;
        private readonly IMapper _mapper;

        public CursosController(iCurso ctCursos, IMapper mapper)
        {
            _ctCursos = ctCursos;
            _mapper = mapper;
        }
        //Crear Registro de cursos       
        [HttpPost("cursos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Cursos ([FromBody] cRegistroCursoDto registroCursosDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registroCursosDto == null)
            {
                return BadRequest(ModelState);
            }
            var Registro = _mapper.Map<Curso>(registroCursosDto);

            if (Registro == null)
            {
                return NotFound();
            }

            if (!_ctCursos.RegistraCursos(Registro))
            {
                ModelState.AddModelError("", $"Error al grabar registro del centro {registroCursosDto.NombreCurso}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        //Devuelve listado de Cursos
        [HttpGet("DetalleCursos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<cDetalleCursosDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult listadoSedesCentros()
        {
            var lstCursos = _ctCursos.ListadoCursos();
            var listaCursosDto = new List<cDetalleCursosDto>();

            foreach (var item in lstCursos)
            {
                listaCursosDto.Add(_mapper.Map<cDetalleCursosDto>(item));
            }
            return Ok(listaCursosDto);

        }

        //Actualiza nombre de cursos
        [HttpPut("ActualizaNombreCurso")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<cActualizaCursoDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCatalogo([FromBody] cActualizaCursoDto actualizaCursoDto)
        {

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Esta entrando aqui");
                return BadRequest(ModelState);
            }

            if (actualizaCursoDto == null)
            {
                return BadRequest(ModelState);
            }

            var curso = _mapper.Map<Curso>(actualizaCursoDto);
            if (curso == null)
            {
                return NotFound();
            }

            if (!_ctCursos.ActualizaCursos(curso))
            {
                ModelState.AddModelError("", $"Error al actuualizar registro en base de datos {curso.NombreCurso}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
