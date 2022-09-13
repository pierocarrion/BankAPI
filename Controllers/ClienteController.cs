using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test_Backend.DTOs.Cliente;
using Test_Backend.Models;
using Test_Backend.Services.ClienteService;
using Test_Backend.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private IMapper _mapper;
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(_clienteService.GetAllClientes());
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

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _mapper.Map<Cliente, ClienteDTO>(_clienteService.GetClienteById(id));
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

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post(ClienteForCreationDTO cliente)
        {
            try
            {
                var result = _clienteService.InsertCliente(_mapper.Map<ClienteForCreationDTO, Cliente>(cliente));
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

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ClienteForUpdateDTO cliente)
        {
            try
            {
                var result = _clienteService.UpdateCliente(_mapper.Map<ClienteForUpdateDTO, Cliente>(cliente));
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

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int clienteId)
        {
            try
            {
                var result = _clienteService.DeleteCliente(clienteId);
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
