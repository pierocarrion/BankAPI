using Test_Backend.Models;
using Test_Backend.Repositories.CuentaRepository;
using Test_Backend.Repositories.MovimientoRepository;
using Test_Backend.Utils;

namespace Test_Backend.Services.MovimientoService
{
    public class MovimientoServiceImpl : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _CuentaRepository;

        public MovimientoServiceImpl()
        {
        }

        public MovimientoServiceImpl(IMovimientoRepository movimientoRepository, ICuentaRepository CuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _CuentaRepository = CuentaRepository;
        }

        public bool DeleteMovimiento(int movimientoId)
        {
            try
            {
                _movimientoRepository.DeleteMovimiento(movimientoId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _movimientoRepository.SaveChanges();
            }
        }

        public IEnumerable<Movimiento> GetAllMovimientos()
        {
            try
            {
                return _movimientoRepository.GetAllMovimientos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Movimiento GetMovimientoById(int movimientoId)
        {
            try
            {
                return _movimientoRepository.GetMovimientoById(movimientoId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertMovimiento(Movimiento movimiento)
        {
            try
            {
                if (movimiento.Valor is null)
                {
                    throw new Exception("Monto invalido");
                }
                var cuenta = _CuentaRepository.GetCuentaById(movimiento.CuentaId);
                if (cuenta.SaldoInicial == 0 && movimiento.Valor < 0)
                {
                    throw new Exception("Saldo no disponible");
                }
                if (movimiento.Valor < 0) //Debito
                {
                    decimal? validacionCupo = 0;
                    foreach (var transacciones in cuenta.Movimientos)
                    {
                        if (transacciones.Fecha.Value.Date == movimiento.Fecha.Value.Date)
                        {
                            validacionCupo += (transacciones.Valor < 0 ? transacciones.Valor : 0);
                        }
                    }
                    
                    if ((validacionCupo * -1) >= Constants.VALOR_MAXIMO)
                    {
                        throw new Exception("Cupo diario Excedido"); // Valor tope $1000
                    }

                    movimiento.TipoMovimiento = "Debito";
                    movimiento.Saldo = cuenta.SaldoInicial + movimiento.Valor;
                    cuenta.SaldoInicial += movimiento.Valor;
                }
                else //Credito
                {
                    movimiento.TipoMovimiento = "Credito";
                    movimiento.Saldo = cuenta.SaldoInicial + movimiento.Valor;
                    cuenta.SaldoInicial += movimiento.Valor;
                }
                
                _CuentaRepository.UpdateCuenta(cuenta);
                _movimientoRepository.InsertMovimiento(movimiento);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _movimientoRepository.SaveChanges();
            }
        }

        public bool UpdateMovimiento(Movimiento movimiento)
        {
            try
            {
                _movimientoRepository.UpdateMovimiento(movimiento);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _movimientoRepository.SaveChanges();
            }
        }
    }
}
