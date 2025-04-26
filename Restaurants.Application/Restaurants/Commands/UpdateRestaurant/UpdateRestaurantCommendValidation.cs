using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommendValidation : AbstractValidator<UpdateRestaurantCommend>
    {
        public UpdateRestaurantCommendValidation()
        {
            RuleFor(c => c.Name)
                .Length(3, 100); 
        }
    }
}