using System.Linq;
using System.Threading.Tasks;
using LtuLunch.Server.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace LtuLunch.Server.Controllers
{
    [ApiController]
    [Route("/api/restaurant")]
    public class RestaurantController : Controller
    {
        private readonly LunchDbContext _lunchDbContext;

        public RestaurantController(LunchDbContext lunchDbContext)
        {
            _lunchDbContext = lunchDbContext;
        }
    
        [HttpGet]
        [Route("byId")]
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
        [Route("")]
        public async Task<IActionResult> GetRestaurants()
        {
            var results = await _lunchDbContext.Resturants.ToListAsync(); //TODO: this will be your downfall.
            if (results.Any())
                return Ok(results);

            return BadRequest("No restaurant exist.");
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRestaurants()
        {
            var rest = new[]
            {
                new Resturant
                {
                    Name = "Stuk",
                    Description = "Kårhusresturangen i C-huset",
                    OpensWhen = LocalTime.FromHoursSinceMidnight(11),
                    OpenFor = Period.FromHours(4)
                },
                new Resturant
                {
                    Name = "Centrumresturangen",
                    Description = "Centrumresturangen i B-huset",
                    OpensWhen = LocalTime.FromHoursSinceMidnight(11),
                    OpenFor = Period.FromHours(4)
                }
            };
       

            await _lunchDbContext.Resturants.AddRangeAsync(rest);
            await _lunchDbContext.SaveChangesAsync();

            return Ok();
        }
        }
    }


