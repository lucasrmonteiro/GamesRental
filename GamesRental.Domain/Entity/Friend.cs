using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Domain.Entity
{
    public class Friend : IIdentityEntity
    {
        public long Id { get; set; }
        public string name { get; set; }

        public ICollection<Rental> rentals { get; set; }
    }
}
