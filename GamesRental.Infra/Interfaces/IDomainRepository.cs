using GamesRental.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Infra.Interfaces
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity 
    {
    }
}
