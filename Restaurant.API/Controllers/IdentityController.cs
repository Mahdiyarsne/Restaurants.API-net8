using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers;

[Route("api/identity")]
public class IdentityController:BaseApiController
{
    [HttpPatch("user")]
    public async Task<IActionResult> UpdateUserDetails()
    {

    }
}
