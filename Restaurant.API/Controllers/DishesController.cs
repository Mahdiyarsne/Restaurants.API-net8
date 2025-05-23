﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDishes;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurnt;
using Restaurants.Application.Dishes.Queries.GetDishForRestaurnt;

namespace Restaurant.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
public class DishesController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;

        var dishId= await mediator.Send(command);
        return CreatedAtAction(nameof(GetAllForRestaurant), new {restaurantId, dishId},null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurntQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId,[FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdForRestaurntQuery(restaurantId,dishId));
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));

        return NoContent();
    }
}
