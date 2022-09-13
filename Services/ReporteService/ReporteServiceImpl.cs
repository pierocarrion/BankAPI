using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test_Backend.DTOs.Cliente;
using Test_Backend.DTOs.Cuenta;
using Test_Backend.DTOs.Movimiento;
using Test_Backend.DTOs.Persona;
using Test_Backend.Models;
using Test_Backend.Repositories.CuentaRepository;
using Test_Backend.Services.ClienteService;
using Test_Backend.Services.MovimientoService;

namespace Test_Backend.Services.ReporteService
{
    public class ReporteServiceImpl : IReporteService
    {
        private readonly IClienteService _clienteService;
        private readonly IMovimientoService _movimientoService;
        private readonly ICuentaRepository _cuentaRepository;

        public ReporteServiceImpl()
        {
        }

        public ReporteServiceImpl(IClienteService clienteService, IMovimientoService movimientoService, ICuentaRepository cuentaRepository)
        {
            _clienteService = clienteService;
            _movimientoService = movimientoService;
            _cuentaRepository = cuentaRepository;
        }
        
        public Cliente GetEstadoDeCuenta(DateTime dateTimeFrom, DateTime dateTimeTo, int clienteId)
        {
            var cliente = _clienteService.GetClienteById(clienteId);
            var result = new Cliente
            {
                ClienteId = cliente.ClienteId,
                Estado = cliente.Estado,
                Persona = new Persona()
                {
                    Nombre = cliente.Persona.Nombre,
                    Identificacion = cliente.Persona.Identificacion,
                    Direccion = cliente.Persona.Direccion,
                    Telefono = cliente.Persona.Telefono
                }
            };
            
            foreach (var cuenta in cliente.Cuentas)
            {
                result.Cuentas.Add(new Cuenta
                {
                    CuentaId = cuenta.CuentaId,
                    Movimientos = cuenta.Movimientos.Where(x => x.Fecha >= dateTimeFrom && x.Fecha <= dateTimeTo).ToList(),
                    Estado = cuenta.Estado,
                    SaldoInicial = cuenta.SaldoInicial,
                    NumeroCuenta = cuenta.NumeroCuenta
                });
            }
            
            return result;
        }
    }
}
