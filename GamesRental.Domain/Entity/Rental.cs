using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Domain.Entity
{
    public class Rental : IIdentityEntity
    {
        public long FriendId { get; set; }
        public long GameId { get; set; }
        public Friend friend { get; set; }
        public Game game { get; set; }
        public long Id { get; set; }
    }
}
