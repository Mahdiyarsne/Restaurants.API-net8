using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurnt
{
    internal class GetDishByIdForRestaurntQueryHandler(
        ILogger<GetDishByIdForRestaurntQueryHandler> logger,
        IRestaurantRepository restaurantRepository,
        IMapper mapper
        ) : IRequestHandler<GetDishByIdForRestaurntQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurntQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id {RestaurantId}",
                 request.DishId,
                request.RestaurantId );

            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId)
                ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());


            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId) 
                    ?? throw new NotFoundException(nameof(Dish), request.DishId.ToString());

            var result = mapper.Map<DishDto>(dish); 
            return result;
        }
    }
}
