﻿
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Restaurants.Application.User;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = (httpContextAccessor?.HttpContext?.User)
            ?? throw new InvalidOperationException("User Context is not present");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);


        return new CurrentUser(userId, email, roles);
    }
}
