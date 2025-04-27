using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurant.API.Controllers;

[Route("api/restaurant/{restaurantsId}/dishes")]
public class DishesController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantsId ,CreateDishCommand command)
    {
        command.RestaurantId = restaurantsId;

        await mediator.Send(command);
        return Created();
    }
}
