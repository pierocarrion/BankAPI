using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test_Backend.DTOs.Cuenta;
using Test_Backend.Models;
using Test_Backend.Services.CuentaService;
using Test_Backend.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        private IMapper _mapper;
        public CuentaController(ICuentaService cuentaService, IMapper mapper)
        {
            _cuentaService = cuentaService;
            _mapper = mapper;
        }
        // GET: api/<CuentaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<Cuenta>, List<CuentaDTO>>(_cuentaService.GetAllCuentas());
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

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _mapper.Map<Cuenta, CuentaDTO>(_cuentaService.GetCuentaById(id));
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

        // POST api/<CuentaController>
        [HttpPost]
        public IActionResult Post(CuentaForCreationDTO cuenta)
        {
            try
            {
                var result = _cuentaService.InsertCuenta(_mapper.Map<CuentaForCreationDTO, Cuenta>(cuenta));
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

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(CuentaForUpdateDTO cuenta)
        {
            try
            {
                var result = _cuentaService.UpdateCuenta(_mapper.Map<CuentaForUpdateDTO, Cuenta>(cuenta));
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

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int cuentaId)
        {
            try
            {
                var result = _cuentaService.DeleteCuenta(cuentaId);
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
