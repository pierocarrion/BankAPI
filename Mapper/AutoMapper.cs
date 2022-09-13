using AutoMapper;
using Test_Backend.DTOs;
using Test_Backend.DTOs.Cliente;
using Test_Backend.DTOs.Cuenta;
using Test_Backend.DTOs.Movimiento;
using Test_Backend.DTOs.Persona;
using Test_Backend.Models;

namespace Test_Backend
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //Cliente
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteForCreationDTO, Cliente>();
            CreateMap<ClienteForUpdateDTO, Cliente>();
            CreateMap<List<ClienteDTO> , IEnumerable<Cliente>>();
            //Movimiento
            CreateMap<Movimiento, MovimientoDTO>()
                .ForMember(dest => dest.Nombre, act => act.MapFrom(src => src.Cuenta.Cliente.Persona.Nombre))
                .ForMember(dest => dest.NumeroCuenta, act => act.MapFrom(src => src.Cuenta.NumeroCuenta));
            CreateMap<MovimientoForUpdateDTO, Movimiento>();
            CreateMap<MovimientoForCreationDTO, Movimiento>();
            CreateMap<List<MovimientoDTO>, IEnumerable<Movimiento>>();
            //Cuenta
            CreateMap<Cuenta, CuentaDTO>();
            CreateMap<CuentaForUpdateDTO, Cuenta>();
            CreateMap<CuentaForCreationDTO, Cuenta>();
            CreateMap<List<CuentaDTO>, IEnumerable<Cuenta>>();
            //Persona
            CreateMap<Persona, PersonaDTO>();
        }
    }
}
