using System;
using System.Collections.Generic;

namespace Test_Backend.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int CuentaId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public string? Estado { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
