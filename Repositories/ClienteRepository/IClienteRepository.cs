using Test_Backend.Models;

namespace Test_Backend.Repositories.ClienteRepository
{
    public interface IClienteRepository
    {
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int clienteId);
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int clienteId);
        void SaveChanges();
    }
}