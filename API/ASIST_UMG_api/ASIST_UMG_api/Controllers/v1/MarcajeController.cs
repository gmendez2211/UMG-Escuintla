using ASIST_UMG_api.Models.DTOs;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASIST_UMG_api.Controllers.v1
{
    //[Route("api/[controller]")]  
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MarcajeController : Controller
    {
        private readonly iMarcajes _ctMarcaje;
        private readonly IMapper _mapper;

        public MarcajeController(iMarcajes ctMarcaje, IMapper mapper)
        {
            _ctMarcaje = ctMarcaje;
            _mapper = mapper;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //Crear Registro de marcaje       
        [HttpPost("marcaje")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Marcaje([FromBody] cRegistroMarcajeDto registroMarcajeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registroMarcajeDto == null)
            {
                return BadRequest(ModelState);
            }
            var Registro = _mapper.Map<Marcaje>(registroMarcajeDto);

            if (Registro == null)
            {
                return NotFound();
            }

            if (!_ctMarcaje.RegistraMarcarje(Registro))
            {
                ModelState.AddModelError("", $"Error al grabar registro de la persona {registroMarcajeDto.IdPersona}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    
/*
    //Consulta Registro de marcaje por fecha      
        [HttpGet(Name = "marcajePorFecha")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult marcajePorFecha(FromBody] cParamMarcaje registroMarcajeDto)
        {



            var itemCurso = _ctMarcaje.MarcajesPorFecha(FechaMarcaje);

            if (itemCurso == null)
            {
                return NotFound();
            }

            var itemMarcajePorFecha = _mapper.Map<cDetalleMarcajeDto>(itemCurso);
            return Ok(itemMarcajePorFecha);
        }*/
    }
    }
