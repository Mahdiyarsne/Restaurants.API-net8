using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurnt;

 public class GetDishesForRestaurntQuery(int restautantId) :IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; } = restautantId;
}   
