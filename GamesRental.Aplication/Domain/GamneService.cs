using GamesRental.Aplication.Base;
using GamesRental.Aplication.Domain;
using GamesRental.Domain.Entity;
using GamesRental.Infra.Repository;
using System;

namespace GamesRental.Aplication
{
    public class GamneService : ServiceBase<Game> ,IGamneService
    {
        private readonly IGameRepository _repository;

        public GamneService(IGameRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
