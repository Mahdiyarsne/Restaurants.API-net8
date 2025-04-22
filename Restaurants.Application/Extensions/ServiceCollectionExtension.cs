using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;


namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtenson
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtenson).Assembly;

        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
    }
}