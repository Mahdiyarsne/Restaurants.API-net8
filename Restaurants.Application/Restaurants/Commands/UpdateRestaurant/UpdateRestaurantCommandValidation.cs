using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidation : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidation()
        {
            RuleFor(c => c.Name)
                .Length(3, 100); 
        }
    }
}