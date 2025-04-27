using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommendHandler(ILogger<DeleteRestaurantCommendHandler> logger,
    IRestaurantRepository restaurantRepository
    ) : IRequestHandler<DeleteRestaurantCommend>
{
    public async Task Handle(DeleteRestaurantCommend request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id :{RestaurantId}", request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Restaurant) ,request.Id.ToString());
        await restaurantRepository.Delete(restaurant);
      
    }

}
