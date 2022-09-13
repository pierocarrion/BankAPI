using Microsoft.EntityFrameworkCore;
using Test_Backend.Contexts;
using Test_Backend.Models;

namespace Test_Backend.Repositories.CuentaRepository
{
    public class CuentaRepositoryImpl : ICuentaRepository
    {
        private readonly DataBaseApiTestContext _context;
        public CuentaRepositoryImpl(DataBaseApiTestContext context)
        {
            _context = context;
        }
        public void InsertCuenta(Cuenta Cuenta)
        {
            _context.Cuenta.Add(Cuenta);
        }
        public void UpdateCuenta(Cuenta cuenta)
        {
            var cuentaFound = _context.Cuenta.Where(x => x.CuentaId == cuenta.CuentaId).FirstOrDefault();
            if (cuentaFound is not null)
            {
                cuentaFound.NumeroCuenta = cuenta.NumeroCuenta;
                cuentaFound.TipoCuenta = cuenta.TipoCuenta;
                cuentaFound.SaldoInicial = cuenta.SaldoInicial;
                cuentaFound.Estado = cuenta.Estado;
                SaveChanges();
            }
        }
        public void DeleteCuenta(int CuentaId)
        {
            var temp = _context.Cuenta.Where(x => x.CuentaId == CuentaId).FirstOrDefault();
            _context.Remove(temp);
        }
        public IEnumerable<Cuenta> GetAllCuentas()
        {
            return _context.Cuenta.ToList();
        }

        public void SaveChanges()
        {   
            _context.SaveChanges();
        }

        public Cuenta GetCuentaById(int? cuentaId)
        {
            var cuenta = _context.Cuenta.Where(x => x.CuentaId == cuentaId)
                .Include(x=> x.Movimientos)
                .FirstOrDefault();
            if (cuenta is null)
            {
                throw new Exception("Cuenta no existe");
            }
            return cuenta;
        }
    }
}
