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
    public class CreditoService : ICreditoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreditoService(IUnitOfWork unitOfWork) { 
         _unitOfWork = unitOfWork;
        }

        public IEnumerable<CreditoDto> GetCreditoList(int IdCliente)
        {
            var creditos = _unitOfWork.Repository<Credito>().Get(c => c.IdCliente == IdCliente);
            List<CreditoDto> creditoDto = new List<CreditoDto>();
            foreach (var credito in creditos)
            {
                CreditoDto dto = new CreditoDto();
                dto.FechaCierre = credito.FechaCierre;
                dto.FechaApro = credito.FechaApro;
                dto.IdComercio = credito.IdComercio;
                dto.Monto = credito.Monto;
                dto.IdCliente = credito.IdCliente;
                creditoDto.Add(dto);             
            }
            return creditoDto;
        }

        public void RealizarCredito(CreditoDto creditoDto)
        {
            var cliente = _unitOfWork.Repository<Cliente>().GetByID(creditoDto.IdCliente);
            if (cliente == null)
            {
                throw new Exception("No existe esta persona");
            }

            bool puedeComprar = (cliente.Deuda + creditoDto.Monto) < cliente.Cupo;

            if (puedeComprar)
            {
                Credito credito = new Credito()
                {
                    IdCliente = cliente.IdCliente,
                    IdComercio = creditoDto.IdComercio,
                    Monto = creditoDto.Monto,
                    FechaApro = creditoDto.FechaApro,
                    FechaCierre = creditoDto.FechaCierre
                };

                cliente.Deuda = (double)(cliente.Deuda + creditoDto.Monto);           
                _unitOfWork.Repository<Credito>().Insert(credito);
                _unitOfWork.Commit();
                return;
            }

            throw new Exception("sus deudas superan su cupo");

        }
    }
}
