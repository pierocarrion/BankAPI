using Test_Backend.Models;
using Test_Backend.Repositories.ClienteRepository;

namespace Test_Backend.Services.ClienteService
{
    public class ClienteServiceImpl : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceImpl()
        {
        }

        public ClienteServiceImpl(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool DeleteCliente(int clienteId)
        {
            try
            {
                _clienteRepository.DeleteCliente(clienteId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _clienteRepository.SaveChanges();
            }
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            try
            {
                return _clienteRepository.GetAllClientes();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Cliente GetClienteById(int clienteId)
        {
            try
            {
                return _clienteRepository.GetClienteById(clienteId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool InsertCliente(Cliente cliente)
        {
            try
            {
                _clienteRepository.InsertCliente(cliente);
                _clienteRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCliente(Cliente cliente)
        {
            try
            {
                _clienteRepository.UpdateCliente(cliente);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _clienteRepository.SaveChanges();
            }
        }
    }
}
