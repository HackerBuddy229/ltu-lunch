using System.Globalization;
using LtuLunch.Server.data;
using LtuLunch.Server.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LtuLunch.Server.Controllers;

[ApiController]
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
    public async Task<IActionResult> GetLunchByWeek([FromQuery] int week = 0)
    {
        week = week == 0 ? _weekService.GetCurrentWeek() : week;

        var lunches = await _lunchDbContext.Lunches
            .Where(x => _weekService.GetWeekByDateTime(x.When) == week)
            .ToListAsync();

        if (lunches.Any())
            return Ok(lunches);

        return BadRequest("No lunch found!");
    }

    public async Task<IActionResult> GetLunchByDay([FromQuery] DateOnly day)
    {
        var lunches = await _lunchDbContext.Lunches
            .Where(x => DateOnly.FromDateTime(x.When) == day)
            .ToListAsync();

        if (lunches.Any())
            return Ok(lunches);

        return BadRequest("No lunch Found");
    }
}