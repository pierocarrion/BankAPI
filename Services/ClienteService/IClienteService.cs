using Test_Backend.Models;

namespace Test_Backend.Services.ClienteService
{
    public interface IClienteService
    {
        bool InsertCliente(Cliente cliente);
        bool UpdateCliente(Cliente cliente);
        bool DeleteCliente(int clienteId);
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int clienteId);
    }
}