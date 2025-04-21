using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantService(IRestaurantRepository restaurantRepository,
    ILogger<RestaurantService> logger, IMapper mapper) : IRestaurantService
{
    public async Task<int> Create(CreateRestaurantDto restaurantDto)
    {
        logger.LogInformation("Creating a new restaurant");
        var restautant = mapper.Map<Restaurant>(restaurantDto);
        int id = await restaurantRepository.Create(restautant);

        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDto!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurants {id}");

        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var resturantDto = mapper.Map<RestaurantDto?>(restaurant);
        return resturantDto;

    }
}
