using Test_Backend.Models;

namespace Test_Backend.Repositories.MovimientoRepository
{
    public interface IMovimientoRepository
    {
        void InsertMovimiento(Movimiento movimiento);
        void UpdateMovimiento(Movimiento movimiento);
        void DeleteMovimiento(int movimientoId);
        IEnumerable<Movimiento> GetAllMovimientos();
        Movimiento GetMovimientoById(int movimientoId);
        void SaveChanges();
    }
}