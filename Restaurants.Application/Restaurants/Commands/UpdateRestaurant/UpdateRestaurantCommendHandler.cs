using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommendHandler(ILogger<UpdateRestaurantCommendHandler> logger,
    IRestaurantRepository restaurantRepository,
    IMapper mapper
    ) : IRequestHandler<UpdateRestaurantCommend>
{
    public async Task Handle(UpdateRestaurantCommend request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id :{RestaurantId} with {@UpdateRestaurant}", request.Id,request);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        mapper.Map( request ,restaurant);

     

        await restaurantRepository.SaveChanges();

        
    }
}
