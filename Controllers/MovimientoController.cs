using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test_Backend.DTOs.Movimiento;
using Test_Backend.Models;
using Test_Backend.Services.MovimientoService;
using Test_Backend.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        private IMapper _mapper;
        public MovimientoController(IMovimientoService movimientoService, IMapper mapper)
        {
            _movimientoService = movimientoService;
            _mapper = mapper;
        }
        // GET: api/<MovimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<Movimiento>, List<MovimientoDTO>>(_movimientoService.GetAllMovimientos());
                return Ok(result);
            }
            catch (WebException ex)
            {
                return (IActionResult)HandlerWebException.HandleWebExceptions(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _mapper.Map<Movimiento, MovimientoDTO>(_movimientoService.GetMovimientoById(id));
                return Ok(result);
            }
            catch (WebException ex)
            {
                return (IActionResult)HandlerWebException.HandleWebExceptions(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public IActionResult Post(MovimientoForCreationDTO movimiento)
        {
            try
            {
                _movimientoService.InsertMovimiento(_mapper.Map<MovimientoForCreationDTO, Movimiento>(movimiento));
                return Ok("Transaccion realizada con exito");
            }
            catch (WebException ex)
            {
                return (IActionResult)HandlerWebException.HandleWebExceptions(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(MovimientoForUpdateDTO movimiento)
        {
            try
            {
                var result = _movimientoService.UpdateMovimiento(_mapper.Map<MovimientoForUpdateDTO, Movimiento>(movimiento));
                return Ok(result);
            }
            catch (WebException ex)
            {
                return (IActionResult)HandlerWebException.HandleWebExceptions(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int movimientoId)
        {
            try
            {
                var result = _movimientoService.DeleteMovimiento(movimientoId);
                return Ok(result);
            }
            catch (WebException ex)
            {
                return (IActionResult)HandlerWebException.HandleWebExceptions(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
