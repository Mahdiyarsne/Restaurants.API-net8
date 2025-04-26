using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommendHandler(ILogger<DeleteRestaurantCommendHandler> logger,
    IRestaurantRepository restaurantRepository
    ) : IRequestHandler<DeleteRestaurantCommend,bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommend request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id :{RestaurantId}",request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant is null)
            return false;

        await restaurantRepository.Delete(restaurant);
        return true;             
    }

}
