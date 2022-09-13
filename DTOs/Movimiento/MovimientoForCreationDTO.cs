namespace Test_Backend.DTOs.Movimiento
{
    public class MovimientoForCreationDTO
    {
        public DateTime? Fecha { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
        public int? CuentaId { get; set; }
    }
}
