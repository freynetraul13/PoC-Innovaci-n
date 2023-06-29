using Application.DTO;

namespace Application.Interfaces
{
    public interface IComercioService
    {
        void CrearComercio(ComercioDto comercioDto);
        ComercioDto ObtenerComercio(int idComercio);
    }
}