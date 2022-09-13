using Test_Backend.DTOs.Movimiento;

namespace Test_Backend.DTOs.Cuenta
{
    public class CuentaDTO
    {
        public int CuentaId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public string? Estado { get; set; }
        public int? ClienteId { get; set; }
        public List<MovimientoDTO> Movimientos { get; set; }
    }
}
