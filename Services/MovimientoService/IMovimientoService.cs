using Test_Backend.Models;

namespace Test_Backend.Services.MovimientoService
{
    public interface IMovimientoService
    {
        void InsertMovimiento(Movimiento movimiento);
        bool UpdateMovimiento(Movimiento movimiento);
        bool DeleteMovimiento(int movimientoId);
        IEnumerable<Movimiento> GetAllMovimientos();
        Movimiento GetMovimientoById(int movimientoId);
    }
}