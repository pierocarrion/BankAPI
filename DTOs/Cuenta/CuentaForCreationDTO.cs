namespace Test_Backend.DTOs.Cuenta
{
    public class CuentaForCreationDTO
    {
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public string? Estado { get; set; }
        public int? ClienteId { get; set; }
    }
}
