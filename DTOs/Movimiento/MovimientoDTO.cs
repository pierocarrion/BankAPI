using Test_Backend.DTOs.Cuenta;

namespace Test_Backend.DTOs.Movimiento
{
    public class MovimientoDTO
    {
        public int MovimientoId { get; set; }
        public DateTime? Fecha { get; set; }
        public string? TipoMovimiento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
        public int? CuentaId { get; set; }
        public string Nombre { get; set; }      
        public string NumeroCuenta { get; set; }
    }
}
