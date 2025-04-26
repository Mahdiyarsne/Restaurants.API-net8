using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommendHandler(ILogger<UpdateRestaurantCommendHandler> logger,
    IRestaurantRepository restaurantRepository,
    IMapper mapper
    ) : IRequestHandler<UpdateRestaurantCommend, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommend request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id :{RestaurantId} with {@UpdateRestaurant}", request.Id,request);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant is null)
            return false;

         mapper.Map( request ,restaurant);

     

        await restaurantRepository.SaveChanges();

        return true;
    }
}
