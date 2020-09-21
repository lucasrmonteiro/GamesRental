using GamesRental.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Infra.Repository
{
    public class RentalRepository : DomainRepository<Rental> ,IRentalRepository
    {
        public RentalRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
