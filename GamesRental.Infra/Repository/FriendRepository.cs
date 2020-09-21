using GamesRental.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Infra.Repository
{
    public class FriendRepository : DomainRepository<Friend> ,IFriendRepository
    {
        public FriendRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
