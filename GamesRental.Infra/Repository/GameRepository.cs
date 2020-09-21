using GamesRental.Domain.Entity;
using GamesRental.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Infra.Repository
{
    public class GameRepository : DomainRepository<Game>, IGameRepository
    {
        public GameRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
