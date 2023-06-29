using Application.DTO;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{

    public class ClienteService : IClienteService
    {
        public readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void CrearCliente(ClienteDTO clienteDto)
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = clienteDto.IdCliente,
                Apellido = clienteDto.Apellido,
                Cupo = clienteDto.Cupo,
                Deuda = clienteDto.Deuda,
                Direccion = clienteDto.Direccion,
                Nombre = clienteDto.Nombre,
                Telefono = clienteDto.Telefono
            };
            _unitOfWork.Repository<Cliente>().Insert(cliente);
            _unitOfWork.Commit();
        }
        public ClienteDTO ObtenerCliente(int clienteId)
        {
            var cliente = _unitOfWork.Repository<Cliente>().GetByID(clienteId);
            ClienteDTO dto = new ClienteDTO()
            {
                IdCliente = clienteId,
                Apellido = cliente.Apellido,
                Cupo = cliente.Cupo,
                Deuda = cliente.Deuda,
                Direccion = cliente.Direccion,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono
            };
            return dto;
        }

    }
}
