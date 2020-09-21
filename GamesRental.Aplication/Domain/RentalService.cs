using GamesRental.Aplication.Base;
using GamesRental.Domain.Entity;
using GamesRental.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Aplication.Domain
{
    public class RentalService : ServiceBase<Rental> ,IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
