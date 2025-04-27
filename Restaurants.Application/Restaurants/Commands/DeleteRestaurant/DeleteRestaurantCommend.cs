using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommend(int id) : IRequest
{
    public int Id { get; } = id;
}
