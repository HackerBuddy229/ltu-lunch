using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LtuLunch.Server.data;
using LtuLunch.Server.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using NodaTime.Calendars;

namespace LtuLunch.Server.Controllers
{
    [ApiController]
    [Route("/api/lunch")]
    public class LunchController : Controller
    {
        private readonly LunchDbContext _lunchDbContext;
        private readonly WeekService _weekService;

        public LunchController(LunchDbContext lunchDbContext, WeekService weekService)
        {
            _lunchDbContext = lunchDbContext;
            _weekService = weekService;
        }

        [HttpGet]
        [Route("byWeek")]
        public async Task<IActionResult> GetLunchByWeek([FromQuery] int week = 0)
        {
            week = week == 0 ? _weekService.GetCurrentWeek() : week;

        var lunches = await _lunchDbContext.Lunches
            .Where(x =>  _weekService.GetWeekByLocalDate(x.When) == week)
            .ToListAsync();

            if (lunches.Any())
                return Ok(lunches);

            return BadRequest("No lunch found!");
        }

        [HttpGet]
        [Route("byDay")]
        public async Task<IActionResult> GetLunchByDay([FromQuery] int year, int month, int date)
        {
            var day = new LocalDate(year, month, date);
            var lunches = await _lunchDbContext.Lunches
                .Where(x => x.When == day)
                .ToListAsync();

            if (lunches.Any())
                return Ok(lunches);

            return BadRequest("No lunch Found");
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> CreateLunchForResturant()
        {
            var stuk = await _lunchDbContext.Resturants
                .FirstAsync(x => x.Id == "1abb70a1-f5ec-4d08-a2f1-e6608d24bd24");
            
            var centrum = await _lunchDbContext.Resturants
                .FirstAsync(x => x.Id == "00e22596-50b2-416e-9632-9b5aad6463ce");

            var lunches = new[]
            {
                new Lunch
                {
                    Title = "Korv",
                    Description = "Lunch korv med senaps stuvad potatis & syrad kålsallad",
                    Price = 85,
                    Resturant = centrum,
                    Tags = {"Dagens"},
                    When = new LocalDate(2021, 11, 29)
                },
                new Lunch
                {
                    Title = "Gratinerad fisk",
                    Description = "Gratinerad fisk med hunnersås & kokt potatis",
                    Price = 85,
                    Resturant = centrum,
                    Tags = {"Fisk"},
                    When = new LocalDate(2021, 11, 29)
                },
                new Lunch
                {
                    Title = "Asiatiska biffar",
                    Description = "Asiatiska biffar med ananas, mango & ris",
                    Price = 85,
                    Resturant = centrum,
                    Tags = {"Veg"},
                    When = new LocalDate(2021, 11, 29)
                },
            };
            
            await _lunchDbContext.Lunches.AddRangeAsync(lunches);
            await _lunchDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

