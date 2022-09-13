using System;
using System.Collections.Generic;

namespace Test_Backend.Models
{
    public partial class Movimiento
    {
        public int MovimientoId { get; set; }
        public DateTime? Fecha { get; set; }
        public string? TipoMovimiento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
        public int? CuentaId { get; set; }

        public virtual Cuenta? Cuenta { get; set; }
    }
}
