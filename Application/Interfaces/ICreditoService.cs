using Application.DTO;
using Domain;

namespace Application.Interfaces
{
    public interface ICreditoService
    {
        void RealizarCredito(CreditoDto creditoDto);

        IEnumerable<CreditoDto> GetCreditoList(int IdCliente);
    }
}