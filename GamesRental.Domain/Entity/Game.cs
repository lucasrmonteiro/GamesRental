using System;
using System.Collections.Generic;

namespace GamesRental.Domain.Entity
{
    public class Game : IIdentityEntity
    {
        public long Id { get; set; }
        public string name { get; set; }
        public ICollection<Rental> rentals { get; set; }
    }
}
