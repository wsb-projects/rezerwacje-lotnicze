using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Application.Services;
using rezerwacje_lotnicze.Domain.Entities.User;
using rezerwacje_lotnicze.Infrastructure;
using rezerwacje_lotnicze.Infrastructure.Extensions;
using rezerwacje_lotnicze.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSwaggerServices();
builder.Services.AddIdentityServices();
builder.Services.AddFlightBookingDbContext(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.Services.ApplyMigrations();
await app.SeedDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();