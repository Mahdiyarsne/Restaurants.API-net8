using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBrith  { get; set; }
    public string? Nationlity { get; set; }
}
