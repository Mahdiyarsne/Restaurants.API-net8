using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.API.Controllers;

[Authorize]
[Route("api/restaurants")]
public class RestaurantsController(IMediator mediator) :BaseApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "<id claim type>")!.Value;
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateResturant([FromRoute] int id, UpdateRestaurantCommand commend)
    {
        commend.Id = id;
        await mediator.Send(commend);

        return NoContent();

    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResturant([FromRoute] int id)
    {
        await mediator.Send(new DeleteRestaurantCommend(id));

        return NotFound();
    }

}
