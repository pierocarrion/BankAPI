using Test_Backend.Models;

namespace Test_Backend.Repositories.CuentaRepository
{
    public interface ICuentaRepository
    {
        void InsertCuenta(Cuenta cuenta);
        void UpdateCuenta(Cuenta cuenta);
        void DeleteCuenta(int cuentaId);
        IEnumerable<Cuenta> GetAllCuentas();
        Cuenta GetCuentaById(int? cuentaId);
        void SaveChanges();
    }
}