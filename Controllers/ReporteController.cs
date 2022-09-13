using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test_Backend.DTOs.Cliente;
using Test_Backend.Models;
using Test_Backend.Services.ReporteService;
using Test_Backend.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteService _reporteService;
        private IMapper _mapper;
        public ReporteController(IReporteService reporteService, IMapper mapper)
        {
            _reporteService = reporteService;
            _mapper = mapper;
        }
        [HttpGet("Estado de Cuenta")]
        public IActionResult GetEstadoDeCuenta(DateTime dateTimeFrom, DateTime dateTimeTo, int clienteId)
        {
            try
            {
                var result = _mapper.Map<Cliente,ClienteDTO>(_reporteService.GetEstadoDeCuenta(dateTimeFrom , dateTimeTo, clienteId));
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
