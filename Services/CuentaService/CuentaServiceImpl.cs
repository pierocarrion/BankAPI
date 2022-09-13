using Test_Backend.Models;
using Test_Backend.Repositories.CuentaRepository;

namespace Test_Backend.Services.CuentaService
{
    public class CuentaServiceImpl : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaServiceImpl()
        {
        }

        public CuentaServiceImpl(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public bool DeleteCuenta(int cuentaId)
        {
            try
            {
                _cuentaRepository.DeleteCuenta(cuentaId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _cuentaRepository.SaveChanges();
            }
        }

        public IEnumerable<Cuenta> GetAllCuentas()
        {
            try
            {
                return _cuentaRepository.GetAllCuentas();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Cuenta GetCuentaById(int cuentaId)
        {
            try
            {
                return _cuentaRepository.GetCuentaById(cuentaId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool InsertCuenta(Cuenta cuenta)
        {
            try
            {
                _cuentaRepository.InsertCuenta(cuenta);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _cuentaRepository.SaveChanges();
            }
        }

        public bool UpdateCuenta(Cuenta cuenta)
        {
            try
            {
                _cuentaRepository.UpdateCuenta(cuenta);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _cuentaRepository.SaveChanges();
            }
        }
    }
}
