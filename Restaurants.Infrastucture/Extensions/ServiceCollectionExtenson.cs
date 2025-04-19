using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurants.Infrastucture.Persistence;
using Restaurants.Infrastucture.Seeders;

namespace Restaurants.Infrastucture.Extensions;

public static class ServiceCollectionExtenson 
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestautantDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("RestaurantDb"))
        );

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
    }
}
