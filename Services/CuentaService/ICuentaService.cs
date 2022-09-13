using Test_Backend.Models;

namespace Test_Backend.Services.CuentaService
{
    public interface ICuentaService
    {
        bool InsertCuenta(Cuenta cuenta);
        bool UpdateCuenta(Cuenta cuenta);
        bool DeleteCuenta(int cuentaId);
        IEnumerable<Cuenta> GetAllCuentas();
        Cuenta GetCuentaById(int cuentaId);
    }
}