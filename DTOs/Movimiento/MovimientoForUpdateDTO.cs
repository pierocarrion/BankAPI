namespace Test_Backend.DTOs.Movimiento
{
    public class MovimientoForUpdateDTO
    {
        public int MovimientoId { get; set; }
        public DateTime? Fecha { get; set; }
        public string? TipoMovimiento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
        public int? CuentaId { get; set; }
    }
}
