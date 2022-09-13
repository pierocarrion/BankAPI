using Microsoft.EntityFrameworkCore;
using Test_Backend.Contexts;
using Test_Backend.Models;

namespace Test_Backend.Repositories.ClienteRepository
{
    public class ClienteRepositoryImpl : IClienteRepository
    {
        private readonly DataBaseApiTestContext _context;
        public ClienteRepositoryImpl(DataBaseApiTestContext context)
        {
            _context = context;
        }
        public void InsertCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }
        public void UpdateCliente(Cliente cliente)
        {
            var clientFound = _context.Clientes.Where(x => x.ClienteId == cliente.ClienteId).FirstOrDefault();
            if (clientFound is not null)
            {
                clientFound.Contrasena = cliente.Contrasena;
                clientFound.Estado = cliente.Estado;
                SaveChanges();
            }
        }
        public void DeleteCliente(int clienteId)
        {
            var temp = _context.Clientes.Where(x => x.ClienteId == clienteId).FirstOrDefault();
            _context.Remove(temp);
        }
        public IEnumerable<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public void SaveChanges()
        {   
            _context.SaveChanges();
        }

        public Cliente GetClienteById(int clienteId)
        {
            return _context.Clientes.Where(x => x.ClienteId == clienteId)
                .Include(x => x.Cuentas)
                .ThenInclude(x => x.Movimientos)
                .Include(x => x.Persona)
                .FirstOrDefault();
        }
    }
}
