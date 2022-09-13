using System;
using System.Collections.Generic;

namespace Test_Backend.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuentas = new HashSet<Cuenta>();
        }

        public int ClienteId { get; set; }
        public string? Contrasena { get; set; }
        public string? Estado { get; set; }
        public int? PersonaId { get; set; } 

        public virtual Persona? Persona { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
