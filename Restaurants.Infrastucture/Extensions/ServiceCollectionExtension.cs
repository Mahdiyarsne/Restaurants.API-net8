using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastucture.Persistence;
using Restaurants.Infrastucture.Repositories;
using Restaurants.Infrastucture.Seeders;

namespace Restaurants.Infrastucture.Extensions;

public static class ServiceCollectionExtensهon
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestautantDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("RestaurantDb"))
          .EnableSensitiveDataLogging()
        );

        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();

    }
}
