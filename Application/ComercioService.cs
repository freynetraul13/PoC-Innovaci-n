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
    public class ComercioService : IComercioService
    {
        public readonly IUnitOfWork _unitOfWork;
        public ComercioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CrearComercio(ComercioDto comercioDto)
        {
            var comercio = new Comercio()
            {
                IdComercio = comercioDto.IdComercio,
                Direccion = comercioDto.Direccion,
                Nombre = comercioDto.Nombre,
                Telefono = comercioDto.Telefono,
            };

            _unitOfWork.Repository<Comercio>().Insert(comercio);
            _unitOfWork.Commit();
        }
        public ComercioDto ObtenerComercio(int  idComercio)
        {
            var comercio = _unitOfWork.Repository<Comercio>().GetByID(idComercio);
            ComercioDto comercioDto = new ComercioDto()
            {
                IdComercio = idComercio,
                Direccion = comercio.Direccion,
                Nombre = comercio.Nombre,
                Telefono = comercio.Telefono,
            };
            return comercioDto;
        }
    }
}
