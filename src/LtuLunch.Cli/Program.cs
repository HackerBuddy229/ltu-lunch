// See https://aka.ms/new-console-template for more information

using LtuLunch.Server.data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
RestaurantPrefab.CreateRestaurants();

static class RestaurantPrefab
{
    public async static Task CreateRestaurants()
    {
        using var dbContext = new LunchDbContext(new DbContextOptions<LunchDbContext>());

        var restaurants = new[]
        {
            new Resturant
            {
                Name = "Stuk",
                Description = "Kårhusresturangen i C-huset",
                OpensWhen = TimeOnly.FromTimeSpan(TimeSpan.FromHours(11)),
                OpenFor = TimeSpan.FromHours(4)
            },
            new Resturant
            {
                Name = "Centrumresturangen",
                Description = "Centrumresturangen i B-huset",
                OpensWhen = TimeOnly.FromTimeSpan(TimeSpan.FromHours(11)),
                OpenFor = TimeSpan.FromHours(4)
            },
        };

        await dbContext.Resturants.AddRangeAsync(restaurants);
        await dbContext.SaveChangesAsync();
    }
}