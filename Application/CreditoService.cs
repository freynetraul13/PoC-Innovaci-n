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

    }
}
