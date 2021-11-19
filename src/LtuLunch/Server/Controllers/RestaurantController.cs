using LtuLunch.Server.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LtuLunch.Server.Controllers;

[ApiController]
public class RestaurantController : Controller
{
    private readonly LunchDbContext _lunchDbContext;

    public RestaurantController(LunchDbContext lunchDbContext)
    {
        _lunchDbContext = lunchDbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRestaurantInfo([FromQuery] string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest("Did not provide an id.");

        var restaurant = await _lunchDbContext.Resturants.FirstOrDefaultAsync(x => x.Id == id);

        if (restaurant != null)
            return Ok(restaurant);

        return BadRequest("No such restaurant");

    }

    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var results = await _lunchDbContext.Resturants.ToListAsync(); //TODO: this will be your downfall.
        if (results.Any())
            return Ok(results);

        return BadRequest("No restaurant exist.");
    }
}