using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurnt;
public class GetDishesForRestaurntQueryHandler(ILogger<GetDishesForRestaurntQueryHandler> logger,
    IRestaurantRepository restaurantRepository,
    IMapper mapper)
    : IRequestHandler<GetDishesForRestaurntQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurntQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dishes for restaurant with id {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId) 
            ?? throw new NotFoundException(nameof(Restaurant) , request.RestaurantId.ToString());


        var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return results;
    }
}
