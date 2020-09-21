using GamesRental.Aplication;
using GamesRental.Aplication.Base;
using GamesRental.Aplication.Domain;
using GamesRental.Infra.DB.Context;
using GamesRental.Infra.Interfaces;
using GamesRental.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.IoC
{
    public static class ServicesIoC
    {
        private static IServiceCollection ApplicationServicesIoC(IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IRentalService, RentalService>();

            return services;
        }

        private static IServiceCollection ApplicationRepositoryIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();

            return services;
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            ApplicationRepositoryIoC(services);
            ApplicationServicesIoC(services);
        }
    }
}
