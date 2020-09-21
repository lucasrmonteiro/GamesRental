using GamesRental.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesRental.Infra.DB.Context
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<Friend> friend { get; set; }
        public DbSet<Rental> rental { get; set; }
        public DbSet<Game> game { get; set; }
    }
}
