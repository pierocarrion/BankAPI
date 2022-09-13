using Test_Backend.DTOs.Cuenta;
using Test_Backend.DTOs.Persona;

namespace Test_Backend.DTOs.Cliente
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string? Contrasena { get; set; }
        public string? Estado { get; set; }
        public PersonaDTO Persona { get; set; }
        public List<CuentaDTO> Cuentas { get; set; }
    }
}
