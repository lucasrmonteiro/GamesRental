using GamesRental.Domain.Entity;
using GamesRental.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Infra.Repository
{
    public interface IRentalRepository : IDomainRepository<Rental>
    {
    }
}
