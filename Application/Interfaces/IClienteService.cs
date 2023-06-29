using Application.DTO;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        void CrearCliente(ClienteDTO clienteDto);
        ClienteDTO ObtenerCliente(int clienteId);
    }
}