using GamesRental.Aplication.Base;
using GamesRental.Domain.Entity;
using GamesRental.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Aplication.Domain
{
    public class FriendService : ServiceBase<Friend> ,IFriendService
    {
        private readonly IFriendRepository _repository;

        public FriendService(IFriendRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
