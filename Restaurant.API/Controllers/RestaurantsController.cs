using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant is null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            int id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult>UpdateResturant([FromRoute] int id, UpdateRestaurantCommend commend)
        {
            commend.Id = id;
            var isUpdated = await mediator.Send(commend);
            if (isUpdated)
                return NoContent();

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant([FromRoute] int id)
        {
            var isDeleted  = await mediator.Send(new DeleteRestaurantCommend(id));
            if (isDeleted)
              return NoContent();

            return NotFound();
        }

    }
}
