using Microsoft.EntityFrameworkCore;
using Test_Backend.Contexts;
using Test_Backend.Models;

namespace Test_Backend.Repositories.MovimientoRepository
{
    public class MovimientoRepositoryImpl : IMovimientoRepository
    {
        private readonly DataBaseApiTestContext _context;
        public MovimientoRepositoryImpl(DataBaseApiTestContext context)
        {
            _context = context;
        }
        public void InsertMovimiento(Movimiento Movimiento)
        {
            _context.Movimientos.Add(Movimiento);
        }
        public void UpdateMovimiento(Movimiento movimiento)
        {
            var movimientoFound = _context.Movimientos.Where(x => x.MovimientoId == movimiento.MovimientoId).FirstOrDefault();
            if (movimientoFound is not null)
            {
                movimientoFound.Fecha = movimiento.Fecha;
                movimientoFound.TipoMovimiento = movimiento.TipoMovimiento;
                movimientoFound.Valor = movimiento.Valor;
                movimientoFound.Saldo = movimiento.Saldo;
                SaveChanges();
            }
        }
        public void DeleteMovimiento(int MovimientoId)
        {
            var temp = _context.Movimientos.Where(x => x.MovimientoId == MovimientoId).FirstOrDefault();
            _context.Remove(temp);
        }
        public IEnumerable<Movimiento> GetAllMovimientos()
        {
            return _context.Movimientos.ToList();
        }

        public void SaveChanges()
        {   
            _context.SaveChanges();
        }

        public Movimiento GetMovimientoById(int movimientoId)
        {
            return _context.Movimientos.Where(x => x.MovimientoId == movimientoId)
                .Include(x => x.Cuenta)
                .ThenInclude(x => x.Cliente)
                .ThenInclude(x => x.Persona)
                .FirstOrDefault();
        }
    }
}
