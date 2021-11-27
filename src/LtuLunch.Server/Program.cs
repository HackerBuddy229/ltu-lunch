using LtuLunch.Server.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "LtuLunch.Server", Version = "v1" }); });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(@"Host=localhost:49153;Username=postgres;Password=test123;Database=ltulunch");
    //options.UseInMemoryDatabase("testing-db");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LtuLunch.Server v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();