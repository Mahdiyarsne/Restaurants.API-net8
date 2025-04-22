using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidation : AbstractValidator<CreateRestaurantDto>
{
    public CreateRestaurantDtoValidation()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
        .NotEmpty().WithMessage("Insert a vaild category.");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("Please provide a vaild email address");

        RuleFor(dto => dto.PostalCode)
        .Matches(@"^\d{2}-\d{3}$")
        .WithMessage("Please provide a vaild postal code (XX-XXX).");
        
    }
}
